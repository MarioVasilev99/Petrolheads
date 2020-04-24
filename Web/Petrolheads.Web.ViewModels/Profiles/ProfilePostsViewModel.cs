namespace Petrolheads.Web.ViewModels.Profiles
{
    using System.Collections.Generic;

    using Petrolheads.Data.Models;
    using Petrolheads.Services.Mapping;
    using Petrolheads.Web.ViewModels.Posts;

    public class ProfilePostsViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string ProfilePhotoUrl { get; set; }

        public string CoverPhotoUrl { get; set; }

        public string UserName { get; set; }

        public IEnumerable<PostViewModel> Posts { get; set; }

        public bool IsProfileOwner { get; set; }
    }
}
