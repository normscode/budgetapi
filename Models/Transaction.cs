namespace BudgetApi.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Note { get; set; } = string.Empty;
    }
}
