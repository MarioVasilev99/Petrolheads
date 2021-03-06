﻿namespace Petrolheads.Web.ViewModels.Profiles
{
    using System.Collections.Generic;

    using Petrolheads.Data.Models;
    using Petrolheads.Services.Mapping;

    public class ProfileCarsViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string ProfilePhotoUrl { get; set; }

        public string CoverPhotoUrl { get; set; }

        public string UserName { get; set; }

        public bool IsProfileOwner { get; set; }

        public bool IsFollowed { get; set; }

        public string FollowButtonText => this.IsFollowed ? "Unfollow" : "Follow";

        public string FollowButtonColorClass => this.IsFollowed ? "btn-danger" : "btn-primary";

        public IEnumerable<CarViewModel> Cars { get; set; }
    }
}
