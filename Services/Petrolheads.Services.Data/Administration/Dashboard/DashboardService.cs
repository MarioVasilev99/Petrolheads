namespace Petrolheads.Services.Data.Administration.Dashboard
{
    using Petrolheads.Data.Common.Repositories;
    using Petrolheads.Data.Models;
    using Petrolheads.Web.ViewModels.Administration.Dashboard;
    using System.Linq;

    public class DashboardService : IDashboardService
    {
        private readonly IDeletableEntityRepository<Post> posts;
        private readonly IDeletableEntityRepository<Make> makes;
        private readonly IDeletableEntityRepository<Car> cars;
        private readonly IDeletableEntityRepository<ApplicationUser> users;

        public DashboardService(
            IDeletableEntityRepository<Post> posts,
            IDeletableEntityRepository<Make> makes,
            IDeletableEntityRepository<Car> cars,
            IDeletableEntityRepository<ApplicationUser> users)
        {
            this.posts = posts;
            this.makes = makes;
            this.cars = cars;
            this.users = users;
        }

        public IndexViewModel GetAppInfo()
        {
            return new IndexViewModel()
            {
                PostsCount = this.posts.All().Count(),
                CarsCount = this.cars.All().Count(),
                MakesCount = this.makes.All().Count(),
                UsersCount = this.users.All().Count(),
            };
        }
    }
}
