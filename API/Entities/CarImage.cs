using System;

namespace API.Entities
{
    public class CarImage
    {
        public CarImage(byte[] imageData)
        {
            ImageData = imageData;
        }

        public Guid Id { get; set;}
        public byte[] ImageData { get; set; }
        public Guid CarId { get; set;}
    }
}