using PayslipGenerator2.Structures;

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

            var firstName = fields[0];
            var lastName = fields[1];
            var income = int.Parse(fields[2]);
            var super = ParseSuper(fields[3]);
            var date = fields[4];

            return new Employee(firstName, lastName, income, super, date);
        }

        internal double ParseSuper(string superField)
        {
            return double.Parse(superField.TrimEnd('%')) / 100;
        }
    }
}