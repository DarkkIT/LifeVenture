namespace LifeVenture.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using LifeVenture.Services.Data;
    using LifeVenture.Web.ViewModels.Events;
    using LifeVenture.Web.ViewModels.Image;
    using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
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
        [Authorize]
        [RequestSizeLimit(20 * 1024 * 1024)]
        public async Task<IActionResult> Create(CreateEventViewModel eventInput, IFormFile image)
        {
            if (image == null)
            {
                this.ModelState.AddModelError("Image", "Снимката е задължителна!.");
                eventInput.ImageError = "Снимката е задължителна!";
            }

            if (image != null && image.Length > 10 * 1024 * 1024)
            {
                this.ModelState.AddModelError("Image", "Снимката не може да бъде по-голяма от 10 MB.");
            }

            if (!this.ModelState.IsValid)
            {
                eventInput.Categories = await this.eventsService.GetAllCategories();

                eventInput.Phone.Codes = await this.eventsService.GetAllPhoneCodes();
                eventInput.Regions = await this.eventsService.GetAllRegions();

                return this.View(eventInput);
            }

            var imageInputModel = new ImageInputModel
            {
                Name = image?.FileName,
                Type = image?.ContentType,
                Content = image?.OpenReadStream(),
            };

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await this.eventsService.CreateEvent(eventInput, imageInputModel, userId);

            return this.RedirectToAction(nameof(this.Success));
        }

        public IActionResult Success() => this.View();
    }
}
