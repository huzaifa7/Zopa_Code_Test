using RepaymentConsole.Calculator;
using RepaymentConsole.Model;
using Xunit;

namespace RepaymentConsole.UnitTests.Calculator
{
    public class InterestCalculatorShould
    {
        [Fact]
        public void Return_Annual_Interest_Applicable_Based_On_Amount_Request()
        {
            // Arrange
            var amount = 200;
            var lenders = new[] {new Lender(100, 0.069m), new Lender(250, 0.075m)};
            IInterestCalculator interestCalculator = new InterestCalculator();
            var expectedInterestedRate = 0.144m;

            // Act
            var interestRate = interestCalculator.CalculateAnnualInterest(lenders, amount);

            // Assert
            Assert.Equal(expectedInterestedRate, interestRate);
        }
    }
}
