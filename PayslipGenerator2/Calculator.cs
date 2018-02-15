using System.Collections.Generic;
using System.Linq;
using PayslipGenerator2.DTO;

namespace PayslipGenerator2
{
    public class Calculator
    {
        private readonly IOrderedEnumerable<TaxBracket> _taxBrackets;
        private readonly int _payslipsPerYear;

        public Calculator(IEnumerable<TaxBracket> taxBrackets, int payslipsPerYear)
        {
            _payslipsPerYear = payslipsPerYear;
            _taxBrackets = taxBrackets.OrderBy(bracket => bracket.UpperBound);
        }

        internal double AnnualIncomeTax(double annualSalary)
        {
            var relevantBracket = _taxBrackets.First(bracket => annualSalary <= bracket.UpperBound);

            return (annualSalary - relevantBracket.LowerBound) * relevantBracket.Rate + relevantBracket.LumpTax;
        }

        public string Name(string first, string last)
        {
            return $@"{first} {last}";
        }

        public double GrossIncome(double annualSalary)
        {
            return annualSalary / _payslipsPerYear;
        }

        public double IncomeTax(double annualSalary)
        {
            return AnnualIncomeTax(annualSalary) / _payslipsPerYear;
        }

        public double NetIncome(double grossIncome, double incomeTax)
        {
            return grossIncome - incomeTax;
        }

        public double Super(double grossIncome, double superRate)
        {
            return grossIncome * superRate;
        }
    }
}