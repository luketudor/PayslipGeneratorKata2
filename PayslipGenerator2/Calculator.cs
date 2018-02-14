using System;
using PayslipGenerator2.DTO;

namespace PayslipGenerator2
{
    public class Calculator
    {
        private readonly int _payslipsPerYear;
        private readonly TaxFinder _taxFinder;

        public Calculator()
        {
            _taxFinder = new TaxFinder(new[]
                {
                    new TaxBracket {LowerBound = 0, UpperBound = 18200, Rate = 0, LumpTax = 0},
                    new TaxBracket {LowerBound = 18200, UpperBound = 37000, Rate = .19, LumpTax = 0},
                    new TaxBracket {LowerBound = 37000, UpperBound = 80000, Rate = .325, LumpTax = 3572},
                    new TaxBracket {LowerBound = 80000, UpperBound = 180000, Rate = .37, LumpTax = 17547},
                    new TaxBracket {LowerBound = 180000, UpperBound = int.MaxValue, Rate = .45, LumpTax = 54547}
                }
            );
            _payslipsPerYear = 12;
        }

        public Payslip MakePayslip(Employee employee)
        {
            var name = Name(employee.FirstName, employee.LastName);
            var payPeriod = employee.PaymentStartDate;
            var grossIncome = GrossIncome(employee.AnnualSalary);
            var incomeTax = IncomeTax(employee.AnnualSalary);
            var netIncome = NetIncome(grossIncome, incomeTax);
            var super = Super(grossIncome, employee.SuperRate);

            return new Payslip
            {
                Name = name,
                PayPeriod = payPeriod,
                GrossIncome = Convert.ToInt32(grossIncome),
                IncomeTax = Convert.ToInt32(incomeTax),
                NetIncome = Convert.ToInt32(netIncome),
                Super = Convert.ToInt32(super)
            };
        }

        internal string Name(string first, string last)
        {
            return $@"{first} {last}";
        }

        internal double GrossIncome(double annualSalary)
        {
            return annualSalary / _payslipsPerYear;
        }

        internal double IncomeTax(double annualSalary)
        {
            return _taxFinder.AnnualIncomeTax(annualSalary) / _payslipsPerYear;
        }

        internal double NetIncome(double grossIncome, double incomeTax)
        {
            return grossIncome - incomeTax;
        }

        internal double Super(double grossIncome, double superRate)
        {
            return grossIncome * superRate;
        }
    }
}