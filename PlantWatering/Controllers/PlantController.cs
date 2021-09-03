using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PlantWatering.Models;
using PlantWatering.Repository;
using System;
using System.Threading.Tasks;

namespace PlantWatering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantController : ControllerBase
    {
        private readonly IPlantRepository _plantRepository;

        public PlantController(IPlantRepository plantRepository)
        {
            _plantRepository = plantRepository;
        }

        //Get All Plants
        [HttpGet]
        public async Task<IActionResult> GetAllPlants()
        {
            try
            {
                var plants = await _plantRepository.GetAllPlantsAsync();
                return Ok(plants);
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return StatusCode(500, "Internal Server Error");  
            }
        }

        //Get Plant by Id

        [HttpGet("{plantId}")]
        public async Task<IActionResult> GetPlantById([FromRoute] int plantId)
        {
            try
            {
                var plant = await _plantRepository.GetPlantByIdAsync(plantId);
                if (plant == null)
                {
                    return NotFound();
                }
                return Ok(plant);
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return StatusCode(500, "Internal Server error");
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> AddNewPlant([FromBody] PlantModel plantModel)
        {
            try
            {
                var plantId = await _plantRepository.AddPlantAsync(plantModel);
                return CreatedAtAction(nameof(GetPlantById), new { plantId = plantId, controller = "plant" }, plantId);
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return StatusCode(500, "Internal Server error");
            }
        }

        [HttpPut("{plantId}")]
        public async Task<IActionResult> UpdatePlant([FromBody] PlantModel plantModel, [FromRoute] int plantId)
        {
            try
            {
                await _plantRepository.UpdatePlantAsync(plantId, plantModel);
                return Ok();
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return StatusCode(500, "Internal Server error");
            }
        }

        [HttpPatch("{plantId}")]
        public async Task<IActionResult> UpdatePlantPatch([FromBody] JsonPatchDocument plantModel, [FromRoute] int plantId)
        {
            try
            {
                await _plantRepository.UpdatePlantAsync(plantId, plantModel);
                return Ok();
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return StatusCode(500, "Internal Server error");
            }
        }

    }
}
