using PayslipGenerator2.DTO;

namespace PayslipGenerator2
{
    public class Parser
    {
        private readonly char _separator;

        public Parser()
        {
            _separator = ',';
        }

        public Employee ParseEmployee(string employeeDetails)
        {
            var fields = employeeDetails.Split(_separator);

            return new Employee
            {
                FirstName = fields[0],
                LastName = fields[1],
                AnnualSalary = int.Parse(fields[2]),
                SuperRate = ParseSuper(fields[3]),
                PaymentStartDate = fields[4],
            };
        }

        internal double ParseSuper(string superField)
        {
            return double.Parse(superField.TrimEnd('%')) / 100;
        }
    }
}