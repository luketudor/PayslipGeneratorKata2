using PayslipGenerator2.Structures;

namespace PayslipGenerator2
{
    public class TaxTable
    {
        private readonly TaxBracket[] _taxBrackets;

        public TaxTable(TaxBracket[] taxBrackets)
        {
            _taxBrackets = taxBrackets;
        }

        public double AnnualIncomeTax(double annualSalary)
        {
            var incomeTax = 0.0;
            for (var i = 0; i < _taxBrackets.Length; i++)
            {
                var lowerBound = i > 0 ? _taxBrackets[i - 1].CutOff : 0;
                var upperBound = _taxBrackets[i].CutOff;

                if (annualSalary <= upperBound)
                {
                    incomeTax = (annualSalary - lowerBound) * _taxBrackets[i].Rate + _taxBrackets[i].LumpTax;
                    break;
                }
            }
            return incomeTax;
        }
    }
}