using System;
using System.Collections.Generic;
using System.Text;
using API.Controllers;
using API.Data;
using API.Entities;
using API.EntityDtos;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using NSubstitute.Core.Arguments;
using NSubstitute.ReceivedExtensions;
using Serilog;
using Xunit;

namespace Api.Tests
{
    public class CarControllerTests : IDisposable
    {
        private readonly CarController _controller;
        private readonly ILogger _mockLogger = Substitute.For<ILogger>();
        private readonly DataContext _inMemoryDb;

        public CarControllerTests()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _inMemoryDb = new DataContext(options);
            _controller = new CarController(_mockLogger, _inMemoryDb);
            _inMemoryDb.Database.EnsureCreated();

        }
        
        public void Dispose()
        {
            _inMemoryDb?.Database.EnsureDeleted();
        }
        
        [Fact]
        public async void GetCars_ReturnsCars()
        {
            var car1Id = Guid.NewGuid();
            var car2Id = Guid.NewGuid();
            var car3Guid = Guid.NewGuid();
            
            var carsToAdd = new List<Car>()
            {
                new Car(car1Id, "honda", "civic ex", 2019, Guid.NewGuid()),
                new Car(car2Id, "honda", "civic ex", 2018, Guid.NewGuid()),
                new Car(car3Guid, "honda", "civic lx", 2019, Guid.NewGuid()),
            };

            var expectedDtos = new List<CarDto>()
            {
                new CarDto() {Id = car1Id, Make = "honda", Model = "civic ex", Year = 2019},
                new CarDto() {Id = car2Id, Make = "honda", Model = "civic ex", Year = 2018},
                new CarDto() {Id = car3Guid, Make = "honda", Model = "civic lx", Year = 2019},
            };
            await _inMemoryDb.Cars.AddRangeAsync(carsToAdd);
            await _inMemoryDb.SaveChangesAsync();

            var controllerResult = await _controller.GetCars() as OkObjectResult;

            controllerResult?.Value.Should().BeEquivalentTo(expectedDtos);
        }
        
        [Fact]
        public async void GetCars_DoesNotReturnChildInformation()
        {
            var car1Id = Guid.NewGuid();
            var car2Id = Guid.NewGuid();
            var car3Guid = Guid.NewGuid();
            var car1DetailId = Guid.NewGuid();
            var car1InteriorDetailId = Guid.NewGuid();
            
            var carsToAdd = new List<Car>()
            {
                new Car(car1Id, "honda", "civic ex", 2019, car1DetailId),
                new Car(car2Id, "honda", "civic ex", 2018, Guid.NewGuid()),
                new Car(car3Guid, "honda", "civic lx", 2019, Guid.NewGuid()),
            };

            var detailToAdd = new Detail()
            {
                Id = car1DetailId,
                InteriorDetailId = car1InteriorDetailId
            };

            var interiorDetailToAdd = new InteriorDetail(car1InteriorDetailId, null, null, true);

            var expectedDtos = new List<CarDto>()
            {
                new CarDto() {Id = car1Id, Make = "honda", Model = "civic ex", Year = 2019},
                new CarDto() {Id = car2Id, Make = "honda", Model = "civic ex", Year = 2018},
                new CarDto() {Id = car3Guid, Make = "honda", Model = "civic lx", Year = 2019},
            };
            await _inMemoryDb.Cars.AddRangeAsync(carsToAdd);
            await _inMemoryDb.Details.AddAsync(detailToAdd);
            await _inMemoryDb.InteriorDetails.AddAsync(interiorDetailToAdd);
            await _inMemoryDb.SaveChangesAsync();

            var controllerResult = await _controller.GetCars() as OkObjectResult;

            controllerResult?.Value.Should().BeEquivalentTo(expectedDtos);
        }
        
        [Fact]
        public async void GetCars_Response404WhenNoCars()
        {
            var controllerResult = await _controller.GetCars() as ObjectResult;
            controllerResult?.StatusCode.Should().Be(404);
            controllerResult?.Value.Should().Be("No Cars were found");
            _mockLogger.Received(1).Error(Arg.Any<string>());
        }
        
        
        [Fact]
        public async void GetCar_ReturnsAllData()
        {
            var carId = Guid.NewGuid();
            var carDetailId = Guid.NewGuid();
            var carInteriorDetailId = Guid.NewGuid();
            var carSafetyDetailId = Guid.NewGuid();
            var carEngineDetailId = Guid.NewGuid();
            var carExteriorDetailId = Guid.NewGuid();
            var carImageId = Guid.NewGuid();
            
            
            var carsToAdd = new List<Car>()
            {
                new Car(carId, "honda", "civic ex", 2019, carDetailId),
            };

            var detailToAdd = new Detail()
            {
                Id = carDetailId,
                InteriorDetailId = carInteriorDetailId,
                ExteriorDetailId = carExteriorDetailId,
                EngineDetailId = carEngineDetailId,
                SafetyDetailId = carSafetyDetailId
            };

            var interiorDetailToAdd = new InteriorDetail(carInteriorDetailId, null, "Really good sound trust me", true);
            var exteriorDetailToAdd = new ExteriorDetail(carExteriorDetailId, "Blue", "Very large");
            var safetyDetailToAdd = new SafetyDetail(carSafetyDetailId, 5);
            var engineDetailToAdd = new EngineDetail(carEngineDetailId, 5000, 6, true);
            var carImageToAdd = new CarImage(carImageId, Encoding.UTF8.GetBytes("normal string"), carId);
            
            await _inMemoryDb.Cars.AddRangeAsync(carsToAdd);
            await _inMemoryDb.Details.AddAsync(detailToAdd);
            await _inMemoryDb.InteriorDetails.AddAsync(interiorDetailToAdd);
            await _inMemoryDb.ExteriorDetails.AddAsync(exteriorDetailToAdd);
            await _inMemoryDb.SafetyDetails.AddAsync(safetyDetailToAdd);
            await _inMemoryDb.EngineDetails.AddAsync(engineDetailToAdd);
            await _inMemoryDb.CarImages.AddAsync(carImageToAdd);
            await _inMemoryDb.SaveChangesAsync();

            var controllerResult = await _controller.GetCar(carId) as OkObjectResult;
            var result = controllerResult.Value as CarDto;

            result.CarImages.Should().HaveCount(1);
            result.EngineDetail.HorsePower.Should().Be(5000);
            result.InteriorDetail.SoundSystem.Should().Be("Really good sound trust me");
            result.ExteriorDetail.Color.Should().Be("Blue");
            result.SafetyDetail.Rating.Should().Be(5);
            result.Year.Should().Be(2019);
        }
        
        [Fact]
        public async void GetCar_Response404WhenNoCar()
        {
            var id = Guid.NewGuid();
            var controllerResult = await _controller.GetCar(id) as ObjectResult;
            controllerResult?.StatusCode.Should().Be(404);
            controllerResult?.Value.Should().Be($"No Car with id:{id} found");
            _mockLogger.Received(1);
        }

    }
}