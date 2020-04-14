namespace Petrolheads.Services.Data
{
    using Petrolheads.Web.ViewModels.Posts;
    using System.Threading.Tasks;

    public interface IPostsService
    {
        Task<int> CreatePost(string userId, CreatePostInputModel input);
    }
}
