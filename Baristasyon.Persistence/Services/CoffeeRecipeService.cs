using AutoMapper;
using Baristasyon.Application.Dtos;
using Baristasyon.Application.Interfaces.Services;
using Baristasyon.Domain.Entities;
using Baristasyon.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baristasyon.Persistence.Services
{
    public class CoffeeRecipeService : ICoffeeRecipeService
    {
        private readonly BaristasyonDbContext _context;
        private readonly IMapper _mapper;

        public CoffeeRecipeService(BaristasyonDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ResultCoffeeRecipeDto>> GetAllAsync()
        {
            var entities = await _context.CoffeeRecipes.ToListAsync();
            return _mapper.Map<List<ResultCoffeeRecipeDto>>(entities);
        }

        public async Task<ResultCoffeeRecipeDto?> GetByIdAsync(int id)
        {
            var entity = await _context.CoffeeRecipes.FindAsync(id);
            return entity == null ? null : _mapper.Map<ResultCoffeeRecipeDto>(entity);
        }

        public async Task<ResultCoffeeRecipeDto> CreateAsync(CreateCoffeeRecipeDto dto)
        {
            var entity = _mapper.Map<CoffeeRecipe>(dto);
            _context.CoffeeRecipes.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<ResultCoffeeRecipeDto>(entity);
        }

        public async Task<bool> UpdateAsync(int id, UpdateCoffeeRecipeDto dto)
        {
            var entity = await _context.CoffeeRecipes.FindAsync(id);
            if (entity == null) return false;

            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.CoffeeRecipes.FindAsync(id);
            if (entity == null) return false;

            _context.CoffeeRecipes.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
    }

