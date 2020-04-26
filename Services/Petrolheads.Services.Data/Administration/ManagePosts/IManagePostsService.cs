namespace Petrolheads.Services.Data.Administration.ManagePosts
{
    using System.Threading.Tasks;

    using Petrolheads.Web.ViewModels.Administration.ManagePosts;

    public interface IManagePostsService
    {
        ManageAllPostsViewModel GetAllPosts(int? count);

        Task DeletePost(int postId);
    }
}
