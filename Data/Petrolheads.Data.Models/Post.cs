namespace Petrolheads.Data.Models
{
    using Petrolheads.Data.Common.Models;

    public class Post : BaseDeletableModel<int>
    {
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string Description { get; set; }
    }
}
