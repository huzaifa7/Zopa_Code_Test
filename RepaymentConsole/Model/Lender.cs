namespace RepaymentConsole.Model
{
    public class Lender
    {
        public int Amount { get; }
        public decimal InterestRate { get; }

        public Lender(int amount, decimal interestRate)
        {
            Amount = amount;
            InterestRate = interestRate;
        }
    }
}