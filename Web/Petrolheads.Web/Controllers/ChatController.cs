namespace Petrolheads.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
