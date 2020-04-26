namespace Petrolheads.Data.Models
{
    using Petrolheads.Data.Common.Models;

    public class PostImage : BaseDeletableModel<int>
    {
        public int PostId { get; set; }

        public Post Post { get; set; }

        public string ImageUrl { get; set; }
    }
}
