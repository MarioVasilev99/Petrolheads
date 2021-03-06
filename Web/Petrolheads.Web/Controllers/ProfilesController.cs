﻿namespace Petrolheads.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Petrolheads.Common;
    using Petrolheads.Data.Models;
    using Petrolheads.Services.Data.Follows;
    using Petrolheads.Services.Data.Profiles;
    using Petrolheads.Web.ViewModels.Profiles;
    using System.Threading.Tasks;

    public class ProfilesController : Controller
    {
        private readonly IProfilesService profilesService;
        private readonly IFollowsService followsService;
        private readonly UserManager<ApplicationUser> userManager;

        public ProfilesController(
            IProfilesService profilesService,
            IFollowsService followsService,
            UserManager<ApplicationUser> userManager)
        {
            this.profilesService = profilesService;
            this.followsService = followsService;
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

            var isFollowed = this.followsService.IsFollowed(userId, currentUserId);
            viewModel.IsFollowed = isFollowed;

            return this.View(viewModel);
        }

        [Authorize]
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

            var isFollowed = this.followsService.IsFollowed(userId, currentUserId);
            viewModel.IsFollowed = isFollowed;

            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult Followed(string userId)
        {
            var currentUserId = this.userManager.GetUserId(this.User);

            if (userId == null)
            {
                userId = currentUserId;
            }

            var viewModel = this.profilesService.GetUserInfoWithFollowed(userId);
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult ProfilePhotoEdit()
        {
            var userId = this.userManager.GetUserId(this.User);
            var currentProfilePhotoUrl = this.profilesService.GetProfilePhotoUrl(userId);
            var viewModel = new NewProfilePhotoInputModel()
            {
                UserId = userId,
                CurrentProfilePhotoUrl = currentProfilePhotoUrl,
            };

            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ProfilePhotoEdit(NewProfilePhotoInputModel input)
        {
            await this.profilesService.ChangeProfilePhoto(input);

            return this.RedirectToAction("Cars", "Profiles", new { userId = input.UserId });
        }

        [Authorize]
        public IActionResult ProfileCoverPhotoEdit()
        {
            var userId = this.userManager.GetUserId(this.User);
            var currentProfileCoverPhotoUrl = this.profilesService.GetCoverPhotoUrl(userId);
            var viewModel = new NewProfilePhotoInputModel()
            {
                UserId = userId,
                CurrentProfilePhotoUrl = currentProfileCoverPhotoUrl,
            };

            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ProfileCoverPhotoEdit(NewProfilePhotoInputModel input)
        {
            await this.profilesService.ChangeCoverPhoto(input);

            return this.RedirectToAction("Cars", "Profiles", new { userId = input.UserId });
        }
    }
}
