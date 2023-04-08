namespace LifeVenture.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class EventsController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
