using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baristasyon.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;

        public string? Bio { get; set; }

        public string PasswordHash { get; set; } = null!;
        public string Role { get; set; } = "user";

        public string? AvatarUrl { get; set; }
        // "admin", "barista", "employer"
    }
}
