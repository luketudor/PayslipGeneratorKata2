using NUnit.Framework;
using PayslipGenerator2.Structures;

namespace PayslipGenerator2.Tests
{
    [TestFixture]
    public class ParserShould
    {
        [Test]
        public void ParseDavidPayslip()
        {
            const string employeeDetails = "David,Rudd,60050,9%,01 March – 31 March";
            var parser = new Parser();

            var expectedEmployee = new Employee("David", "Rudd", 60050, .09, "01 March – 31 March");

            Assert.AreEqual(expectedEmployee, parser.ParseEmployee(employeeDetails));
        }

        [Test]
        public void ParseRyanPayslip()
        {
            const string employeeDetails = "Ryan,Chen,120000,10%,01 March – 31 March";
            var parser = new Parser();

            var expectedEmployee = new Employee("Ryan", "Chen", 120000, .1, "01 March – 31 March");

            Assert.AreEqual(expectedEmployee, parser.ParseEmployee(employeeDetails));
        }
    }
}