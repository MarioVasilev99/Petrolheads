﻿namespace Petrolheads.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Petrolheads.Common;
    using Petrolheads.Data.Models;
    using Petrolheads.Services.Data.Profiles;

    public class ProfilesController : Controller
    {
        private readonly IProfilesService profilesService;
        private readonly UserManager<ApplicationUser> userManager;

        public ProfilesController(IProfilesService profilesService, UserManager<ApplicationUser> userManager)
        {
            this.profilesService = profilesService;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Cars(string userId)
        {
            var currentUserId = this.userManager.GetUserId(this.User);

            if (userId == null)
            {
                userId = currentUserId;
            }

            var viewModel = this.profilesService.GetUserInfoWithCars(userId);
            var isProfileOwner = UserProfileHelper.CheckIfProfileOwner(userId, currentUserId);
            viewModel.IsProfileOwner = isProfileOwner;

            return this.View(viewModel);
        }

        public IActionResult Posts(string userId)
        {
            var currentUserId = this.userManager.GetUserId(this.User);

            if (userId == null)
            {
                userId = currentUserId;
            }

            var viewModel = this.profilesService.GetUserInfoWithPosts(userId);
            var isProfileOwner = UserProfileHelper.CheckIfProfileOwner(userId, currentUserId);
            viewModel.IsProfileOwner = isProfileOwner;

            return this.View(viewModel);
        }
    }
}
