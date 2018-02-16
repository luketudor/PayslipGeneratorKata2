using System;

namespace PayslipGenerator2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    var employeeDetails = Console.ReadLine();
                    var employee = new Parser().ParseEmployee(employeeDetails);
                    var payslip = new Accountant().MakePayslip(employee);
                    var formattedPayslip = new Formatter().FormatPayslip(payslip);
                    Console.WriteLine(formattedPayslip);
                }
                catch (Exception)
                {
                    Console.Error.WriteLine
                    (
                        @"Input format invalid, Expected: <First name>,<Last name>,<Annual salary>,<Super rate>%,<Payment start date>"
                    );
                }
            }
        }
    }
}