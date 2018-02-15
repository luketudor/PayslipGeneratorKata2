using System;
using PayslipGenerator2.DTO;

namespace PayslipGenerator2
{
    public class Accountant
    {
        private readonly Calculator _calculator;

        public Accountant()
        {
            _calculator = new Calculator(new[]
                {
                    new TaxBracket {LowerBound = 0, UpperBound = 18200, Rate = 0, LumpTax = 0},
                    new TaxBracket {LowerBound = 18200, UpperBound = 37000, Rate = .19, LumpTax = 0},
                    new TaxBracket {LowerBound = 37000, UpperBound = 80000, Rate = .325, LumpTax = 3572},
                    new TaxBracket {LowerBound = 80000, UpperBound = 180000, Rate = .37, LumpTax = 17547},
                    new TaxBracket {LowerBound = 180000, UpperBound = int.MaxValue, Rate = .45, LumpTax = 54547}
                },
                12
            );
        }

        public Payslip MakePayslip(Employee employee)
        {
            var name = _calculator.Name(employee.FirstName, employee.LastName);
            var payPeriod = employee.PaymentStartDate;
            var grossIncome = _calculator.GrossIncome(employee.AnnualSalary);
            var incomeTax = _calculator.IncomeTax(employee.AnnualSalary);
            var netIncome = _calculator.NetIncome(grossIncome, incomeTax);
            var super = _calculator.Super(grossIncome, employee.SuperRate);

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
    }
}