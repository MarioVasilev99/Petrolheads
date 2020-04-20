namespace Petrolheads.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Petrolheads.Data.Models;
    using Petrolheads.Services.Data;
    using Petrolheads.Web.ViewModels.Likes;
    using Petrolheads.Web.ViewModels.Votes;

    [ApiController]
    [Route("api/[controller]")]
    public class LikesController : ControllerBase
    {
        private readonly ILikesService likesService;
        private readonly UserManager<ApplicationUser> userManager;

        public LikesController(ILikesService likesService, UserManager<ApplicationUser> userManager)
        {
            this.likesService = likesService;
            this.userManager = userManager;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<LikeResponseModel>> Post(LikeInputModel input)
        {
            var userId = this.userManager.GetUserId(this.User);
            await this.likesService.LikeAsync(input.PostId, userId);
            var likes = this.likesService.GetLikesCount(input.PostId);
            return likes;
        }
    }
}
