using System;

namespace PayslipGenerator2
{
    public class Program
    {
        public static void Main(string[] args)
        { 
            while (true)
            {
                var employeeDetails = Console.ReadLine();
                var employee = new Parser().ParseEmployee(employeeDetails);
                var payslip = new Calculator().MakePayslip(employee);
                var formattedPayslip = new Formatter().FormatPayslip(payslip);
                Console.WriteLine(formattedPayslip);
            }
        }
    }
}