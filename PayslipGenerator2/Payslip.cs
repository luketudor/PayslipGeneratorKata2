namespace PayslipGenerator2
{
    public struct Payslip
    {
        private string _name;
        private string _payPeriod;
        private int _grossIncome;
        private int _incomeTax;
        private int _netIncome;
        private int _super;

        public Payslip(string name, string payPeriod, int grossIncome, int incomeTax, int netIncome, int super)
        {
            _name = name;
            _payPeriod = payPeriod;
            _grossIncome = grossIncome;
            _incomeTax = incomeTax;
            _netIncome = netIncome;
            _super = super;
        }
    }
}