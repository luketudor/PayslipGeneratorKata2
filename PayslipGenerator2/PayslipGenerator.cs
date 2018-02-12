namespace PayslipGenerator2
{
    public class PayslipGenerator
    {
        public string Process(string employeeDetails)
        {
            var parser = new EmployeeDetailsParser();
            var employee = parser.Parse(employeeDetails);
            var payslip = new Calculator().MakePayslip(employee);

            return new Formatter().FormatPayslip(payslip);
        }
    }
}