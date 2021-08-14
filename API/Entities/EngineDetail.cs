using System;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class EngineDetail
    {
        public EngineDetail(Guid id, int horsePower, decimal liters, bool turbo)
        {
            this.Id = id;
            this.HorsePower = horsePower;
            this.Liters = liters;
            this.Turbo = turbo;

        }
        public Guid Id { get; set; }

        public int HorsePower { get; set; }

        public decimal Liters { get; set; }

        public bool Turbo { get; set; }
    }
}