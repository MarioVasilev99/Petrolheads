namespace Petrolheads.Services
{
    using Petrolheads.Web.ViewModels.Profiles;

    public interface IProfilesService
    {
        ProfileCarsViewModel GetUserInfoWithCars(string userId);
    }
}
