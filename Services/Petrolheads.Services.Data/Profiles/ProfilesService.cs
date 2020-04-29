namespace Petrolheads.Services.Data.Profiles
{
    using System.Linq;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using Petrolheads.Common.CloudinaryHelper;
    using Petrolheads.Data.Common.Repositories;
    using Petrolheads.Data.Models;
    using Petrolheads.Services.Mapping;
    using Petrolheads.Web.ViewModels.Profiles;

    public class ProfilesService : IProfilesService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> users;
        private readonly Cloudinary cloudinary;

        public ProfilesService(
            IDeletableEntityRepository<ApplicationUser> users,
            Cloudinary cloudinary)
        {
            this.users = users;
            this.cloudinary = cloudinary;
        }

        public ProfileCarsViewModel GetUserInfoWithCars(string userId)
        {
            var profileCarsViewModel = this.users.All()
                .Where(u => u.Id == userId)
                .To<ProfileCarsViewModel>()
                .FirstOrDefault();

            return profileCarsViewModel;
        }

        public ProfilePostsViewModel GetUserInfoWithPosts(string userId)
        {
            var profilePostsViewModel = this.users.All()
                .Where(u => u.Id == userId)
                .To<ProfilePostsViewModel>()
                .FirstOrDefault();

            return profilePostsViewModel;
        }

        public ProfileFollowedViewModel GetUserInfoWithFollowed(string userId)
        {
            var profileFollowedViewModel = this.users.All()
                .Where(u => u.Id == userId)
                .To<ProfileFollowedViewModel>()
                .FirstOrDefault();

            return profileFollowedViewModel;
        }

        public async Task ChangeProfilePhoto(NewProfilePhotoInputModel input)
        {
            if (input.ProfilePhoto != null)
            {
                var user = this.users.All().FirstOrDefault(u => u.Id == input.UserId);
                var newProfilePhotoUrl = await CloudinaryExtension.UploadFileAsync(this.cloudinary, input.ProfilePhoto);
                user.ProfilePhotoUrl = newProfilePhotoUrl;
                await this.users.SaveChangesAsync();
            }
        }

        public string GetProfilePhotoUrl(string userId)
        {
            return this.users.All()
                .Where(u => u.Id == userId)
                .Select(u => u.ProfilePhotoUrl)
                .FirstOrDefault();
        }

        public async Task ChangeCoverPhoto(NewProfilePhotoInputModel input)
        {
            if (input.ProfilePhoto != null)
            {
                var user = this.users.All().FirstOrDefault(u => u.Id == input.UserId);
                var newCoverPhotoUrl = await CloudinaryExtension.UploadFileAsync(this.cloudinary, input.ProfilePhoto);
                user.CoverPhotoUrl = newCoverPhotoUrl;
                await this.users.SaveChangesAsync();
            }
        }

        public string GetCoverPhotoUrl(string userId)
        {
            return this.users.All()
                .Where(u => u.Id == userId)
                .Select(u => u.CoverPhotoUrl)
                .FirstOrDefault();
        }
    }
}
