namespace LifeVenture.Web.ViewModels.Users
{
    using System;

    using LifeVenture.Data.Models;
    using LifeVenture.Services.Mapping;

    public class ApplicationUserViewModel : IMapFrom<ApplicationUser>
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Nationality { get; set; }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }
    }
}
