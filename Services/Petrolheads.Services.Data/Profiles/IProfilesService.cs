namespace Petrolheads.Services.Data.Profiles
{
    using Petrolheads.Web.ViewModels.Profiles;

    public interface IProfilesService
    {
        ProfileCarsViewModel GetUserInfoWithCars(string userId);

        ProfilePostsViewModel GetUserInfoWithPosts(string userId);
    }
}
