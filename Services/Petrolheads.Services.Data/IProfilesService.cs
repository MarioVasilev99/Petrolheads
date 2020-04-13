namespace Petrolheads.Services
{
    using System.Collections.Generic;

    public interface IProfilesService
    {
        IEnumerable<T> GetAll<T>();
    }
}
