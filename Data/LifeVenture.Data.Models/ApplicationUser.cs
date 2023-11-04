namespace LifeVenture.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using LifeVenture.Data.Common.Models;
    using LifeVenture.Data.Models.Events;
    using LifeVenture.Data.Models.People;
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
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

        public int? PersonOfGoodnessId { get; set; }

        public virtual PersonOfGoodness PersonOfGoodness { get; set; }

        public int? VolunteerId { get; set; }

        public virtual Volunteer Volunteer { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
    }
}
