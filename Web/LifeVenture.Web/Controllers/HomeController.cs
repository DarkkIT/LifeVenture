namespace LifeVenture.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using LifeVenture.Common;
    using LifeVenture.Data.Models;
    using LifeVenture.Services.Data;
    using LifeVenture.Web.ViewModels;
    using LifeVenture.Web.ViewModels.Home;
    using LifeVenture.Web.ViewModels.Users;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class HomeController : BaseController
    {
        private readonly IEventsService eventsService;
        private readonly UserManager<ApplicationUser> userManager;

        public HomeController(
            IEventsService eventsService,
            UserManager<ApplicationUser> userManager)
        {
            this.eventsService = eventsService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await this.userManager.Users.ToListAsync();
            var usersWithRoleCount = this.userManager.GetUsersInRoleAsync(GlobalConstants.HeroRoleName).Result.Count;

            var userStatistics = new UserStatisticalInfoViewModel
            {
                UsersCount = users.Count,
                HeroesCount = usersWithRoleCount,
            };

            var viewModel = new HomeViewModel();
            var statisticalInfoViewModel = new StatisticalInfoViewModel
            {
                EventStatistic = await this.eventsService.GetEventStatistics(),
                UserStatistic = userStatistics,
            };

            viewModel.StatisticalInfo = statisticalInfoViewModel;

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
