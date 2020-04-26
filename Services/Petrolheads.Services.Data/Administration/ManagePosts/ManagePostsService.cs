namespace Petrolheads.Services.Data.Administration.ManagePosts
{
    using System.Linq;

    using Petrolheads.Data.Common.Repositories;
    using Petrolheads.Data.Models;
    using Petrolheads.Services.Mapping;
    using Petrolheads.Web.ViewModels.Administration.ManagePosts;

    public class ManagePostsService : IManagePostsService
    {
        private readonly IDeletableEntityRepository<Post> postsRepository;

        public ManagePostsService(IDeletableEntityRepository<Post> postsRepository)
        {
            this.postsRepository = postsRepository;
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
