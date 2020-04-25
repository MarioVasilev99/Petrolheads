namespace Petrolheads.Services.Data.Makes
{
    using System.Collections.Generic;
    using System.Linq;

    using Petrolheads.Data.Common.Repositories;
    using Petrolheads.Data.Models;
    using Petrolheads.Services.Mapping;
    using Petrolheads.Web.ViewModels.Cars;

    public class MakesService : IMakesService
    {
        private readonly IDeletableEntityRepository<Make> makesRepository;

        public MakesService(IDeletableEntityRepository<Make> makesRepository)
        {
            this.makesRepository = makesRepository;
        }

        public IEnumerable<MakeViewModel> GetAll()
        {
            return this.makesRepository
                .All()
                .To<MakeViewModel>()
                .OrderBy(m => m.Name)
                .ToList();
        }
    }
}
