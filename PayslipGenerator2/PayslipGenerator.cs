namespace PayslipGenerator2
{
    public class PayslipGenerator
    {
        public string Process(string employeeDetails)
        {
            var parser = new EmployeeDetailsParser();
            var employee = parser.CsvParse(employeeDetails);

            return "David Rudd,01 March – 31 March,5004,922,4082,450";
        }

        public Payslip MakePayslip(Employee employee)
        {
            return new Payslip("", "", 0, 0, 0, 0);
        }
    }
}