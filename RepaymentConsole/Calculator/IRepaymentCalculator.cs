using RepaymentConsole.Model;

namespace RepaymentConsole.Calculator
{
    public interface IRepaymentCalculator
    {
        Repayment Calculate(decimal annualInterestRateInPercent, int amount, int termInMonths);
    }
}