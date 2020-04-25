namespace Petrolheads.Services.Data.Cars
{
    using System.Linq;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using Petrolheads.Common.CloudinaryHelper;
    using Petrolheads.Data.Common.Repositories;
    using Petrolheads.Data.Models;
    using Petrolheads.Services.Mapping;
    using Petrolheads.Web.ViewModels.Cars;

    public class CarsService : ICarsService
    {
        private readonly IDeletableEntityRepository<Car> carRepository;
        private readonly Cloudinary cloudinary;

        public CarsService(IDeletableEntityRepository<Car> carRepository, Cloudinary cloudinary)
        {
            this.carRepository = carRepository;
            this.cloudinary = cloudinary;
        }

        public async Task<int> CreateCar(string userId, AddCarInputModel input)
        {
            var newCar = new Car()
            {
                UserId = userId,
                MakeId = input.MakeId,
                Model = input.Model,
                TopSpeed = input.TopSpeed,
                Weight = input.Weight,
                Horsepower = input.Horsepower,
                Year = input.Year,
                Torque = input.Torque,
            };

            if (input.MainImage != null)
            {
                var carMainImageUrl = await CloudinaryExtension.UploadFileAsync(this.cloudinary, input.MainImage);
                newCar.MainImageUrl = carMainImageUrl;
            }

            await this.carRepository.AddAsync(newCar);
            await this.carRepository.SaveChangesAsync();

            return newCar.Id;
        }

        public async Task DeleteCar(string userId, int carId)
        {
            var carToDelete = this.carRepository
                .All()
                .FirstOrDefault(c => c.UserId == userId && c.Id == carId);

            this.carRepository.Delete(carToDelete);
            await this.carRepository.SaveChangesAsync();
        }

        public async Task EditCar(CarDetailsEditViewModel input)
        {
            var carToEdit = this.carRepository
                .All()
                .FirstOrDefault(c => c.Id == input.Id);

            if (input.MainImage != null)
            {
                var carMainImageUrl = await CloudinaryExtension.UploadFileAsync(this.cloudinary, input.MainImage);
                carToEdit.MainImageUrl = carMainImageUrl;
            }

            carToEdit.Model = input.Model;
            carToEdit.Year = input.Year;
            carToEdit.Horsepower = input.Horsepower;
            carToEdit.Torque = input.Torque;
            carToEdit.Weight = input.Weight;
            carToEdit.TopSpeed = input.TopSpeed;

            await this.carRepository.SaveChangesAsync();
        }

        public CarDetailsViewModel GetCarDetails(int carId)
        {
            return this.carRepository
                .All()
                .Where(c => c.Id == carId)
                .To<CarDetailsViewModel>()
                .FirstOrDefault();
        }

        public CarDetailsEditViewModel GetCarEditDetails(int carId)
        {
            return this.carRepository
                .All()
                .Where(c => c.Id == carId)
                .To<CarDetailsEditViewModel>()
                .FirstOrDefault();
        }
    }
}
