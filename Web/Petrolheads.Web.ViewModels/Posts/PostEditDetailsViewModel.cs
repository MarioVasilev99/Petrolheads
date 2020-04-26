namespace Petrolheads.Web.ViewModels.Posts
{
    using System.Collections.Generic;

    using Petrolheads.Data.Models;
    using Petrolheads.Services.Mapping;

    public class PostEditDetailsViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }

        public bool IsAdminArea { get; set; }

        public IEnumerable<PostImageViewModel> Images { get; set; }
    }
}
