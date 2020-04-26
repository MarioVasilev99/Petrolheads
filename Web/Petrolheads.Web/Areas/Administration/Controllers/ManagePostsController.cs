namespace Petrolheads.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Petrolheads.Common;
    using Petrolheads.Services.Data.Administration.ManagePosts;
    using Petrolheads.Services.Data.Posts;
    using Petrolheads.Web.ViewModels.Posts;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class ManagePostsController : Controller
    {
        private readonly IManagePostsService managePostsService;
        private readonly IPostsService postsService;

        public ManagePostsController(
            IManagePostsService managePostsService,
            IPostsService postsService)
        {
            this.managePostsService = managePostsService;
            this.postsService = postsService;
        }

        [Authorize]
        public IActionResult Index()
        {
            var viewModel = this.managePostsService.GetAllPosts(50);
            return this.View(viewModel);
        }

        [Authorize]
        [HttpGet]
        public IActionResult EditPost(int? postId, string userId)
        {
            if (postId == null || string.IsNullOrEmpty(userId))
            {
                return this.NotFound();
            }

            var postEditViewModel = this.postsService.GetPostEditDetails(userId, (int)postId);
            postEditViewModel.IsAdminArea = true;

            if (postEditViewModel == null)
            {
                return this.NotFound();
            }

            return this.View("~/Views/Posts/Edit.cshtml", postEditViewModel);
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditPost(EditPostInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }
            await this.postsService.EditPost(input.UserId, input);

            return this.RedirectToAction("Index", "ManagePosts", new { area = "Administration" });
        }

        [Authorize]
        public async Task<IActionResult> DeletePost(int? postId)
        {
            if (postId == null)
            {
                return this.NotFound();
            }

            await this.managePostsService.DeletePost((int)postId);
            return this.RedirectToAction("Index", "ManagePosts", new { area = "Administration" });
        }
    }
}
