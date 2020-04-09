namespace Petrolheads.Data.Models
{
    using System.Collections.Generic;

    using Petrolheads.Data.Common.Models;

    public class Post : BaseDeletableModel<int>
    {
        public Post()
        {
            this.Images = new HashSet<string>();
        }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string Description { get; set; }

        public IEnumerable<string> Images { get; set; }
    }
}
