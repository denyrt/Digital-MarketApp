namespace DigitalMarket.Presentation.Models.Account
{
    public record MeViewModel
    {
        public string Username { get; init; }

        public string Email { get; init; }

        public double Balance { get; init; }

        public MyTransactionViewModel[] LastTransactions { get; init; }
    }
}