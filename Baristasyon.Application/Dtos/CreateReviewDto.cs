using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baristasyon.Application.Dtos
{
    public class CreateReviewDto
    {
        public int UserId { get; set; }
        public int CoffeeRecipeId { get; set; }
        public string Comment { get; set; } = null!;
    }
}
