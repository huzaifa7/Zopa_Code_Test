using System;
using RepaymentConsole.Model;

namespace RepaymentConsole.Calculator
{
    public class RepaymentCalculator : IRepaymentCalculator
    {
        public Repayment Calculate(decimal annualInterestRate, int amount, int termInMonths)
        {
            var monthlyInterestRate = Convert.ToDouble(annualInterestRate / 12);

            var monthlyAmount = amount / ((Math.Pow((1 + monthlyInterestRate), termInMonths) - 1) /
                                          (monthlyInterestRate * (Math.Pow(1 + monthlyInterestRate, termInMonths))));
            var totalRepayment = monthlyAmount * termInMonths;

            return new Repayment(amount, annualInterestRate, Convert.ToDecimal(monthlyAmount), Convert.ToDecimal(totalRepayment));
        }
    }
}