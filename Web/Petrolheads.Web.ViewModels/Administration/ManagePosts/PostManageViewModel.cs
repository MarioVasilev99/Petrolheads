namespace Petrolheads.Web.ViewModels.Administration.ManagePosts
{
    using Petrolheads.Data.Models;
    using Petrolheads.Services.Mapping;

    public class PostManageViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        public string UserUserName { get; set; }

        public string Description { get; set; }

        public int LikesCount { get; set; }
    }
}
