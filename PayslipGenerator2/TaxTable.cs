using System;
using System.Collections.Generic;
using PayslipGenerator2.Structures;

namespace PayslipGenerator2
{
    public class TaxTable
    {
        private readonly IReadOnlyList<TaxBracket> _taxBrackets;

        public TaxTable(IReadOnlyList<TaxBracket> taxBrackets)
        {
            _taxBrackets = taxBrackets;
        }

        public double AnnualIncomeTax(double annualSalary)
        {
            for (var i = 0; i < _taxBrackets.Count; i++)
            {
                var lowerBound = i > 0 ? _taxBrackets[i - 1].CutOff : 0;
                var upperBound = _taxBrackets[i].CutOff;

                if (annualSalary <= upperBound)
                {
                    return (annualSalary - lowerBound) * _taxBrackets[i].Rate + _taxBrackets[i].LumpTax;
                }
            }
            throw new ArgumentOutOfRangeException(nameof(annualSalary), "Exceeds Top Tax Bracket");
        }
    }
}