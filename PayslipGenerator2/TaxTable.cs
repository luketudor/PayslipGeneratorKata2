namespace PayslipGenerator2
{
    public class TaxTable
    {
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
    }
}