namespace Petrolheads.Web.ViewModels.Profiles
{
    using Microsoft.AspNetCore.Http;

    public class NewProfilePhotoInputModel
    {
        public string UserId { get; set; }

        public string CurrentProfilePhotoUrl { get; set; }

        public IFormFile ProfilePhoto { get; set; }
    }
}
