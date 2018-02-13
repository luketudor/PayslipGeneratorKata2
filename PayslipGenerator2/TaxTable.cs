using System.Collections.Generic;
using System.Linq;
using PayslipGenerator2.Structures;

namespace PayslipGenerator2
{
    public class TaxTable
    {
        private readonly IEnumerable<TaxBracket> _taxBrackets;

        public TaxTable(IEnumerable<TaxBracket> taxBrackets)
        {
            _taxBrackets = taxBrackets;
        }

        public double AnnualIncomeTax(double annualSalary)
        {
            var relevantBracket = _taxBrackets.First(bracket => annualSalary <= bracket.UpperBound);

            return (annualSalary - relevantBracket.LowerBound) * relevantBracket.Rate + relevantBracket.LumpTax;
        }
    }
}