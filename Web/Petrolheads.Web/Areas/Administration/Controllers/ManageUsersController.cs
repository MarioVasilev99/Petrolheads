namespace Petrolheads.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Petrolheads.Common;
    using Petrolheads.Services.Data.Administration.ManageUsers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class ManageUsersController : Controller
    {
        private readonly IManageUsersService usersService;

        public ManageUsersController(IManageUsersService usersService)
        {
            this.usersService = usersService;
        }

        public IActionResult Index()
        {
            var viewModel = this.usersService.GetAll();
            return this.View(viewModel);
        }
    }
}
