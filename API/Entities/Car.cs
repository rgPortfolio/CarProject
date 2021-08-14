using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Car
    {
        public Car(Guid id, string make, string model, int year, Guid detailId)
        {
            this.Id = id;
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.DetailId = detailId;

        }
        
        public Guid Id { get; set; }

        [StringLength(60)]
        public string Make { get; set; }

        [StringLength(60)]
        public string Model { get; set; }

        public int Year { get; set; }

        public Guid DetailId { get; set; }

        public virtual Detail Detail { get; set; }

        public virtual List<CarImage> CarImages { get; set;}
    }
}