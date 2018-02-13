namespace PayslipGenerator2.Structures
{
    public struct Employee
    {
        public string FirstName { get; }
        public string LastName { get; }
        public int AnnualSalary { get; }
        public double SuperRate { get; }
        public string PaymentStartDate { get; }

        public Employee(string firstName, string lastName, int annualSalary, double superRate, string paymentStartDate)
        {
            FirstName = firstName;
            LastName = lastName;
            AnnualSalary = annualSalary;
            SuperRate = superRate;
            PaymentStartDate = paymentStartDate;
        }
    }
}