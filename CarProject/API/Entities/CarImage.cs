using System;

namespace API.Entities
{
    public class CarImage
    {
        public CarImage(Guid id, byte[] imageData, Guid carId)
        {
            Id = id;
            ImageData = imageData;
            CarId = carId;
        }

        public Guid Id { get; set;}
        public byte[] ImageData { get; set; }
        public Guid CarId { get; set;}
    }
}