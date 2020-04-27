namespace Petrolheads.Web.ViewModels.Administration.ManageCars
{
    using System.Collections.Generic;

    using Petrolheads.Data.Models;
    using Petrolheads.Services.Mapping;

    public class ManageAllCarsViewModel : IMapFrom<Car>
    {
        public IEnumerable<ManageCarViewModel> Cars { get; set; }
    }
}
