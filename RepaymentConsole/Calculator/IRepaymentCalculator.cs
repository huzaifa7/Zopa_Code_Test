using RepaymentConsole.Model;

namespace RepaymentConsole.Calculator
{
    public interface IRepaymentCalculator
    {
        Repayment Calculate(decimal annualInterestRate, int amount, int termInMonths);
    }
}