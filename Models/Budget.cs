namespace BudgetApi.Models
{
    public class Budget
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int Month { get; set; }
        public int Year { get; set; }
        public decimal Amount { get; set; }
    }
}
