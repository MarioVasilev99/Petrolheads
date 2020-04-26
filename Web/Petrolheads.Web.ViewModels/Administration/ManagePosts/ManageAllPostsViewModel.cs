namespace Petrolheads.Web.ViewModels.Administration.ManagePosts
{
    using Petrolheads.Data.Models;
    using Petrolheads.Services.Mapping;
    using System.Collections.Generic;

    public class ManageAllPostsViewModel : IMapFrom<Post>
    {
        public IEnumerable<PostManageViewModel> Posts { get; set; }
    }
}
