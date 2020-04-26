namespace Petrolheads.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Petrolheads.Common;
    using Petrolheads.Services.Data.Administration.ManagePosts;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class ManagePostsController : Controller
    {
        private readonly IManagePostsService managePostsService;

        public ManagePostsController(IManagePostsService managePostsService)
        {
            this.managePostsService = managePostsService;
        }

        public IActionResult Index()
        {
            var viewModel = this.managePostsService.GetAllPosts(50);
            return this.View(viewModel);
        }
    }
}
