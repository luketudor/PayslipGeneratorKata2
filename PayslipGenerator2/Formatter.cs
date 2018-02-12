namespace PayslipGenerator2
{
    public class Formatter
    {
        public string FormatPayslip(Payslip payslip)
        {
            return
                $"{payslip.Name},{payslip.PayPeriod},{payslip.GrossIncome},{payslip.IncomeTax},{payslip.NetIncome},{payslip.Super}";
        }
    }
}