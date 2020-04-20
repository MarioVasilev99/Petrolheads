namespace Petrolheads.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Petrolheads.Data.Common.Models;

    public class Post : BaseDeletableModel<int>
    {
        public Post()
        {
            this.Images = new HashSet<PostImage>();
            this.Likes = new HashSet<Like>();
        }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string Description { get; set; }

        public IEnumerable<PostImage> Images { get; set; }

        public IEnumerable<Like> Likes { get; set; }
    }
}
