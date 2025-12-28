namespace BudgetApi.Dto
{
    public class CreateCategoryResDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
