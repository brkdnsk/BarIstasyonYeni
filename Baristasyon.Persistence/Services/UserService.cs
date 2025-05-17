﻿using AutoMapper;
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
    public class UserService : IUserService
    {
        private readonly BaristasyonDbContext _context;
        private readonly IMapper _mapper;

        public UserService(BaristasyonDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResultUserDto> RegisterAsync(RegisterUserDto dto)
        {
            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password), // 🔐 şifreleme
                Role = "user"
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return _mapper.Map<ResultUserDto>(user);
        }

        public async Task<ResultUserDto?> LoginAsync(LoginUserDto dto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return null;

            return _mapper.Map<ResultUserDto>(user);
        }

        public async Task<ResultUserDto?> GetByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user == null ? null : _mapper.Map<ResultUserDto>(user);
        }

        public async Task<List<ResultUserDto>> GetAllAsync()
        {
            var users = await _context.Users.ToListAsync();
            return _mapper.Map<List<ResultUserDto>>(users);
        }
        public async Task<bool> UpdatePasswordAsync(UpdatePasswordDto dto)
        {
            var user = await _context.Users.FindAsync(dto.UserId);
            if (user == null) return false;

            var valid = BCrypt.Net.BCrypt.Verify(dto.CurrentPassword, user.PasswordHash);
            if (!valid) return false;

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> UpdateProfileAsync(UpdateUserProfileDto dto)
        {
            var user = await _context.Users.FindAsync(dto.UserId);
            if (user == null) return false;

            user.Username = dto.Username;
            user.Bio = dto.Bio;
            user.AvatarUrl = dto.AvatarUrl;

            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> CheckEmailExistsAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email.ToLower() == email.ToLower());
        }



    }
}
