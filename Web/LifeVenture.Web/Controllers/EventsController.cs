namespace LifeVenture.Web.Controllers
{
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using LifeVenture.Services.Data;
    using LifeVenture.Web.ViewModels.Events;
    using LifeVenture.Web.ViewModels.Image;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    using static LifeVenture.Common.ErrorConstants.EventErrors;
    using static LifeVenture.Common.ErrorConstants.ImageErrors;
    using static LifeVenture.Common.InputConstants.InputCommonConstants;
    using static LifeVenture.Common.InputConstants.InputImageConstants;
    using static LifeVenture.Common.ViewConstants.EventsConstants;

    public class EventsController : BaseController
    {
        private readonly IEventsService eventsService;

        public EventsController(IEventsService eventsService)
        {
            this.eventsService = eventsService;
        }

        public async Task<IActionResult> Index(string sortOrder, string categoryId, string currentFilter, int pageNumber = 1)
        {
            var input = this.CreateSortOrder(sortOrder);

            if (categoryId != null)
            {
                pageNumber = 1;
            }
            else
            {
                categoryId = currentFilter;
            }

            this.ViewData["CurrentFilter"] = categoryId;

            if (!string.IsNullOrEmpty(categoryId))
            {
                input.CategoryId = int.Parse(categoryId);
            }

            var events = await this.eventsService.GetAll<EventViewModel>(pageNumber, ItemsPerPage, input);
            var categories = await this.eventsService.GetAllCategories();

            var categoriesAsSelectListItem = categories.Select(x => new SelectListItem(x.Value, x.Key, x.Key == categoryId ? true : false));

            var viewModel = new EventsListingViewModel<SelectListItem>
            {
                PaginatedEvents = events,
                Categories = categoriesAsSelectListItem,
            };

            return this.View(viewModel);
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
        [RequestSizeLimit(RequestSizeLimit)]
        public async Task<IActionResult> Create(CreateEventViewModel eventInput)
        {
            if (eventInput.Image != null && eventInput.Image.Length > ImageMaxSizeMb)
            {
                this.ModelState.AddModelError(Image, ImageMaxSizeErr);
            }

            if (eventInput.EndDate <= eventInput.StartDate)
            {
                this.ModelState.AddModelError(EndDate, EndDateErr);
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
                Name = eventInput.Image.FileName,
                Type = eventInput.Image.ContentType,
                Content = eventInput.Image.OpenReadStream(),
            };

            var eventInputModel = new CreateEventInputModel
            {
                CategoryId = eventInput.CategoryId,
                Title = eventInput.Title,
                Description = eventInput.Description,
                Email = eventInput.Email,
                StartDate = eventInput.StartDate,
                EndDate = eventInput.EndDate,
                IsUrgent = eventInput.IsUrgent,
                MaxParticipantsCount = eventInput.MaxParticipantsCount,
                Phone = eventInput.Phone,
                Image = imageInputModel,
                Locations = eventInput.Locations,
            };

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await this.eventsService.CreateEvent(eventInputModel, userId);

            return this.RedirectToAction(nameof(this.Success));
        }

        public IActionResult Success() => this.View();

        private EventsFiltersInputViewModel CreateSortOrder(string sortOrder)
        {
            this.ViewData["CurrentSort"] = sortOrder;
            this.ViewData["Latest"] = string.IsNullOrEmpty(sortOrder) ? "latest" : string.Empty;
            this.ViewData["MostPopular"] = sortOrder == "MostPopular" ? "most_popular" : "MostPopular";
            this.ViewData["MostVisited"] = sortOrder == "MostVisited" ? "most_visited" : "MostVisited";

            var input = new EventsFiltersInputViewModel();

            if (!string.IsNullOrEmpty(sortOrder))
            {
                if (sortOrder == "latest")
                {
                    input.Latest = true;
                }
                else if (sortOrder == "MostPopular")
                {
                    input.MostPopular = false;
                }
                else if (sortOrder == "most_popular")
                {
                    input.MostPopular = true;
                }
                else if (sortOrder == "MostVisited")
                {
                    input.MostVisited = false;
                }
                else if (sortOrder == "most_visited")
                {
                    input.MostVisited = true;
                }
            }

            return input;
        }
    }
}
