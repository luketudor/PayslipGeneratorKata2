using NUnit.Framework;
using PayslipGenerator2.DTO;

namespace PayslipGenerator2.Test
{
    [TestFixture]
    public class ParserShould
    {
        [Test]
        public void ParseDavidPayslip()
        {
            const string employeeDetails = "David,Rudd,60050,9%,01 March – 31 March";
            var parser = new Parser();

            var expectedEmployee = new Employee
            {
                FirstName = "David",
                LastName = "Rudd",
                AnnualSalary = 60050,
                SuperRate = .09,
                PaymentStartDate = "01 March – 31 March"
            };

            Assert.AreEqual(expectedEmployee, parser.ParseEmployee(employeeDetails));
        }

        [Test]
        public void ParseRyanPayslip()
        {
            const string employeeDetails = "Ryan,Chen,120000,10%,01 March – 31 March";
            var parser = new Parser();

            var expectedEmployee = new Employee
            {
                FirstName = "Ryan",
                LastName = "Chen",
                AnnualSalary = 120000,
                SuperRate = .1,
                PaymentStartDate = "01 March – 31 March"
            };

            Assert.AreEqual(expectedEmployee, parser.ParseEmployee(employeeDetails));
        }
    }
}