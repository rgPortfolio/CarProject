using System;

namespace API.Entities
{
    public class SafetyDetail
    {
        public SafetyDetail(Guid id)
        {
            this.Id = id;

        }
        public Guid Id { get; set; }
        public decimal Rating { get; set; }
    }
}