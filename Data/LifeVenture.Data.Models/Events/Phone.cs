namespace LifeVenture.Data.Models.Events
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using LifeVenture.Data.Common.Models;

    public class Phone : BaseDeletableModel<int>
    {
        public Phone()
        {
            this.Events = new HashSet<Event>();
        }

        [Required]
        [MaxLength(30)]
        public string Number { get; set; }

        public int CodeId { get; set; }

        public virtual CountryPhoneCode Code { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
