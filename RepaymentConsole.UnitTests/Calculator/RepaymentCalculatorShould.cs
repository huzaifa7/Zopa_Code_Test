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
            decimal expectedmonthlyRepayment = 27.8394876085315m;
            decimal expectedTotalRepayment = 1002.22155390714m;
            int amount = 1000;
            int termInMonths = 36;
            IRepaymentCalculator repaymentCalculator = new RepaymentCalculator();

            // Act
            var repayment = repaymentCalculator.Calculate(interestRate, amount, termInMonths);

            // Assert
            Assert.Equal(amount, repayment.RequestedAmount);
            Assert.Equal(interestRate, repayment.AnnualInterestRateInPercent);
            Assert.Equal(expectedmonthlyRepayment, repayment.MonthlyRepayment);
            Assert.Equal(expectedTotalRepayment, repayment.TotalRepayment);
        }
    }
}
