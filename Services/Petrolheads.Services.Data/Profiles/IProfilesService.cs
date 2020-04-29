namespace Petrolheads.Services.Data.Profiles
{
    using System.Threading.Tasks;

    using Petrolheads.Web.ViewModels.Profiles;

    public interface IProfilesService
    {
        ProfileCarsViewModel GetUserInfoWithCars(string userId);

        ProfilePostsViewModel GetUserInfoWithPosts(string userId);

        ProfileFollowedViewModel GetUserInfoWithFollowed(string userId);

        string GetProfilePhotoUrl(string userId);

        Task ChangeProfilePhoto(NewProfilePhotoInputModel input);

        string GetCoverPhotoUrl(string userId);

        Task ChangeCoverPhoto(NewProfilePhotoInputModel input);
    }
}
