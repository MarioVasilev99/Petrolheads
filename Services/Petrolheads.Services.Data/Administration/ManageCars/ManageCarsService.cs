namespace Petrolheads.Services.Data.Administration.ManageCars
{
    using System.Linq;
    using System.Threading.Tasks;
    using Petrolheads.Data.Common.Repositories;
    using Petrolheads.Data.Models;
    using Petrolheads.Services.Mapping;
    using Petrolheads.Web.ViewModels.Administration.ManageCars;

    public class ManageCarsService : IManageCarsService
    {
        private readonly IDeletableEntityRepository<Car> carsRepository;

        public ManageCarsService(IDeletableEntityRepository<Car> carsRepository)
        {
            this.carsRepository = carsRepository;
        }

        public ManageAllCarsViewModel GetAll()
        {
            var cars = this.carsRepository.All().To<ManageCarViewModel>().ToList();

            return new ManageAllCarsViewModel()
            {
                Cars = cars,
            };
        }

        public async Task RemoveCar(int carId)
        {
            var carToRemove = this.carsRepository.All().FirstOrDefault(c => c.Id == carId);

            this.carsRepository.Delete(carToRemove);
            await this.carsRepository.SaveChangesAsync();
        }
    }
}
