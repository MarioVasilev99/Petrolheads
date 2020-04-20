namespace Petrolheads.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Petrolheads.Data.Common.Models;

    public class Like : BaseDeletableModel<int>
    {
        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public LikeType Type { get; set; }
    }
}
