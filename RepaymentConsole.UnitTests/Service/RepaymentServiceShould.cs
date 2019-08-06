using System.Collections.Generic;
using System.Text;
using Moq;
using RepaymentConsole.Calculator;
using RepaymentConsole.Model;
using RepaymentConsole.Parser;
using RepaymentConsole.Service;
using Xunit;

namespace RepaymentConsole.UnitTests.Service
{
    public class RepaymentServiceShould
    {
        private readonly Mock<ILenderFileParser> _lenderFileParserMock;
        private readonly Mock<IInterestCalculator> _interestCalculatorMock;
        private readonly Mock<IRepaymentCalculator> _repaymentCalculatorMock;
        private readonly RepaymentService _repaymentService;
        private readonly int _amount = 1000;
        private readonly string _fileName = "./zopa-rate market.csv";

        public RepaymentServiceShould()
        {
            _lenderFileParserMock = new Mock<ILenderFileParser>();
            _interestCalculatorMock = new Mock<IInterestCalculator>();
            _repaymentCalculatorMock = new Mock<IRepaymentCalculator>();
            var lenders = new[] {new Lender(1000, 1.0m)};
            _lenderFileParserMock.Setup(parser => parser.GetLenders(_fileName)).Returns(lenders);
            _repaymentService = new RepaymentService(_lenderFileParserMock.Object, _interestCalculatorMock.Object, _repaymentCalculatorMock.Object);       
        }
        [Fact]
        public void Call_LendersFileParser_When_Processing_Repayment()
        {
            // Act
            _repaymentService.Process(_fileName, _amount);

            // Assert
            _lenderFileParserMock.Verify(parser => parser.GetLenders(_fileName), Times.Once);
        }

        [Fact]
        public void Call_InterestCalculator_When_Processing_Repayment()
        {
            // Act
            _repaymentService.Process(_fileName, _amount);

            // Assert
            _interestCalculatorMock.Verify(calculator => calculator.CalculateTotalAnnualInterest(It.IsAny<IEnumerable<Lender>>(), _amount));
        }

        [Fact]
        public void Call_RepaymentCalculator_When_Processing_Repayment()
        {
            // Arrange
            int termInMonths = 36;

            // Act
            _repaymentService.Process(_fileName, _amount);

            // Assert
            _repaymentCalculatorMock.Verify(calculator => calculator.Calculate(It.IsAny<decimal>(), _amount, termInMonths));
        }

        [Fact]
        public void Return_RepaymentQuote_When_Processing_Request()
        {
            // Arrange
            var termInMonths = 36;
            var expectedRepayment = new Repayment(1000, 7.0m, 30.78m, 1108.10m);
            _interestCalculatorMock.Setup(calculator => calculator.CalculateTotalAnnualInterest(It.IsAny<IEnumerable<Lender>>(), _amount)).Returns(7.0m);
            _repaymentCalculatorMock.Setup(calculator => calculator.Calculate(7.0m, _amount, termInMonths))
                .Returns(expectedRepayment);

            // Act
            var repaymentQuote = _repaymentService.Process(_fileName, _amount);

            // Assert
            var expectedRepaymentQuote = CreateRepaymentQuote();
            Assert.Equal(expectedRepaymentQuote, repaymentQuote);
        }

        private string CreateRepaymentQuote()
        {
            var quoteFormatter = new StringBuilder();
            quoteFormatter.AppendLine("Requested amount: £1000");
            quoteFormatter.AppendLine("Annual Interest Rate: 7.0%");
            quoteFormatter.AppendLine("Monthly repayment: £30.78");
            quoteFormatter.AppendLine("Total repayment: £1108.10");

            return quoteFormatter.ToString();
        }

        [Fact]
        public void Return_Null_When_Requested_Amount_Cannot_Be_Processed()
        {
            // Arrange
            string fileName = "./zopa-rate market.csv";
            int amount = 1000;
            _lenderFileParserMock.Setup(parser => parser.GetLenders(fileName)).Returns(new[] {new Lender(200, 1.0m)});
            
            // Act
            var repaymentQuote = _repaymentService.Process(fileName, amount);

            // Assert
            Assert.Equal("Sorry, it is not possible to provide a quote", repaymentQuote);
        }

    }
}
