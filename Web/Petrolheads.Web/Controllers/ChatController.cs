﻿namespace Petrolheads.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ChatController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
