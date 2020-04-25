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
            var carId = await this.carsService.CreateCar(userId, input);

            return this.RedirectToAction("Cars", "Profiles");
        }

        [Authorize]
        public IActionResult Details(int carId)
        {
            var carDetailsViewModel = this.carsService.GetCarDetails(carId);

            if (carDetailsViewModel == null)
            {
                return this.NotFound();
            }

            var currentUserId = this.userManager.GetUserId(this.User);
            var isEditable = currentUserId == carDetailsViewModel.UserId ? true : false;
            carDetailsViewModel.IsEditable = isEditable;

            return this.View(carDetailsViewModel);
        }
    }
}
