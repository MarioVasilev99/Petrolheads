﻿namespace Petrolheads.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
