namespace Petrolheads.Web.ViewModels.Profiles
{
    using System.Collections.Generic;

    using Petrolheads.Data.Models;
    using Petrolheads.Services.Mapping;
    using Petrolheads.Web.ViewModels.Follows;

    public class ProfileFollowedViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string ProfilePhotoUrl { get; set; }

        public string CoverPhotoUrl { get; set; }

        public string UserName { get; set; }

        public IEnumerable<FollowedUserViewModel> Following { get; set; }
    }
}
