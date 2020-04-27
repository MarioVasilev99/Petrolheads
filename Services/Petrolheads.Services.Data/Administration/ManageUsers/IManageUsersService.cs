namespace Petrolheads.Services.Data.Administration.ManageUsers
{
    using Petrolheads.Web.ViewModels.Administration.ManageUsers;

    public interface IManageUsersService
    {
        ManageUsersAllViewModel GetAll();
    }
}
