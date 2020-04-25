namespace Petrolheads.Services.Data.Likes
{
    using System.Threading.Tasks;

    using Petrolheads.Web.ViewModels.Likes;

    public interface ILikesService
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="userId"></param>
        /// <param name="isUpVote">If true - up vote, else - down vote.</param>
        /// <returns></returns>
        Task LikeAsync(int postId, string userId);

        LikeResponseModel GetLikesCount(int postId);
    }
}
