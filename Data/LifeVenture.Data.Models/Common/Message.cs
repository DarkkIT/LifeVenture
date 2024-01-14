namespace LifeVenture.Data.Models.Common
{
    using LifeVenture.Data.Common.Models;

    public class Message : BaseDeletableModel<int>
    {
        public string SenderName { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public string Description { get; set; }

        public int? Phone { get; set; }
    }
}
