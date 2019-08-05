using System;
using RepaymentConsole.Calculator;
using RepaymentConsole.Parser;
using RepaymentConsole.Service;

namespace RepaymentConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Repayment Console");
            var repaymentService = SetupService();

            while (true)
            {
                Console.WriteLine(@"Enter csv file and amount --> C:\Users\huzaifaa\source\repos\RepaymentConsole\Market.csv 1000");
                var input = Console.ReadLine();
                var inputValues = input.Split(' ');
                var fileName = inputValues[0];
                var amount = inputValues[1];
                var repaymentQuote = repaymentService.Process(fileName, Convert.ToInt32(amount));
                Console.WriteLine(repaymentQuote);
            }
        }

        private static RepaymentService SetupService()
        {
            return new RepaymentService(new LenderFileParser(), new InterestCalculator(), new RepaymentCalculator());
        }
    }
}
