namespace LifeVenture.Web.Controllers
{
    using System.Diagnostics;

    using LifeVenture.Web.ViewModels;

    using Microsoft.AspNetCore.Mvc;

    public class EventsController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
