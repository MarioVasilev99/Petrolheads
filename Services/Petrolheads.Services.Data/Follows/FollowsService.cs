namespace Petrolheads.Services.Data.Follows
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Petrolheads.Data.Common.Repositories;
    using Petrolheads.Data.Models;
    using Petrolheads.Data.Models.Enums;
    using Petrolheads.Web.ViewModels.Follows;

    public class FollowsService : IFollowsService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly IDeletableEntityRepository<Follower> followersRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public FollowsService(
            IDeletableEntityRepository<ApplicationUser> usersRepository,
            IDeletableEntityRepository<Follower> followersRepository,
            UserManager<ApplicationUser> userManager)
        {
            this.usersRepository = usersRepository;
            this.followersRepository = followersRepository;
            this.userManager = userManager;
        }

        public async Task<FollowResponseModel> FollowUserAsync(string currentUserId, string userToFollowId)
        {
            var userToFollow = await this.userManager.FindByIdAsync(userToFollowId);
            var existingFollow = this.followersRepository
                .All()
                .FirstOrDefault(f => f.UserId == userToFollowId && f.FollowedById == currentUserId);
            if (existingFollow != null)
            {
                this.followersRepository.Delete(existingFollow);
                await this.followersRepository.SaveChangesAsync();
            }
            else
            {
                var newFollow = new Follower()
                {
                    FollowerType = FollowerTypeEnum.Following,
                    User = userToFollow,
                    FollowedById = currentUserId,
                };

                await this.followersRepository.AddAsync(newFollow);
                await this.followersRepository.SaveChangesAsync();
            }


            return new FollowResponseModel() { Success = true };
        }

        public bool IsFollowed(string queryUserId, string currentUserId)
        {
            return this.followersRepository.All()
                .Any(f => f.UserId == queryUserId && f.FollowedById == currentUserId);
        }

        public async Task UnfollowUserAsync(string userId, string followedUserId)
        {
            var follow = this.followersRepository.All().FirstOrDefault(f => f.UserId == followedUserId && f.FollowedById == userId);
            this.followersRepository.Delete(follow);
            await this.followersRepository.SaveChangesAsync();
        }
    }
}
