namespace Petrolheads.Web.ViewModels.Profiles
{
    using System.Collections.Generic;

    using Petrolheads.Data.Models;
    using Petrolheads.Services.Mapping;

    public class ProfileCarsViewModel : IMapFrom<ApplicationUser>
    {
        public string ProfilePhotoUrl { get; set; }

        public string CoverPhotoUrl { get; set; }

        public string UserName { get; set; }

        public IEnumerable<CarViewModel> Cars { get; set; }
    }
}
