namespace Petrolheads.Services.Data.Administration.ManageCars
{
    using System.Threading.Tasks;

    using Petrolheads.Web.ViewModels.Administration.ManageCars;

    public interface IManageCarsService
    {
        ManageAllCarsViewModel GetAll();

        Task RemoveCar(int carId);
    }
}
