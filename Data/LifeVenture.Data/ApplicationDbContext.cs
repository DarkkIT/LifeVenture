﻿namespace LifeVenture.Data
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    using LifeVenture.Data.Common.Models;
    using LifeVenture.Data.Models;
    using LifeVenture.Data.Models.Common;
    using LifeVenture.Data.Models.Events;
    using LifeVenture.Data.Models.Locations;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        private static readonly MethodInfo SetIsDeletedQueryFilterMethod =
            typeof(ApplicationDbContext).GetMethod(
                nameof(SetIsDeletedQueryFilter),
                BindingFlags.NonPublic | BindingFlags.Static);

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Setting> Settings { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CountryPhoneCode> CountriesPhoneCodes { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Phone> Phones { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Municipality> Municipalities { get; set; }

        public DbSet<Settlement> Settlements { get; set; }

        public DbSet<Region> Regions { get; set; }

        public override int SaveChanges() => this.SaveChanges(true);

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            this.SaveChangesAsync(true, cancellationToken);

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Phone>()
                .HasOne(x => x.User)
                .WithOne(x => x.Phone)
                .HasForeignKey<Phone>(x => x.UserId);

            builder.Entity<Event>()
                .HasOne(e => e.Image)
                .WithOne(i => i.Event)
                .HasForeignKey<Event>(e => e.ImageId)
                .IsRequired(false);

            builder.Entity<ApplicationUser>()
                .HasMany(u => u.UserEvents)
                .WithOne(e => e.CreatedBy)
                .HasForeignKey(e => e.CreatedById)
                .IsRequired(true);

            builder.Entity<ApplicationUser>()
                .HasMany(u => u.EventsТоАttend)
                .WithMany(e => e.Volunteers);

            builder.Entity<ApplicationUser>()
                .HasOne(u => u.Image)
                .WithOne(i => i.User)
                .HasForeignKey<ApplicationUser>(u => u.ImageId);

            builder.Entity<ApplicationUser>()
                .HasMany(u => u.LikedEvents)
                .WithMany(e => e.UserLikes);

            // Needed for Identity models configuration
            base.OnModelCreating(builder);

            this.ConfigureUserIdentityRelations(builder);

            EntityIndexesConfiguration.Configure(builder);

            var entityTypes = builder.Model.GetEntityTypes().ToList();

            // Set global query filter for not deleted entities only
            var deletableEntityTypes = entityTypes
                .Where(et => et.ClrType != null && typeof(IDeletableEntity).IsAssignableFrom(et.ClrType));
            foreach (var deletableEntityType in deletableEntityTypes)
            {
                var method = SetIsDeletedQueryFilterMethod.MakeGenericMethod(deletableEntityType.ClrType);
                method.Invoke(null, new object[] { builder });
            }

            // Disable cascade delete
            var foreignKeys = entityTypes
                .SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));
            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        private static void SetIsDeletedQueryFilter<T>(ModelBuilder builder)
            where T : class, IDeletableEntity
        {
            builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        }

        // Applies configurations
        private void ConfigureUserIdentityRelations(ModelBuilder builder)
             => builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        private void ApplyAuditInfoRules()
        {
            var changedEntries = this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IAuditInfo &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in changedEntries)
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default)
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}
