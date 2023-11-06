namespace LifeVenture.Web.Controllers
{
    using System.Collections.Generic;

    using LifeVenture.Services.Data;
    using LifeVenture.Web.ViewModels.Events;
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

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new EventInputViewModel();
            viewModel.Categories = new List<KeyValuePair<string, string>>() { new KeyValuePair<string, string>("2", "Гъз") };
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(EventInputViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(this.Create));
            }

            // var userId = this.userManager.GetUserId(this.User);
            // var carId = await this.carsService.CreateCarAsync(input, userId);

            // if (input.Images != null)
            // {
            //    var imagePath = $"{this.environment.WebRootPath}/img";

            // var imageUploadModel = new ImageUploadViewModel();
            //    imageUploadModel.Images = input.Images;
            //    imageUploadModel.Path = imagePath;
            //    imageUploadModel.UserId = userId;
            //    imageUploadModel.ImageTypeName = GlobalConstants.CarExternalImage;
            //    imageUploadModel.CarId = carId;

            // await this.imagesService.UploadImages(imageUploadModel);
            // }

            // this.TempData["Message"] = "You can drive now. Your car is created successufully";
            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
