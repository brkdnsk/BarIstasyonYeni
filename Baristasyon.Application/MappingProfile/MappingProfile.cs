using AutoMapper;
using Baristasyon.Application.Dtos;
using Baristasyon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Baristasyon.Application.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CoffeeRecipe, ResultCoffeeRecipeDto>().ReverseMap();
            CreateMap<CreateCoffeeRecipeDto, CoffeeRecipe>();
            CreateMap<UpdateCoffeeRecipeDto, CoffeeRecipe>();

            CreateMap<Equipment,ResultEquipmentDto>().ReverseMap();
            CreateMap<CreateEquipmentDto, Equipment>();
            CreateMap<UpdateEquipmentDto, Equipment>();

            CreateMap<FavoriteRecipe, ResultFavoriteRecipeDto>().ReverseMap();
            CreateMap<CreateFavoriteRecipeDto, FavoriteRecipe>();
            CreateMap<UpdateFavoriteRecipeDto, FavoriteRecipe>();

            CreateMap<JobPost, ResultJobPostDto>().ReverseMap();
            CreateMap<CreateJobPostDto, JobPost>();
            CreateMap<UpdateJobPostDto, JobPost>();

            CreateMap<User, ResultJobPostDto>().ReverseMap();
            CreateMap<CreateJobPostDto, JobPost>();
            CreateMap<UpdateJobPostDto, JobPost>();

            CreateMap<User, ResultUserDto>().ReverseMap();

        }
    }
}
