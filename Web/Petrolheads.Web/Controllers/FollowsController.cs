namespace Petrolheads.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Petrolheads.Data.Models;
    using Petrolheads.Services.Data.Follows;
    using Petrolheads.Web.ViewModels.Follows;

    public class FollowsController : Controller
    {
        private readonly IFollowsService followsService;
        private readonly UserManager<ApplicationUser> userManager;

        public FollowsController(
            IFollowsService followsService,
            UserManager<ApplicationUser> userManager)
        {
            this.followsService = followsService;
            this.userManager = userManager;
        }

        [Authorize]
        [Route("/[controller]/[action]")]
        public async Task<IActionResult> Unfollow(UnfollowInputModel input)
        {
            await this.followsService.UnfollowUserAsync(input.UserId, input.FollowedUserId);

            var currentUserId = this.userManager.GetUserId(this.User);
            return this.RedirectToAction("Followed", "Profiles", new { userId = currentUserId });
        }
    }
}
