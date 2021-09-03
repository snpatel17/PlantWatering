using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using PlantWatering.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlantWatering.Repository
{
    public class PlantRepository : IPlantRepository
    {
        private readonly PlantContext _context;
        private readonly IMapper _mapper;

        public PlantRepository(PlantContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Get All Plants from database
        //Using Automaper so we dont need to type all fields manualy
        public async Task<List<PlantModel>> GetAllPlantsAsync()
        {
            var records = await _context.Plants.ToListAsync();
            return _mapper.Map<List<PlantModel>>(records);
            
        }

        //Get Plant by Id
        public async Task<PlantModel> GetPlantByIdAsync(int plantId)
        {
            var Plant = await _context.Plants.FindAsync(plantId);
            return _mapper.Map<PlantModel>(Plant);
        }

        //Add Plant record in database
        public async Task<int> AddPlantAsync(PlantModel plantModel)
        {
            var plant = new PlantModel()
            {
                PlantName = plantModel.PlantName,
                StartTime = DateTime.Now,
                WaterStatus = plantModel.WaterStatus
            };
            _context.Plants.Add(plant);
            await _context.SaveChangesAsync();

            return plant.Id;
        }

        //Update Plant records after watering starts
        public async Task UpdatePlantAsync(int plantId, PlantModel plantModel)
        {
            var plant = new PlantModel()
            {
                PlantName = plantModel.PlantName,
                StartTime = DateTime.Now,
                WaterStatus = plantModel.WaterStatus
            };
            _context.Plants.Update(plant);
            await _context.SaveChangesAsync();

        }

        //Update Plant using JasonPatchDocument
        //Checks only the field which is updated and change that field in database
        public async Task UpdatePlantAsync(int plantId, JsonPatchDocument plantModel)
        {
            var plant = await _context.Plants.FindAsync(plantId);
            if (plant != null)
            {
                plantModel.ApplyTo(plant);
                await _context.SaveChangesAsync();
            }

        }
    }
}
