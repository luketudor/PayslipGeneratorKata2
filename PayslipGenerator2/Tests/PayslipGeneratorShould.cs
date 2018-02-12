using System.Runtime.Remoting.Messaging;
using NUnit.Framework;

namespace PayslipGenerator2.Tests
{
    [TestFixture]
    public class PayslipGeneratorShould
    {
        [TestCase("David,Rudd,60050,9%,01 March – 31 March", "David Rudd,01 March – 31 March,5004,922,4082,450")]
        [TestCase("Ryan,Chen,120000,10%,01 March – 31 March", "Ryan Chen,01 March – 31 March,10000,2696,7304,1000")]
        [Test]
        public void PrintPayslip(string employeeDetails, string expectedPayslip)
        {
            var generator = new PayslipGenerator();

            Assert.AreEqual(expectedPayslip, generator.Process(employeeDetails));
        }

        [Test]
        public void CalculateDavidPayslip()
        {
            var david = new Employee("David", "Rudd", 60050, .09, "01 March – 31 March");
            var generator = new PayslipGenerator();

            var expectedPayslip = new Payslip("David Rudd", "01 March – 31 March", 5004, 922, 4082, 450);
            var actualPayslip = generator.MakePayslip(david);

            Assert.AreEqual(expectedPayslip, actualPayslip);
        }

        [Test]
        public void CalculateRyanPayslip()
        {
            var ryan = new Employee("Ryan", "Chen", 120000, .1, "01 March – 31 March");
            var generator = new PayslipGenerator();

            var expectedPayslip = new Payslip("Ryan Chen", "01 March – 31 March", 10000, 2696, 7304, 1000);
            var actualPayslip = generator.MakePayslip(ryan);

            Assert.AreEqual(expectedPayslip, actualPayslip);
        }

        [TestCase(0, 0)]
        [TestCase(60050, 11063.25)]
        [Test]
        public void CalculateAnnualIncomeTax(double annualSalary, double expectedTax)
        {
            var generator = new PayslipGenerator();

            var actualTax = generator.AnnualIncomeTax(annualSalary);

            Assert.AreEqual(expectedTax, actualTax);
        }
    }
}