namespace Petrolheads.Web.ViewModels.Follows
{
    using Petrolheads.Data.Models;
    using Petrolheads.Services.Mapping;

    public class FollowedUserViewModel : IMapFrom<Follower>
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string UserProfilePhotoUrl { get; set; }

        public string UserUserName { get; set; }
    }
}
