namespace Petrolheads.Web.ViewModels.Profiles
{
    using System;

    using Petrolheads.Data.Models;
    using Petrolheads.Services.Mapping;

    public class CarViewModel : IMapFrom<Car>
    {
        public string MainImageUrl { get; set; }

        public string MakeName { get; set; }

        public string Model { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}