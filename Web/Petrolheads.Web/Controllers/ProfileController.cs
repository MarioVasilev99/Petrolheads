namespace Petrolheads.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ProfileController : Controller
    {
        public IActionResult Cars()
        {
            return this.View();
        }
    }
}
