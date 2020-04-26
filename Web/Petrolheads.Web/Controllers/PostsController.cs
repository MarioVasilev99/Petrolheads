namespace Petrolheads.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Petrolheads.Data.Models;
    using Petrolheads.Services.Data.Posts;
    using Petrolheads.Web.ViewModels.Posts;

    public class PostsController : Controller
    {
        private readonly IPostsService postsService;
        private readonly UserManager<ApplicationUser> userManager;

        public PostsController(IPostsService postsService, UserManager<ApplicationUser> userManager)
        {
            this.postsService = postsService;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreatePostInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var userId = this.userManager.GetUserId(this.User);
            var postId = await this.postsService.CreatePost(userId, input);

            return this.Redirect("/");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Edit(int? postId)
        {
            if (postId == null)
            {
                return this.NotFound();
            }

            var userId = this.userManager.GetUserId(this.User);
            var postEditViewModel = this.postsService.GetPostEditDetails(userId, (int)postId);

            if (postEditViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(postEditViewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(EditPostInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var userId = this.userManager.GetUserId(this.User);
            await this.postsService.EditPost(userId, input);

            return this.RedirectToAction("Posts", "Profiles", new { userId = userId });
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Delete(int? postId)
        {
            if (postId == null)
            {
                return this.NotFound();
            }

            var userId = this.userManager.GetUserId(this.User);
            await this.postsService.DeletePost(userId, (int)postId);

            return this.RedirectToAction("Posts", "Profiles", new { userId = userId });
        }
    }
}
