using System;
using System.Collections.Generic;
using System.Linq;
using RepaymentConsole.Model;

namespace RepaymentConsole.Calculator
{
    public class InterestCalculator : IInterestCalculator
    {
        public decimal CalculateTotalAnnualInterest(IEnumerable<Lender> lenders, int amount)
        {
            var sortedLenders = SortLenderCollectionByInterestRate(lenders);
            int outstandingAmount = amount;
            decimal totalInterestRateInPercent = 0;
            foreach (var lender in sortedLenders)
            {
                if (outstandingAmount <= 0)
                {
                    break;
                }

                outstandingAmount -= lender.Amount;
                totalInterestRateInPercent += lender.InterestRate;
            }
            var decimalVal = Convert.ToDecimal(totalInterestRateInPercent);
            var doubleVal = Math.Round(totalInterestRateInPercent, 3);
            return decimalVal;
        }

        private static IOrderedEnumerable<Lender> SortLenderCollectionByInterestRate(IEnumerable<Lender> lenders)
        {
            return lenders.OrderBy(lender => lender.InterestRate);
        }
    }
}