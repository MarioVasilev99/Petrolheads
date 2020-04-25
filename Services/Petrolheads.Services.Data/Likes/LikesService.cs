namespace Petrolheads.Services.Data.Likes
{
    using System.Linq;
    using System.Threading.Tasks;

    using Petrolheads.Data.Common.Repositories;
    using Petrolheads.Data.Models;
    using Petrolheads.Web.ViewModels.Likes;

    public class LikesService : ILikesService
    {
        private readonly IDeletableEntityRepository<Like> likesRepository;

        public LikesService(IDeletableEntityRepository<Like> likesRepository)
        {
            this.likesRepository = likesRepository;
        }

        public LikeResponseModel GetLikesCount(int postId)
        {
            var likesCount = this.likesRepository
                .All()
                .Where(l => l.PostId == postId && l.Type == LikeType.Like)
                .Count();

            return new LikeResponseModel() { LikesCount = likesCount };
        }

        public async Task LikeAsync(int postId, string userId)
        {
            var like = this.likesRepository
                .All()
                .FirstOrDefault(v => v.UserId == userId && v.PostId == postId);

            if (like != null)
            {
                this.likesRepository.Delete(like);
            }
            else
            {
                like = new Like
                {
                    PostId = postId,
                    UserId = userId,
                    Type = LikeType.Like,
                };

                await this.likesRepository.AddAsync(like);
            }

            await this.likesRepository.SaveChangesAsync();
        }
    }
}
