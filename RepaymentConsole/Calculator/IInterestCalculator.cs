using System.Collections.Generic;
using RepaymentConsole.Model;

namespace RepaymentConsole.Calculator
{
    public interface IInterestCalculator
    {
        decimal CalculateTotalAnnualInterest(IEnumerable<Lender> lenders, int amount);
    }
}