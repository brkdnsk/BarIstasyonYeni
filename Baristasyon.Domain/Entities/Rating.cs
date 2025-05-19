using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baristasyon.Domain.Entities
{
    public class Rating
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CoffeeRecipeId { get; set; }
        public int Score { get; set; } // 1–5
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

}
