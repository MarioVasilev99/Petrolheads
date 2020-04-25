namespace Petrolheads.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Petrolheads.Data.Models;
    using Petrolheads.Services.Data.Cars;
    using Petrolheads.Services.Data.Makes;
    using Petrolheads.Web.ViewModels.Cars;

    public class CarsController : Controller
    {
        private readonly IMakesService makesService;
        private readonly ICarsService carsService;
        private readonly UserManager<ApplicationUser> userManager;

        public CarsController(
            IMakesService makesService,
            ICarsService carsService,
            UserManager<ApplicationUser> userManager)
        {
            this.makesService = makesService;
            this.carsService = carsService;
            this.userManager = userManager;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            var makes = this.makesService.GetAll();
            var createCarViewModel = new AddCarInputModel()
            {
                Makes = new SelectList(makes, "Id", "Name"),
            };

            return this.View(createCarViewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(AddCarInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var userId = this.userManager.GetUserId(this.User);
            await this.carsService.CreateCar(userId, input);

            return this.RedirectToAction("Cars", "Profiles");
        }

        [Authorize]
        public IActionResult Details(int? carId)
        {
            if (carId == null)
            {
                return this.NotFound();
            }

            var carDetailsViewModel = this.carsService.GetCarDetails((int)carId);

            if (carDetailsViewModel == null)
            {
                return this.NotFound();
            }

            var currentUserId = this.userManager.GetUserId(this.User);
            var isEditable = currentUserId == carDetailsViewModel.UserId ? true : false;
            carDetailsViewModel.IsEditable = isEditable;

            return this.View(carDetailsViewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Delete(int? carId)
        {
            if (carId == null)
            {
                return this.NotFound();
            }

            var carDetailsViewModel = this.carsService.GetCarDetails((int)carId);

            if (carDetailsViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(carDetailsViewModel);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> DeleteConfirm(int? carId)
        {
            if (carId == null)
            {
                return this.NotFound();
            }

            var userId = this.userManager.GetUserId(this.User);
            await this.carsService.DeleteCar(userId, (int)carId);

            return this.RedirectToAction("Cars", "Profiles", new { userId = userId });
        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit(int? carId)
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
        public async Task<IActionResult> Edit(CarDetailsEditViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.carsService.EditCar(input);
            return this.RedirectToAction("Details", "Cars", new { carId = input.Id });
        }
    }
}
