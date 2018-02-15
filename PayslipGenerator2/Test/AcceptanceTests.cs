using NUnit.Framework;

namespace PayslipGenerator2.Test
{
    [TestFixture]
    public class AcceptanceTests
    {
        [TestCase("David,Rudd,60050,9%,01 March – 31 March", "David Rudd,01 March – 31 March,5004,922,4082,450")]
        [TestCase("Ryan,Chen,120000,10%,01 March – 31 March", "Ryan Chen,01 March – 31 March,10000,2696,7304,1000")]
        [Test]
        public void PrintPayslip(string employeeDetails, string expectedPayslip)
        {
            var parser = new Parser();
            var calculator = new Accountant();
            var formatter = new Formatter();

            var employee = parser.ParseEmployee(employeeDetails);
            var payslip = calculator.MakePayslip(employee);
            var actualPayslip = formatter.FormatPayslip(payslip);

            Assert.AreEqual(expectedPayslip, actualPayslip);
        }
    }
}