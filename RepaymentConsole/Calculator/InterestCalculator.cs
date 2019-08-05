using System;
using System.Collections.Generic;
using System.Linq;
using RepaymentConsole.Model;

namespace RepaymentConsole.Calculator
{
    public class InterestCalculator : IInterestCalculator
    {
        public decimal CalculateAnnualInterest(IEnumerable<Lender> lenders, int amount)
        {
            var sortedLenders = SortLenderCollectionByInterestRate(lenders);
            int outstandingAmount = amount;
            decimal totalInterestRate = 0;
            foreach (var lender in sortedLenders)
            {
                if (outstandingAmount <= 0)
                {
                    break;
                }

                outstandingAmount -= lender.Amount;
                totalInterestRate += lender.InterestRate;
            }
            var decimalVal = Convert.ToDecimal(totalInterestRate);
            var doubleVal = Math.Round(totalInterestRate, 3);
            return decimalVal;
        }

        private static IOrderedEnumerable<Lender> SortLenderCollectionByInterestRate(IEnumerable<Lender> lenders)
        {
            return lenders.OrderBy(lender => lender.InterestRate);
        }
    }
}