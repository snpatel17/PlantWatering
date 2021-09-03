using System;
using System.ComponentModel.DataAnnotations;

namespace PlantWatering.Models
{
    public class PlantModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Plant Name is required")]
        public string PlantName { get; set; }

        public DateTime StartTime { get; set; }

        public int WaterStatus { get; set; }

    }
}
