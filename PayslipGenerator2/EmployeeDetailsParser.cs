namespace PayslipGenerator2
{
    public class EmployeeDetailsParser
    {
        public Employee CsvParse(string employeeDetails)
        {
            var fields = employeeDetails.Split(',');
            var firstName = fields[0];
            var lastName = fields[1];
            var income = int.Parse(fields[2]);
            var super = int.Parse(fields[3].TrimEnd('%'));
            var date = fields[4];
            return new Employee(firstName, lastName, income, super, date);
        }
    }
}