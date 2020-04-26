namespace Petrolheads.Services.Data.Administration.ManagePosts
{
    using System.Linq;
    using System.Threading.Tasks;
    using Petrolheads.Data.Common.Repositories;
    using Petrolheads.Data.Models;
    using Petrolheads.Services.Data.Posts;
    using Petrolheads.Services.Mapping;
    using Petrolheads.Web.ViewModels.Administration.ManagePosts;

    public class ManagePostsService : IManagePostsService
    {
        private readonly IDeletableEntityRepository<Post> postsRepository;
        private readonly IPostsService postsService;

        public ManagePostsService(IDeletableEntityRepository<Post> postsRepository)
        {
            this.postsRepository = postsRepository;
        }

        public async Task DeletePost(int postId)
        {
            var postToDelete = this.postsRepository.All().FirstOrDefault(p => p.Id == postId);
            this.postsRepository.Delete(postToDelete);
            await this.postsRepository.SaveChangesAsync();
        }

        public ManageAllPostsViewModel GetAllPosts(int? count)
        {
            IQueryable<Post> posts = this.postsRepository.All().OrderByDescending(p => p.CreatedOn);

            if (count.HasValue)
            {
                posts = posts.Take(count.Value);
            }

            var allPosts = posts.To<PostManageViewModel>().ToList();

            return new ManageAllPostsViewModel()
            {
                Posts = allPosts,
            };
        }
    }
}
