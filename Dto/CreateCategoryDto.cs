using System.ComponentModel.DataAnnotations;

namespace BudgetApi.Dto
{
    public class CreateCategoryDto
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
