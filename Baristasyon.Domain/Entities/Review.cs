using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baristasyon.Domain.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int UserId { get; set; } // Yorumu yapan kullanıcı
        public int CoffeeRecipeId { get; set; } // Hangi tarife yapıldı
        public string Comment { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // opsiyonel navigationlar
        public CoffeeRecipe? CoffeeRecipe { get; set; }
    }

}
