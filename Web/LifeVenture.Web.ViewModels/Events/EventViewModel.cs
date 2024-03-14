namespace LifeVenture.Web.ViewModels.Events
{
    using System;

    using AutoMapper;
    using LifeVenture.Data.Models.Events;
    using LifeVenture.Services.Mapping;
    using LifeVenture.Web.ViewModels.Common;

    public class EventViewModel : IMapFrom<Event>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public ImageViewModel Image { get; set; }

        public DateTime StartDate { get; set; }

        public int MaxParticipantsCount { get; set; }

        public int VolunteersCount { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Event, EventViewModel>().ForMember(
                m => m.VolunteersCount,
                opt => opt.MapFrom(x => x.Volunteers.Count));
        }
    }
}
