namespace Petrolheads.Services.Data.Posts
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using Petrolheads.Common.CloudinaryHelper;
    using Petrolheads.Data.Common.Repositories;
    using Petrolheads.Data.Models;
    using Petrolheads.Services.Mapping;
    using Petrolheads.Web.ViewModels.Posts;

    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<Post> posts;
        private readonly IDeletableEntityRepository<PostImage> postImages;
        private readonly Cloudinary cloudinary;

        public PostsService(
            IDeletableEntityRepository<Post> posts,
            IDeletableEntityRepository<PostImage> postImages,
            Cloudinary cloudinary)
        {
            this.posts = posts;
            this.postImages = postImages;
            this.cloudinary = cloudinary;
        }

        public async Task<int> CreatePost(string userId, CreatePostInputModel input)
        {
            var postImages = new List<PostImage>();

            if (input.Images != null)
            {
                var postImagesUrls = await CloudinaryExtension.UploadAsync(this.cloudinary, input.Images);
                foreach (var url in postImagesUrls)
                {
                    postImages.Add(new PostImage() { ImageUrl = url });
                }
            }

            var newPost = new Post()
            {
                Images = postImages,
                UserId = userId,
                Description = input.Description,
            };

            await this.posts.AddAsync(newPost);
            await this.posts.SaveChangesAsync();
            return newPost.Id;
        }

        public async Task DeletePost(string userId, int postId)
        {
            var postToDelete = this.posts
                .All()
                .FirstOrDefault(p => p.Id == postId && p.UserId == userId);

            this.posts.Delete(postToDelete);
            await this.posts.SaveChangesAsync();
        }

        public async Task EditPost(string userId, EditPostInputModel input)
        {
            var postToEdit = this.posts
                .All()
                .FirstOrDefault(p => p.Id == input.Id);

            var postImageUrls = new List<string>();
            if (input.Images != null)
            {
                var postImagesUrls = await CloudinaryExtension.UploadAsync(this.cloudinary, input.Images);
                foreach (var url in postImagesUrls)
                {
                    postImageUrls.Add(url);
                }

                var postImage = this.postImages.All().FirstOrDefault(p => p.PostId == postToEdit.Id);
                postImage.ImageUrl = postImageUrls[0];
            }

            postToEdit.Description = input.Description;
            await this.posts.SaveChangesAsync();
        }

        public AllPostsViewModel GetAll(int? count = null)
        {
            IQueryable<Post> posts = this.posts.All().OrderByDescending(p => p.CreatedOn);

            if (count.HasValue)
            {
                posts = posts.Take(count.Value);
            }

            var allPosts = posts.To<PostViewModel>().ToList();

            return new AllPostsViewModel()
            {
                Posts = allPosts,
            };
        }

        public PostEditDetailsViewModel GetPostEditDetails(string userId, int postId)
        {
            return this.posts
                .All()
                .Where(p => p.Id == postId && p.UserId == userId)
                .To<PostEditDetailsViewModel>()
                .FirstOrDefault();
        }
    }
}
