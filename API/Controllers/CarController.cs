using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.EntityDtos;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly DataContext _db;

        public CarController(ILogger logger, DataContext db)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        /// <summary>
        /// Gets all the cars make model and year
        /// </summary>
        /// <returns>List of CarDto</returns>
        public async Task<IActionResult> GetCars(){
            //we could use Automapper here to handle conversions automatically
            var cars = await _db.Cars.Select(x =>
                new CarDto(){
                    Id = x.Id,
                    Make = x.Make,
                    Model = x.Model,
                    Year = x.Year
                }).AsNoTracking().ToListAsync();

            if (!cars.Any())
            {
                _logger.Error("No cards were found");
                return StatusCode(404, "No Cars were found");
            }

            return Ok(cars);
        }


        [HttpGet("{id:guid}")]
        /// <summary>
        /// Gets a single cars information including details and photos
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A single Car dto</returns>
        public async Task<IActionResult> GetCar(Guid id){
            var car = await _db.Cars.Include(x => x.Id == id)
                                .Include(x => x.Detail)
                                .ThenInclude(y => y.EngineDetail)
                                .Include(x => x.Detail)
                                .ThenInclude(y => y.InteriorDetail)
                                .Include(x => x.Detail)
                                .ThenInclude(y => y.ExteriorDetail)
                                .Include(x => x.Detail)
                                .ThenInclude(y => y.SafetyDetail)
                                .Include(x => x.CarImages)
                                .AsNoTracking().FirstOrDefaultAsync();

            if (car == null)
            {
                _logger.Error("No car with  id:{Id} found", id);
                return StatusCode(404, $"No Car with id:{id} found");
            }

            var engineDetailDto = new EngineDetailDto(){
                HorsePower = car.Detail.EngineDetail?.HorsePower,
                Turbo = car.Detail.EngineDetail?.Turbo,
                Liters = car.Detail.EngineDetail?.Liters
            };

            var safetyDetailDto = new SafetyDetailDto(){
                Rating = car.Detail.SafetyDetail?.Rating
            };

            var interiorDetailDto = new InteriorDetailDto(){
                Upholstery = car.Detail.InteriorDetail?.Upholstery,
                SoundSystem = car.Detail.InteriorDetail?.SoundSystem,
                HasAndroidAutoOrCarPlay = car.Detail.InteriorDetail?.HasAndroidAutoOrCarPlay
            };

            var exteriorDetailDto = new ExteriorDetailDto(){
                Color = car.Detail.ExteriorDetail?.Color,
                Rims = car.Detail.ExteriorDetail?.Rims,
            };

            var carImagesDto = new List<CarImageDto>(){};
            foreach (var image in car.CarImages)
            {
                string imageBase64Data = Convert.ToBase64String(image.ImageData);
                string imageDataURL = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
                carImagesDto.Add(new CarImageDto() {Id = image.Id, ImageDataUrl = imageDataURL});
            }

            var carDto = new CarDto() {
                Id = car.Id,
                Make = car.Make,
                Model = car.Model,
                Year = car.Year,
                EngineDetail = engineDetailDto,
                InteriorDetail = interiorDetailDto,
                SafetyDetail = safetyDetailDto,
                ExteriorDetail = exteriorDetailDto  
            };

            return Ok(carDto);

        }
    }
}