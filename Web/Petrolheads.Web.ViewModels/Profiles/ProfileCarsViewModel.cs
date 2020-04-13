namespace Petrolheads.Web.ViewModels.Profiles
{
    using System.Collections.Generic;

    public class ProfileCarsViewModel
    {
        public string UserProfileImageUrl { get; set; }

        public string UserCoverImageUrl { get; set; }

        public string UserName { get; set; }

        public IEnumerable<CarViewModel> Cars { get; set; }
    }
}
