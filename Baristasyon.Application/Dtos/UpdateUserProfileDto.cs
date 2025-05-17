using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baristasyon.Application.Dtos
{
    public class UpdateUserProfileDto
    {
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string? Bio { get; set; }
        public string? AvatarUrl { get; set; }
    }
}
