using System.Collections.Generic;
using RepaymentConsole.Model;

namespace RepaymentConsole.Calculator
{
    public interface IInterestCalculator
    {
        decimal CalculateAnnualInterest(IEnumerable<Lender> lenders, int amount);
    }
}