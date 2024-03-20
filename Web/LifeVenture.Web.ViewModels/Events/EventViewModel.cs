namespace LifeVenture.Web.ViewModels.Events
{
    using System;

    using AutoMapper;
    using LifeVenture.Data.Models.Events;
    using LifeVenture.Services.Mapping;
    using LifeVenture.Web.ViewModels.Common;

    public class EventViewModel : IMapFrom<Event>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ShortDescription { get; set; }

        public int Likes { get; set; }

        public ImageViewModel Image { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int DaysLeft => (this.EndDate.Date - DateTime.UtcNow.Date).Days;

        public int MaxParticipantsCount { get; set; }

        public int VolunteersCount { get; set; }

        public int ViewsCount { get; set; }

        public int ParticipationsPercentage => (int)((double)this.VolunteersCount / this.MaxParticipantsCount * 100);

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<Event, EventViewModel>()
                .ForMember(
                    m => m.Title,
                    opt => opt.MapFrom(x => x.Title.ToUpper()))
                .ForMember(
                    m => m.Likes,
                    opt => opt.MapFrom(x => x.UserLikes.Count))
                .ForMember(
                    m => m.VolunteersCount,
                    opt => opt.MapFrom(x => x.Volunteers.Count))
                .ForMember(
                    m => m.ShortDescription,
                    opt => opt.MapFrom(x => x.Description.Substring(0, Math.Min(x.Description.Length, 100))));
        }
    }
}
