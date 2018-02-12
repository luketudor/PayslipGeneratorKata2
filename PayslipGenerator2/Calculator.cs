using System;

namespace PayslipGenerator2
{
    public class Calculator
    {
        private readonly int _payslipsPerYear;
        private readonly TaxTable _taxTable;

        public Calculator()
        {
            _taxTable = new TaxTable(null);
            _payslipsPerYear = 12;
        }

        public Payslip MakePayslip(Employee employee)
        {
            int Round(double number)
            {
                return Convert.ToInt32(Math.Round(number));
            }

            var name = $"{employee.FirstName} {employee.LastName}";
            var payPeriod = employee.PaymentStartDate;
            var grossIncome = employee.AnnualSalary / _payslipsPerYear;
            var incomeTax = _taxTable.AnnualIncomeTax(employee.AnnualSalary) / _payslipsPerYear;
            var netIncome = grossIncome - incomeTax;
            var super = grossIncome * employee.SuperRate;

            return new Payslip(
                name,
                payPeriod,
                grossIncome,
                Round(incomeTax),
                Round(netIncome),
                Round(super));
        }
    }
}