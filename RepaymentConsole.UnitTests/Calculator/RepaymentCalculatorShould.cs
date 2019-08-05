using System.Collections.Generic;
using System.Text;
using RepaymentConsole.Calculator;
using Xunit;

namespace RepaymentConsole.UnitTests.Calculator
{
    public class RepaymentCalculatorShould
    {
        [Fact]
        public void Calculate_Repayment()
        {
            // Arrange
            decimal interestRate = 0.144m;
            decimal expectedmonthlyRepayment = 34.3722275749651m;
            decimal expectedTotalRepayment = 1237.40019269874m;
            int amount = 1000;
            int termInMonths = 36;
            IRepaymentCalculator repaymentCalculator = new RepaymentCalculator();

            // Act
            var repayment = repaymentCalculator.Calculate(interestRate, amount, termInMonths);

            // Assert
            Assert.Equal(amount, repayment.RequestedAmount);
            Assert.Equal(interestRate, repayment.AnnualInterestRate);
            Assert.Equal(expectedmonthlyRepayment, repayment.MonthlyRepayment);
            Assert.Equal(expectedTotalRepayment, repayment.TotalRepayment);
        }
    }
}
