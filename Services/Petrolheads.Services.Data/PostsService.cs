namespace Petrolheads.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using Petrolheads.Common.CloudinaryHelper;
    using Petrolheads.Data.Common.Repositories;
    using Petrolheads.Data.Models;
    using Petrolheads.Web.ViewModels.Posts;

    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<Post> posts;
        private readonly Cloudinary cloudinary;

        public PostsService(IDeletableEntityRepository<Post> posts, Cloudinary cloudinary)
        {
            this.posts = posts;
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
    }
}
