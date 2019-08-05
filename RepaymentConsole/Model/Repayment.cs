namespace RepaymentConsole.Model
{
    public class Repayment
    {
        public int RequestedAmount { get; }
        public decimal AnnualInterestRate { get; }
        public decimal MonthlyRepayment { get; }
        public decimal TotalRepayment { get; }

        public Repayment(int requestedAmount, decimal annualInterestRate, decimal monthlyRepayment, decimal totalRepayment)
        {
            RequestedAmount = requestedAmount;
            AnnualInterestRate = annualInterestRate;
            MonthlyRepayment = monthlyRepayment;
            TotalRepayment = totalRepayment;
        }
    }
}