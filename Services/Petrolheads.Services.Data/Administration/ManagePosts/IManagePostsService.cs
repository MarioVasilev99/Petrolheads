namespace Petrolheads.Services.Data.Administration.ManagePosts
{
    using Petrolheads.Web.ViewModels.Administration.ManagePosts;

    public interface IManagePostsService
    {
        ManageAllPostsViewModel GetAllPosts(int? count);
    }
}
