namespace Petrolheads.Web.ViewModels.Cars
{
    using Petrolheads.Data.Models;
    using Petrolheads.Services.Mapping;

    public class CarDetailsViewModel : IMapFrom<Car>
    {
        public string UserId { get; set; }

        public string UserUsername { get; set; }

        public string MainImageUrl { get; set; }

        public string MakeName { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public int Horsepower { get; set; }

        public int Torque { get; set; }

        public int Weight { get; set; }

        public int TopSpeed { get; set; }

        public bool IsEditable { get; set; }
    }
}
