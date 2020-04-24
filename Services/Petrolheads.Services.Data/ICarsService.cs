﻿namespace Petrolheads.Services.Data
{
    using System.Threading.Tasks;

    using Petrolheads.Web.ViewModels.Cars;

    public interface ICarsService
    {
        Task<int> CreateCar(string userId, AddCarInputModel input);

        CarDetailsViewModel GetCarDetails(int carId);
    }
}