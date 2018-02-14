using System;
using PayslipGenerator2.Structures;

namespace PayslipGenerator2
{
    public class Calculator
    {
        private readonly int _payslipsPerYear;
        private readonly TaxTable _taxTable;

        public Calculator()
        {
            _taxTable = new TaxTable(new[]
                {
                    new TaxBracket(0, 18200, 0, 0),
                    new TaxBracket(18200, 37000, .19, 0),
                    new TaxBracket(37000, 80000, .325, 3572),
                    new TaxBracket(80000, 180000, .37, 17547),
                    new TaxBracket(180000, int.MaxValue, .45, 54547)
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

            return new Payslip(
                name,
                payPeriod,
                Convert.ToInt32(grossIncome),
                Convert.ToInt32(incomeTax),
                Convert.ToInt32(netIncome),
                Convert.ToInt32(super));
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
            return _taxTable.AnnualIncomeTax(annualSalary) / _payslipsPerYear;
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