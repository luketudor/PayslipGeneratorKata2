namespace PayslipGenerator2.DTO
{
    public struct Employee
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public int AnnualSalary { set; get; }
        public double SuperRate { set; get; }
        public string PaymentStartDate { set; get; }
    }
}