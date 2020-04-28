namespace Petrolheads.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Petrolheads.Data.Models;
    using Petrolheads.Services.Data.Follows;
    using Petrolheads.Web.ViewModels.Follows;

    [ApiController]
    [Route("api/follows")]
    public class FollowsApiController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IFollowsService followsService;

        public FollowsApiController(
            UserManager<ApplicationUser> userManager,
            IFollowsService followsService)
        {
            this.userManager = userManager;
            this.followsService = followsService;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<FollowResponseModel>> Follow(FollowInputModel input)
        {
            var userToFollow = await this.userManager.FindByIdAsync(input.UserId);

            if (userToFollow == null)
            {
                return this.NotFound();
            }

            var currentUserId = this.userManager.GetUserId(this.User);
            var isSuccessful = await this.followsService.FollowUserAsync(currentUserId, input.UserId);
            return isSuccessful;
        }
    }
}
