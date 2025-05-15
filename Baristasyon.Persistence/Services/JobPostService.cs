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
    public class JobPostService : IJobPostService
    {
        private readonly BaristasyonDbContext _context;
        private readonly IMapper _mapper;

        public JobPostService(BaristasyonDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ResultJobPostDto>> GetAllAsync()
        {
            var entities = await _context.JobPosts.ToListAsync();
            return _mapper.Map<List<ResultJobPostDto>>(entities);
        }

        public async Task<ResultJobPostDto?> GetByIdAsync(int id)
        {
            var entity = await _context.JobPosts.FindAsync(id);
            return entity == null ? null : _mapper.Map<ResultJobPostDto>(entity);
        }

        public async Task<ResultJobPostDto> CreateAsync(CreateJobPostDto dto)
        {
            var entity = _mapper.Map<JobPost>(dto);
            _context.JobPosts.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<ResultJobPostDto>(entity);
        }

        public async Task<bool> UpdateAsync(int id, UpdateJobPostDto dto)
        {
            var entity = await _context.JobPosts.FindAsync(id);
            if (entity == null) return false;

            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.JobPosts.FindAsync(id);
            if (entity == null) return false;

            _context.JobPosts.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
