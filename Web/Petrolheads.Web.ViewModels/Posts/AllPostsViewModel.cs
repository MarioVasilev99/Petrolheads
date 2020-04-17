namespace Petrolheads.Web.ViewModels.Posts
{
    using System.Collections.Generic;

    using Petrolheads.Data.Models;
    using Petrolheads.Services.Mapping;

    public class AllPostsViewModel : IMapFrom<Post>
    {
        public IEnumerable<PostViewModel> Posts { get; set; }
    }
}
