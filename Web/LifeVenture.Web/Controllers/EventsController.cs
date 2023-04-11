namespace LifeVenture.Web.Controllers
{
    using LifeVenture.Services.Data;
    using LifeVenture.Web.ViewModels.Events;
    using LifeVenture.Web.ViewModels.Settings;
    using Microsoft.AspNetCore.Mvc;

    public class EventsController : BaseController
    {
        private readonly IEventsService eventsService;

        public EventsController(IEventsService eventsService)
        {
            this.eventsService = eventsService;
        }

        public IActionResult Index()
        {
            var events = this.eventsService.GetAll<EventViewModel>();
            return this.View(events);
        }
    }
}
