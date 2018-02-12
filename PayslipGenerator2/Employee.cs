namespace PayslipGenerator2
{
    public struct Employee
    {
        private string _firstName;
        private string _lastName;
        private int _annualSalary;
        private int _superRate;
        private string _paymentStartDate;

        public Employee(string firstName, string lastName, int annualSalary, int superRate, string paymentStartDate)
        {
            _firstName = firstName;
            _lastName = lastName;
            _annualSalary = annualSalary;
            _superRate = superRate;
            _paymentStartDate = paymentStartDate;
        }
    }
}