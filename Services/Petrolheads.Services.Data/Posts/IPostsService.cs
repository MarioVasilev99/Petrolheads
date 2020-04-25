namespace Petrolheads.Services.Data.Posts
{
    using System.Threading.Tasks;

    using Petrolheads.Web.ViewModels.Posts;

    public interface IPostsService
    {
        Task<int> CreatePost(string userId, CreatePostInputModel input);

        AllPostsViewModel GetAll(int? count);
    }
}
