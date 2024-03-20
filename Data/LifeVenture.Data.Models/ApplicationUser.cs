namespace LifeVenture.Data.Models
{
    using System;
    using System.Collections.Generic;

    using LifeVenture.Data.Common.Models;
    using LifeVenture.Data.Models.Common;
    using LifeVenture.Data.Models.Events;
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.EventsТоАttend = new HashSet<Event>();
            this.UserEvents = new HashSet<Event>();
            this.LikedEvents = new HashSet<Event>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? Age { get; set; }

        public Phone Phone { get; set; }

        public string Nationality { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public int? ImageId { get; set; }

        public Image Image { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual ICollection<Event> UserEvents { get; set; }

        public virtual ICollection<Event> EventsТоАttend { get; set; }

        public virtual ICollection<Event> LikedEvents { get; set; }
    }
}
