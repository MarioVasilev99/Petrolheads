namespace Petrolheads.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Petrolheads.Data.Common.Models;

    public class Car : BaseDeletableModel<int>
    {
        public Car()
        {
            this.Photos = new HashSet<CarPhoto>();
            this.MainImageUrl = "https://res.cloudinary.com/dnzfktppn/image/upload/c_fill,h_230,w_350/v1587844592/no-car-image_zozssn.png";
        }

        public string MainImageUrl { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public int MakeId { get; set; }

        public virtual Make Make { get; set; }

        [Required]
        public string Model { get; set; }

        public int Year { get; set; }

        public int? Horsepower { get; set; }

        public int? Torque { get; set; }

        public int? Weight { get; set; }

        public int? TopSpeed { get; set; }

        public virtual IEnumerable<CarPhoto> Photos { get; set; }
    }
}
