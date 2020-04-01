namespace Petrolheads.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Petrolheads.Data.Common.Models;

    public class CarPhoto : BaseDeletableModel<int>
    {
        public int CarId { get; set; }

        public virtual Car Car { get; set; }

        [Required]
        public string Url { get; set; }
    }
}
