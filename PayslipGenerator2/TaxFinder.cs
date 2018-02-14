using System.Collections.Generic;
using System.Linq;
using PayslipGenerator2.DTO;

namespace PayslipGenerator2
{
    public class TaxFinder
    {
        private readonly IOrderedEnumerable<TaxBracket> _taxBrackets;

        public TaxFinder(IEnumerable<TaxBracket> taxBrackets)
        {
            _taxBrackets = taxBrackets.OrderBy(bracket => bracket.UpperBound);
        }

        public double AnnualIncomeTax(double annualSalary)
        {
            var relevantBracket = _taxBrackets.First(bracket => annualSalary <= bracket.UpperBound);

            return (annualSalary - relevantBracket.LowerBound) * relevantBracket.Rate + relevantBracket.LumpTax;
        }
    }
}