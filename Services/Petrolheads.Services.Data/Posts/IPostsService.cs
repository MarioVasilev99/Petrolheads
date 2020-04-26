namespace Petrolheads.Services.Data.Posts
{
    using System.Threading.Tasks;

    using Petrolheads.Web.ViewModels.Posts;

    public interface IPostsService
    {
        Task<int> CreatePost(string userId, CreatePostInputModel input);

        AllPostsViewModel GetAll(int? count);

        PostEditDetailsViewModel GetPostEditDetails(string userId, int postId);

        Task EditPost(string userId, EditPostInputModel input);

        Task DeletePost(string userId, int postId);
    }
}
