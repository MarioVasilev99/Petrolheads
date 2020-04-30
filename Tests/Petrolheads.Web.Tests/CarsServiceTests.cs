namespace Petrolheads.Web.Tests
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.Extensions.DependencyInjection;
    using Petrolheads.Services.Data.Cars;
    using Petrolheads.Web.ViewModels.Cars;
    using Xunit;

    public class CarsServiceTests : BaseServiceTests
    {
        private ICarsService Service => this.ServiceProvider.GetRequiredService<ICarsService>();

        [Fact]
        public async Task CreateCarShouldAddCarToDb()
        {
            var userId = this.DbContext.Users.Select(u => u.Id).First();
            var makeId = this.DbContext.Makes.Select(m => m.Id).First();
            var inputModel = new AddCarInputModel()
            {
                Horsepower = 100,
                TopSpeed = 100,
                MakeId = makeId,
                Model = "M5",
                Torque = 100,
                Weight = 100,
                Year = 2010,
            };

            await this.Service.CreateCar(userId, inputModel);
            var expectedCarsCount = 2;

            var actualCarsCount = this.DbContext.Cars.Count();

            Assert.Equal(expectedCarsCount, actualCarsCount);
        }
    }
}
