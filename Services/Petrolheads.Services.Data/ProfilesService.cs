namespace Petrolheads.Services
{
    using System.Linq;

    using Petrolheads.Data.Common.Repositories;
    using Petrolheads.Data.Models;
    using Petrolheads.Services.Mapping;
    using Petrolheads.Web.ViewModels.Posts;
    using Petrolheads.Web.ViewModels.Profiles;

    public class ProfilesService : IProfilesService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> users;

        public ProfilesService(IDeletableEntityRepository<ApplicationUser> users)
        {
            this.users = users;
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
    }
}
