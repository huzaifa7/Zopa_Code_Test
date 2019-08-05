using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using RepaymentConsole.Model;

namespace RepaymentConsole.Parser
{
    public class LenderFileParser : ILenderFileParser
    {
        public IEnumerable<Lender> GetLenders(string fileName)
        {
            IEnumerable<string> lenderDetails = File.ReadLines(fileName);
            var lenders = lenderDetails.Skip(1).Select(x =>
            {
                var lenderProperties = x.Split(',');
                return new Lender(Convert.ToInt32(lenderProperties[2]), Convert.ToDecimal(lenderProperties[1]));
            });
            return lenders;
        }
    }
}