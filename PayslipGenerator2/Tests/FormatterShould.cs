using NUnit.Framework;

namespace PayslipGenerator2
{
    [TestFixture]
    public class FormatterShould
    {
        [Test]
        public void FormatDavidPayslip()
        {
            var davidPayslip = new Payslip("David Rudd", "01 March – 31 March", 5004, 922, 4082, 450);

            const string expectedPayslip = "David Rudd,01 March – 31 March,5004,922,4082,450";
            var actualPayslip = new Formatter().FormatPayslip(davidPayslip);

            Assert.AreEqual(expectedPayslip, actualPayslip);
        }

        [Test]
        public void FormatRyanPayslip()
        {
            var ryanPayslip = new Payslip("Ryan Chen", "01 March – 31 March", 10000, 2696, 7304, 1000);

            const string expectedPayslip = "Ryan Chen,01 March – 31 March,10000,2696,7304,1000";
            var actualPayslip = new Formatter().FormatPayslip(ryanPayslip);

            Assert.AreEqual(expectedPayslip, actualPayslip);
        }
    }
}