using System;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class ExteriorDetail
    {
        public ExteriorDetail(Guid id, string color, string rims)
        {
            Id = id;
            Color = color;
            Rims = rims;

        }
        public Guid Id { get; set; }

        [StringLength(60)]
        public string Color { get; set; }

        [StringLength(60)]
        public string Rims { get; set; }
    }
}