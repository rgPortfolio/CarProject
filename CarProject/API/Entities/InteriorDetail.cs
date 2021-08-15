using System;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class InteriorDetail
    {
        public InteriorDetail(Guid id, string upholstery, string soundSystem, bool hasAndroidAutoOrCarPlay)
        {
            Id = id;
            Upholstery = upholstery;
            SoundSystem = soundSystem;
            HasAndroidAutoOrCarPlay = hasAndroidAutoOrCarPlay;

        }
        public Guid Id { get; set; }

        [StringLength(60)]
        public string Upholstery { get; set; }

        [StringLength(60)]
        public string SoundSystem { get; set; }

        public bool HasAndroidAutoOrCarPlay { get; set; }
    }
}