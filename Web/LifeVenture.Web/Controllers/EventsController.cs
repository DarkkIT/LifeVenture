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
        [RequestSizeLimit(20 * 1024 * 1024)]
        public async Task<IActionResult> Create(CreateEventViewModel input)
        {
            if (input.Image.Length > 10 * 1024 * 1024)
            {
                this.ModelState.AddModelError("Image", "Снимката не може да бъде по-голяма от 10 MB.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.eventsService.CreateEvent(input);

            return this.RedirectToAction(nameof(this.Success));
        }

        public IActionResult Success() => this.View();
    }
}
