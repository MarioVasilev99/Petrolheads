namespace Petrolheads.Web.ViewModels.Administration.ManageMakes
{
    using Petrolheads.Data.Models;
    using Petrolheads.Services.Mapping;

    public class ManageMakeViewModel : IMapFrom<Make>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}