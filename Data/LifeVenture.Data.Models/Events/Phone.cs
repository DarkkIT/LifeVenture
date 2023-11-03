namespace LifeVenture.Data.Models.Events
{
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;

    using LifeVenture.Data.Common.Models;

    public class Phone : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(30)]
        public string Number { get; set; }

        public int CodeId { get; set; }

        public virtual CountryPhoneCode Code { get; set; }

        [AllowNull]
        public int EventId { get; set; }

        public Event Event { get; set; }

        [AllowNull]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
