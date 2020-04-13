namespace Petrolheads.Services
{
    using Petrolheads.Data.Common.Repositories;
    using Petrolheads.Data.Models;
    using System.Collections.Generic;

    public class ProfilesService : IProfilesService
    {
        public ProfilesService(IDeletableEntityRepository<Car> category)
        {

        }

        public IEnumerable<T> GetAll<T>()
        {
            throw new System.NotImplementedException();
        }
    }
}
