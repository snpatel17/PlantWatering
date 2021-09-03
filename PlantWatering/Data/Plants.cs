using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlantWatering.Data
{
    public class Plants
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Plant Name is required")]
        public string PlantName { get; set; }

        public DateTime StartTime { get; set; }

        public int WaterStatus { get; set; }
    }
}
