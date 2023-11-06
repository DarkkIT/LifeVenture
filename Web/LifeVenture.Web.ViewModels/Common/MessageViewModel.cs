namespace LifeVenture.Web.ViewModels.Common
{
    using LifeVenture.Data.Models.Common;
    using LifeVenture.Services.Mapping;

    public class MessageViewModel : IMapFrom<Message>
    {
        public int Id { get; set; }

        public string SenderName { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public string Description { get; set; }

        public int? Phone { get; set; }
    }
}
