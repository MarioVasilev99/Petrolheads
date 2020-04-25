namespace Petrolheads.Services.Data.Cars
{
    using System.Threading.Tasks;

    using Petrolheads.Web.ViewModels.Cars;

    public interface ICarsService
    {
        Task<int> CreateCar(string userId, AddCarInputModel input);

        CarDetailsViewModel GetCarDetails(int carId);

        CarDetailsEditViewModel GetCarEditDetails(int carId);

        Task DeleteCar(string userId, int carId);

        Task EditCar(CarDetailsEditViewModel input);
    }
}
