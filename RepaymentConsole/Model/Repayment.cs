namespace RepaymentConsole.Model
{
    public class Repayment
    {
        public int RequestedAmount { get; }
        public decimal AnnualInterestRateInPercent { get; }
        public decimal MonthlyRepayment { get; }
        public decimal TotalRepayment { get; }

        public Repayment(int requestedAmount, decimal annualInterestRateInPercent, decimal monthlyRepayment,
            decimal totalRepayment)
        {
            RequestedAmount = requestedAmount;
            AnnualInterestRateInPercent = annualInterestRateInPercent;
            MonthlyRepayment = monthlyRepayment;
            TotalRepayment = totalRepayment;
        }
    }
}