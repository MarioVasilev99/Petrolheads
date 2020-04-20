namespace Petrolheads.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Petrolheads.Data.Models;
    using Petrolheads.Services;

    public class ProfilesController : Controller
    {
        private readonly IProfilesService profilesService;
        private readonly UserManager<ApplicationUser> userManager;

        public ProfilesController(IProfilesService profilesService, UserManager<ApplicationUser> userManager)
        {
            this.profilesService = profilesService;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Cars(string userId)
        {
            if (userId == null)
            {
                userId = this.userManager.GetUserId(this.User);
            }

            var viewModel = this.profilesService.GetUserInfoWithCars(userId);

            return this.View(viewModel);
        }
    }
}
