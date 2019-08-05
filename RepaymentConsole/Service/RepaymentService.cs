using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RepaymentConsole.Calculator;
using RepaymentConsole.Model;
using RepaymentConsole.Parser;

namespace RepaymentConsole.Service
{
    public class RepaymentService
    {
        private const int TermInMonths = 36;
        private readonly ILenderFileParser _lenderFileParser;
        private readonly IInterestCalculator _interestCalculator;
        private readonly IRepaymentCalculator _repaymentCalculator;

        public RepaymentService(ILenderFileParser lenderFileParser, IInterestCalculator interestCalculator,
            IRepaymentCalculator repaymentCalculator)
        {
            _lenderFileParser = lenderFileParser;
            _interestCalculator = interestCalculator;
            _repaymentCalculator = repaymentCalculator;
        }

        public string Process(string fileName, int amount)
        {
            var lenders = _lenderFileParser.GetLenders(fileName);

            if (RequestAmountIsNotAvailable(amount, lenders))
            {
                return "Sorry, it is not possible to provide a quote";
            }

            var interestRate = _interestCalculator.CalculateAnnualInterest(lenders, amount);

            var repayment = _repaymentCalculator.Calculate(interestRate, amount, TermInMonths);

            return FormatQuote(repayment);
        }

        private string FormatQuote(Repayment repayment)
        {
            if (repayment != null)
            {
                var quoteFormatter = new StringBuilder();
                quoteFormatter.AppendLine($"Requested amount: £{repayment.RequestedAmount}");
                quoteFormatter.AppendLine($"Annual Interest Rate: {Math.Round(repayment.AnnualInterestRate, 1)}%");
                quoteFormatter.AppendLine($"Monthly repayment: £{Math.Round(repayment.MonthlyRepayment,2)}");
                quoteFormatter.AppendLine($"Total repayment: £{Math.Round(repayment.TotalRepayment,2)}");

                return quoteFormatter.ToString();
            }

            return string.Empty;
        }

        private bool RequestAmountIsNotAvailable(int amount, IEnumerable<Lender> lenders)
        {
            return amount > lenders.Sum(lender => lender.Amount);
        }
    }
}