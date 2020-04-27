namespace Petrolheads.Services.Data.Administration.ManageUsers
{
    using Petrolheads.Data.Common.Repositories;
    using Petrolheads.Data.Models;
    using Petrolheads.Services.Mapping;
    using Petrolheads.Web.ViewModels.Administration.ManageUsers;
    using System.Linq;

    public class ManageUsersService : IManageUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public ManageUsersService(IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public ManageUsersAllViewModel GetAll()
        {
            var users = this.usersRepository
                .All()
                .To<ManageUsersUserViewModel>()
                .ToList();

            return new ManageUsersAllViewModel()
            {
                Users = users,
            };
        }
    }
}
