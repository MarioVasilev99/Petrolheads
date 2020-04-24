namespace Petrolheads.Web.ViewModels.Cars
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Petrolheads.Common;

    public class AddCarInputModel
    {
        [Required]
        public int MakeId { get; set; }

        [Required]
        [StringLength(GlobalConstants.CarModelMaxLenght, ErrorMessage = "{0} length can't be more than {1}.")]
        public string Model { get; set; }

        [Required]
        [Range(GlobalConstants.CarYearMinValue, GlobalConstants.CarYearMaxValue, ErrorMessage = "{0} must be between {1} and {2}.")]
        public int Year { get; set; }

        public int Horsepower { get; set; }

        public int Torque { get; set; }

        public int? Weight { get; set; }

        public int? TopSpeed { get; set; }

        public IFormFile MainImage { get; set; }

        public SelectList Makes { get; set; }
    }
}
