using Microsoft.AspNetCore.JsonPatch;
using PlantWatering.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlantWatering.Repository
{
    public interface IPlantRepository
    {
        Task<List<PlantModel>> GetAllPlantsAsync();
        Task<PlantModel> GetPlantByIdAsync(int plantId);
        Task<int> AddPlantAsync(PlantModel plantModel);
        Task UpdatePlantAsync(int plantId, PlantModel plantModel);
        Task UpdatePlantAsync(int plantId, JsonPatchDocument plantModel);
    }
}
