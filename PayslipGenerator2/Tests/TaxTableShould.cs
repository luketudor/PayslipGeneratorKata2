using NUnit.Framework;

namespace PayslipGenerator2.Tests
{
    [TestFixture]
    public class TaxTableShould
    {
        [TestCase(0, 0)]
        [TestCase(60050, 11063.25)]
        [Test]
        public void CalculateAnnualIncomeTax(double annualSalary, double expectedTax)
        {
            var actualTax = new TaxTable().AnnualIncomeTax(annualSalary);

            Assert.AreEqual(expectedTax, actualTax);
        }
    }
}