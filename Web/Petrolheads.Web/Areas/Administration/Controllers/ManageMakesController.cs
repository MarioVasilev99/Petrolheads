namespace Petrolheads.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Petrolheads.Common;
    using Petrolheads.Services.Data.Administration.ManageMakes;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class ManageMakesController : Controller
    {
        private readonly IManageMakesService manageMakesService;

        public ManageMakesController(IManageMakesService manageMakesService)
        {
            this.manageMakesService = manageMakesService;
        }

        public IActionResult Index()
        {
            var viewModel = this.manageMakesService.GetAll();

            return this.View(viewModel);
        }
    }
}
