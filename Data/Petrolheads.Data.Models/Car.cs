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
        }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int MakeId { get; set; }

        public Make Make { get; set; }

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
