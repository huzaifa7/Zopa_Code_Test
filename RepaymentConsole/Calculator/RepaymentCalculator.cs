using System;
using RepaymentConsole.Model;

namespace RepaymentConsole.Calculator
{
    public class RepaymentCalculator : IRepaymentCalculator
    {
        public Repayment Calculate(decimal annualInterestRateInPercent, int amount, int termInMonths)
        {

            var monthlyInterestRate = GetMonthlyInterestRate(annualInterestRateInPercent);

            var monthlyAmount = amount / ((Math.Pow((1 + monthlyInterestRate), termInMonths) - 1) /
                                          (monthlyInterestRate * (Math.Pow(1 + monthlyInterestRate, termInMonths))));

            var totalRepayment = monthlyAmount * termInMonths;

            return new Repayment(amount, annualInterestRateInPercent, Convert.ToDecimal(monthlyAmount), Convert.ToDecimal(totalRepayment));
        }

        private double GetMonthlyInterestRate(decimal annualInterestRateInPercent)
        {
            var annualInterestRate = annualInterestRateInPercent / 100;
            return Convert.ToDouble(annualInterestRate / 12);
        }
    }
}