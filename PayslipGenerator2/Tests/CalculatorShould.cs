using NUnit.Framework;
using PayslipGenerator2.Structures;

namespace PayslipGenerator2.Tests
{
    [TestFixture]
    public class CalculatorShould
    {
        [Test]
        public void CalculateDavidPayslip()
        {
            var david = new Employee("David", "Rudd", 60050, .09, "01 March – 31 March");

            var expectedPayslip = new Payslip("David Rudd", "01 March – 31 March", 5004, 922, 4082, 450);
            var actualPayslip = new Calculator().MakePayslip(david);

            Assert.AreEqual(expectedPayslip, actualPayslip);
        }

        [Test]
        public void CalculateRyanPayslip()
        {
            var ryan = new Employee("Ryan", "Chen", 120000, .1, "01 March – 31 March");

            var expectedPayslip = new Payslip("Ryan Chen", "01 March – 31 March", 10000, 2696, 7304, 1000);
            var actualPayslip = new Calculator().MakePayslip(ryan);

            Assert.AreEqual(expectedPayslip, actualPayslip);
        }
    }
}