namespace Petrolheads.Web.ViewModels.Administration.ManageMakes
{
    using System.Collections.Generic;

    using Petrolheads.Data.Models;
    using Petrolheads.Services.Mapping;

    public class ManageAllMakesViewModel : IMapFrom<Make>
    {
        public IEnumerable<ManageMakeViewModel> Makes { get; set; }
    }
}
