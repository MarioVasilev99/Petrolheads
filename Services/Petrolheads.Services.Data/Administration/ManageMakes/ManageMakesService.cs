namespace Petrolheads.Services.Data.Administration.ManageMakes
{
    using Petrolheads.Data.Common.Repositories;
    using Petrolheads.Data.Models;
    using Petrolheads.Services.Mapping;
    using Petrolheads.Web.ViewModels.Administration.ManageMakes;
    using System.Linq;

    public class ManageMakesService : IManageMakesService
    {
        private readonly IDeletableEntityRepository<Make> makesRepository;

        public ManageMakesService(IDeletableEntityRepository<Make> makesRepository)
        {
            this.makesRepository = makesRepository;
        }

        public ManageAllMakesViewModel GetAll()
        {
            var makes = this.makesRepository.All().To<ManageMakeViewModel>().ToList();

            return new ManageAllMakesViewModel()
            {
                Makes = makes,
            };
        }
    }
}
