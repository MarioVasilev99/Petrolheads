namespace Petrolheads.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ProfilesController : Controller
    {
        public ProfilesController()
        {

        }

        [Authorize]
        public IActionResult Cars()
        {
            return this.View();
        }
    }
}
