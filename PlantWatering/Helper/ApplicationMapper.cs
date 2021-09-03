using AutoMapper;
using PlantWatering.Data;
using PlantWatering.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlantWatering.Helper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Plants, PlantModel>().ReverseMap();
        }
    }

}
