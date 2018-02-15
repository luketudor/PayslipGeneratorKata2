using NUnit.Framework;
using PayslipGenerator2.DTO;

namespace PayslipGenerator2.Test
{
    [TestFixture]
    public class FormatterShould
    {
        [Test]
        public void FormatDavidPayslip()
        {
            var davidPayslip = new Payslip
            {
                Name = "David Rudd",
                PayPeriod = "01 March – 31 March",
                GrossIncome = 5004,
                IncomeTax = 922,
                NetIncome = 4082,
                Super = 450
            };

            const string expectedPayslip = "David Rudd,01 March – 31 March,5004,922,4082,450";
            var actualPayslip = new Formatter().FormatPayslip(davidPayslip);

            Assert.AreEqual(expectedPayslip, actualPayslip);
        }

        [Test]
        public void FormatRyanPayslip()
        {
            var ryanPayslip = new Payslip
            {
                Name = "Ryan Chen",
                PayPeriod = "01 March – 31 March",
                GrossIncome = 10000,
                IncomeTax = 2696,
                NetIncome = 7304,
                Super = 1000
            };

            const string expectedPayslip = "Ryan Chen,01 March – 31 March,10000,2696,7304,1000";
            var actualPayslip = new Formatter().FormatPayslip(ryanPayslip);

            Assert.AreEqual(expectedPayslip, actualPayslip);
        }
    }
}