namespace LifeVenture.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class PeopleOfGoodnessController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
