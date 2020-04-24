namespace Petrolheads.Web.ViewModels.Cars
{
    using Petrolheads.Data.Models;
    using Petrolheads.Services.Mapping;

    public class MakeViewModel : IMapFrom<Make>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
