using System;

namespace PayslipGenerator2
{
    public class PayslipGenerator
    {
        public string Process(string employeeDetails)
        {
            var parser = new EmployeeDetailsParser();
            var employee = parser.CsvParse(employeeDetails);
            var payslip = MakePayslip(employee);

            return FormatPayslip(payslip);
        }

        public Payslip MakePayslip(Employee employee)
        {
            var name = $"{employee.FirstName} {employee.LastName}";
            var payPeriod = employee.PaymentStartDate;
            var grossIncome = employee.AnnualSalary / 12;
            var incomeTax = AnnualIncomeTax(employee.AnnualSalary) / 12;
            var netIncome = grossIncome - incomeTax;
            var super = grossIncome * employee.SuperRate;

            return new Payslip(name, payPeriod, grossIncome, (int) Math.Round(incomeTax), (int) Math.Round(netIncome),
                (int) Math.Round(super));
        }

        public double AnnualIncomeTax(double annualSalary)
        {
            double incomeTax;
            if (annualSalary <= 18200)
            {
                incomeTax = 0;
            }
            else if (annualSalary <= 37000)
            {
                incomeTax = (annualSalary - 18200) * .19;
            }
            else if (annualSalary <= 80000)
            {
                incomeTax = (37000 - 18200) * .19 + (annualSalary - 37000) * .325;
            }
            else if (annualSalary <= 180000)
            {
                incomeTax = (37000 - 18200) * .19 + (80000 - 37000) * .325 + (annualSalary - 80000) * .37;
            }
            else
            {
                incomeTax = (37000 - 18200) * .19 + (80000 - 37000) * .325 * (180000 - 80000) * .37 +
                            (annualSalary - 180000) * .45;
            }
            return incomeTax;
        }

        public string FormatPayslip(Payslip payslip)
        {
            return
                $"{payslip.Name},{payslip.PayPeriod},{payslip.GrossIncome},{payslip.IncomeTax},{payslip.NetIncome},{payslip.Super}";
        }
    }
}