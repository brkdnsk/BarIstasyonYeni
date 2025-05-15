using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baristasyon.Domain.Entities
{
    public class FavoriteRecipe
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int CoffeeRecipeId { get; set; }

        public DateTime AddedAt { get; set; } = DateTime.UtcNow;
    }
}
