namespace Petrolheads.Web.ViewModels.Cars
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;
    using Petrolheads.Common;
    using Petrolheads.Data.Models;
    using Petrolheads.Services.Mapping;

    public class CarDetailsEditViewModel : IMapFrom<Car>
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string UserUsername { get; set; }

        public string MainImageUrl { get; set; }

        public string MakeName { get; set; }

        [Required]
        [StringLength(GlobalConstants.CarModelMaxLenght, ErrorMessage = "{0} length can't be more than {1}.")]
        public string Model { get; set; }

        [Required]
        [Range(GlobalConstants.CarYearMinValue, GlobalConstants.CarYearMaxValue, ErrorMessage = "{0} must be between {1} and {2}.")]
        public int Year { get; set; }

        public int Horsepower { get; set; }

        public int Torque { get; set; }

        public int Weight { get; set; }

        public int TopSpeed { get; set; }

        public bool IsEditable { get; set; }

        public IFormFile MainImage { get; set; }
    }
}
