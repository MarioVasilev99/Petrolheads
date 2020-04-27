namespace Petrolheads.Services.Data.Administration.ManageMakes
{
    using Petrolheads.Web.ViewModels.Administration.ManageMakes;

    public interface IManageMakesService
    {
        ManageAllMakesViewModel GetAll();
    }
}
