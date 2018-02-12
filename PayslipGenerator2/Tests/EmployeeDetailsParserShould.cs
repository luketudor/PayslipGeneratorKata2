using NUnit.Framework;

namespace PayslipGenerator2.Tests
{
    [TestFixture]
    public class EmployeeDetailsParserShould
    {
        [Test]
        public void ParseDavidPayslip()
        {
            const string employeeDetails = "David,Rudd,60050,9%,01 March – 31 March";
            var parser = new EmployeeDetailsParser();

            var expectedEmployee = new Employee("David", "Rudd", 60050, 9, "01 March – 31 March");

            Assert.AreEqual(expectedEmployee, parser.CsvParse(employeeDetails));
        }

        [Test]
        public void ParseRyanPayslip()
        {
            const string employeeDetails = "Ryan,Chen,120000,10%,01 March – 31 March";
            var parser = new EmployeeDetailsParser();

            var expectedEmployee = new Employee("Ryan", "Chen", 120000, 10, "01 March – 31 March");

            Assert.AreEqual(expectedEmployee, parser.CsvParse(employeeDetails));
        }
    }
}