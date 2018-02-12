namespace PayslipGenerator2
{
    public class Formatter
    {
        private readonly string _separator;

        public Formatter()
        {
            _separator = ",";
        }

        public string FormatPayslip(Payslip payslip)
        {
            return string.Join(_separator,
                payslip.Name,
                payslip.PayPeriod,
                payslip.GrossIncome,
                payslip.IncomeTax,
                payslip.NetIncome,
                payslip.Super);
        }
    }
}