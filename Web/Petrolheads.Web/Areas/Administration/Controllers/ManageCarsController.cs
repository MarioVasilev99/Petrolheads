namespace Petrolheads.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Petrolheads.Common;
    using Petrolheads.Services.Data.Administration.ManageCars;
    using Petrolheads.Services.Data.Cars;
    using Petrolheads.Web.ViewModels.Cars;
    using System.Threading.Tasks;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class ManageCarsController : Controller
    {
        private readonly IManageCarsService manageCarsService;
        private readonly ICarsService carsService;

        public ManageCarsController(
            IManageCarsService manageCarsService,
            ICarsService carsService)
        {
            this.manageCarsService = manageCarsService;
            this.carsService = carsService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = this.manageCarsService.GetAll();

            return this.View(viewModel);
        }

        public async Task<IActionResult> RemoveCar(int? carId)
        {
            if (carId == null)
            {
                return this.NotFound();
            }

            await this.manageCarsService.RemoveCar((int)carId);

            return this.RedirectToAction("Index", "ManageCars", new { area = "Administration" });
        }

        [HttpGet]
        [Authorize]
        public IActionResult EditCar(int? carId)
        {
            if (carId == null)
            {
                return this.NotFound();
            }

            var carDetailsEditViewModel = this.carsService.GetCarEditDetails((int)carId);
            if (carDetailsEditViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(carDetailsEditViewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EditCar(CarDetailsEditViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.carsService.EditCar(input);
            return this.RedirectToAction("Index", "ManageCars", new { area = "Administration" });
        }
    }
}
