using System.Linq;
using RepaymentConsole.Parser;
using Xunit;

namespace RepaymentConsole.IntegrationTests.Parser
{
    public class LenderFileParserShould
    {
        [Fact]
        public void Return_Collection_Of_Lenders_From_Csv_File()
        {
            // Arrange
            var fileName =
                @"C:\Users\huzaifaa\source\repos\RepaymentConsole\Market.csv";
            ILenderFileParser lenderFileParser = new LenderFileParser();

            // Act
            var lenders = lenderFileParser.GetLenders(fileName);

            // Assert
            Assert.NotEmpty(lenders);
            Assert.Equal(640m, lenders.First().Amount);
            Assert.Equal(0.075m, lenders.First().InterestRate);
        }
    }
}
