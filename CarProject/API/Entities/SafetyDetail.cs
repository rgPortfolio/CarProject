using System;

namespace API.Entities
{
    public class SafetyDetail
    {
        public SafetyDetail(Guid id, decimal rating)
        {
            Id = id;
            Rating = rating;
        }
        public Guid Id { get; set; }
        public decimal Rating { get; set; }
    }
}