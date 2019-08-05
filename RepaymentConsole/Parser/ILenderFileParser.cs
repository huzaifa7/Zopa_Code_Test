using System.Collections.Generic;
using System.Linq;
using RepaymentConsole.Model;

namespace RepaymentConsole.Parser
{
    public interface ILenderFileParser
    {
        IEnumerable<Lender> GetLenders(string fileName);
    }
}