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
    public class EquipmentService : IEquipmentService
    {
        private readonly BaristasyonDbContext _context;
        private readonly IMapper _mapper;

        public EquipmentService(BaristasyonDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ResultEquipmentDto>> GetAllAsync()
        {
            var entities = await _context.Equipments.ToListAsync();
            return _mapper.Map<List<ResultEquipmentDto>>(entities);
        }

        public async Task<ResultEquipmentDto?> GetByIdAsync(int id)
        {
            var entity = await _context.Equipments.FindAsync(id);
            return entity == null ? null : _mapper.Map<ResultEquipmentDto>(entity);
        }

        public async Task<ResultEquipmentDto> CreateAsync(CreateEquipmentDto dto)
        {
            var entity = _mapper.Map<Equipment>(dto);
            _context.Equipments.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<ResultEquipmentDto>(entity);
        }

        public async Task<bool> UpdateAsync(int id, UpdateEquipmentDto dto)
        {
            var entity = await _context.Equipments.FindAsync(id);
            if (entity == null) return false;

            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Equipments.FindAsync(id);
            if (entity == null) return false;

            _context.Equipments.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
