namespace LifeVenture.Web.Controllers
{
    using System.Threading.Tasks;

    using LifeVenture.Services.Data;
    using LifeVenture.Web.ViewModels.Events;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class EventsController : BaseController
    {
        private readonly IEventsService eventsService;

        public EventsController(IEventsService eventsService)
        {
            this.eventsService = eventsService;
        }

        public async Task<IActionResult> Index()
        {
            var events = await this.eventsService.GetAll<EventViewModel>();
            return this.View(events);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new CreateEventViewModel();
            viewModel.Categories = await this.eventsService.GetAllCategories();

            var phoneCodes = await this.eventsService.GetAllPhoneCodes();
            viewModel.Phone = new PhoneViewModel();
            viewModel.Phone.Codes = phoneCodes;
            viewModel.Regions = await this.eventsService.GetAllRegions();

            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateEventInputModel model, IFormFile image)
        {
            if (!this.ModelState.IsValid)
            {
                // return this.RedirectToAction(nameof(this.Create));
            }

            return this.Ok();
        }
    }
}
