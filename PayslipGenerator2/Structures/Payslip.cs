namespace PayslipGenerator2.Structures
{
    public struct Payslip
    {
        public string Name { get; }
        public string PayPeriod { get; }
        public int GrossIncome { get; }
        public int IncomeTax { get; }
        public int NetIncome { get; }
        public int Super { get; }

        public Payslip(string name, string payPeriod, int grossIncome, int incomeTax, int netIncome, int super)
        {
            Name = name;
            PayPeriod = payPeriod;
            GrossIncome = grossIncome;
            IncomeTax = incomeTax;
            NetIncome = netIncome;
            Super = super;
        }
    }
}