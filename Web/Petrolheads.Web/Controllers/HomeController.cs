namespace Petrolheads.Web.Controllers
{
    using System;
    using System.Diagnostics;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Petrolheads.Services.Data.Posts;
    using Petrolheads.Web.ViewModels;
    using Petrolheads.Web.ViewModels.Posts;

    [Authorize]
    public class HomeController : BaseController
    {
        private const int PostsPerPage = 10;

        private readonly IPostsService postsService;

        public HomeController(IPostsService postsService)
        {
            this.postsService = postsService;
        }

        [Authorize]
        public IActionResult Index(int page = 1)
        {
            var viewModel = new AllPostsViewModel();
            viewModel.AllPosts = this.postsService.GetPosts<PostViewModel>(PostsPerPage, (page - 1) * PostsPerPage);

            var postsCount = this.postsService.GetCount();
            viewModel.PagesCount = (int)Math.Ceiling((double)postsCount / PostsPerPage);
            viewModel.CurrentPage = page;

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
