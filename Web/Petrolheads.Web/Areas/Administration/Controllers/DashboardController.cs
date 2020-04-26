namespace Petrolheads.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Petrolheads.Common;
    using Petrolheads.Services.Data.Administration.Dashboard;
    using Petrolheads.Services.Data.Settings;
    using Petrolheads.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class DashboardController : BaseController
    {
        private readonly ISettingsService settingsService;
        private readonly IDashboardService dashboardService;

        public DashboardController(
            ISettingsService settingsService,
            IDashboardService dashboardService)
        {
            this.settingsService = settingsService;
            this.dashboardService = dashboardService;
        }

        public IActionResult Index()
        {
            var viewModel = this.dashboardService.GetAppInfo();
            return this.View(viewModel);
        }
    }
}
