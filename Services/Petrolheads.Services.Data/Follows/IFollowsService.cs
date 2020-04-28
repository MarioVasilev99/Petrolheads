namespace Petrolheads.Services.Data.Follows
{
    using System.Threading.Tasks;

    using Petrolheads.Web.ViewModels.Follows;

    public interface IFollowsService
    {
        Task<FollowResponseModel> FollowUserAsync(string currentUserId, string userToFollowId);

        public bool IsFollowed(string queryUserId, string currentUserId);


    }
}
