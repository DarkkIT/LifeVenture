namespace LifeVenture.Web.Controllers
{
    using LifeVenture.Services.Data;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Events;

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

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new EventInputViewModel();
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(EventInputViewModel model)
        {
            return this.View(nameof(this.Create));
        }
    }
}
