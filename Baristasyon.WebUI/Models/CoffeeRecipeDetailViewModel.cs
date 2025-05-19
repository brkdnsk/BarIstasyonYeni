using Baristasyon.Application.Dtos;

namespace Baristasyon.WebUI.Models
{
    public class CoffeeRecipeDetailViewModel
    {
        public ResultCoffeeRecipeDto Recipe { get; set; } = null!;
        public List<ResultReviewDto> Reviews { get; set; } = new();
        public CreateReviewDto NewReview { get; set; } = new();
    }
}
