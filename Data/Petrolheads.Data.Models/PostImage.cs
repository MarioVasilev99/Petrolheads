namespace Petrolheads.Data.Models
{
    using Petrolheads.Data.Common.Models;

    public class PostImage : BaseDeletableModel<int>
    {
        public string ImageUrl { get; set; }
    }
}
