namespace LifeVenture.Web.Controllers
{
    using LifeVenture.Web.ViewModels.AboutUs;
    using LifeVenture.Web.ViewModels.Common;
    using Microsoft.AspNetCore.Mvc;

    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            var aboutUsViewModel = new AboutUsViewModel();
            aboutUsViewModel.Input = new MessageInputModel();

            return this.View(aboutUsViewModel);
        }
    }
}
