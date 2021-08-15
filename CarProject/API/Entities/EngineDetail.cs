using System;

namespace API.Entities
{
    public class EngineDetail
    {
        public EngineDetail(Guid id, int horsePower, decimal liters, bool turbo)
        {
            Id = id;
            HorsePower = horsePower;
            Liters = liters;
            Turbo = turbo;

        }
        public Guid Id { get; set; }

        public int HorsePower { get; set; }

        public decimal Liters { get; set; }

        public bool Turbo { get; set; }
    }
}