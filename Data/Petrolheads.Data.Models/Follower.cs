namespace Petrolheads.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Petrolheads.Data.Common.Models;
    using Petrolheads.Data.Models.Enums;

    public class Follower : BaseDeletableModel<int>
    {
        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public string FollowedById { get; set; }

        public virtual ApplicationUser FollowedBy { get; set; }

        public FollowerTypeEnum FollowerType { get; set; }
    }
}
