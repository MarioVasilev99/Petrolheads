namespace Petrolheads.Web.ViewModels.Administration.ManageCars
{
    using Petrolheads.Data.Models;
    using Petrolheads.Services.Mapping;

    public class ManageCarViewModel : IMapFrom<Car>
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string UserUserName { get; set; }

        public string MainImageUrl { get; set; }

        public string MakeName { get; set; }

        public string Model { get; set; }
    }
}