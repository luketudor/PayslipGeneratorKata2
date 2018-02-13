using NUnit.Framework;
using PayslipGenerator2.Structures;

namespace PayslipGenerator2.Tests
{
    [TestFixture]
    public class TaxTableShould
    {
        [TestCase(0, 0)]
        [TestCase(19000, 152)]
        [TestCase(60050, 11063.25)]
        [Test]
        public void CalculateAnnualIncomeTax(double annualSalary, double expectedTax)
        {
            var table = new TaxTable(new[]
                {
                    new TaxBracket(18200, 0, 0),
                    new TaxBracket(37000, .19, 0),
                    new TaxBracket(80000, .325, 3572),
                    new TaxBracket(180000, .37, 17547),
                    new TaxBracket(int.MaxValue, .45, 54547) 
                }
            );
            var actualTax = table.AnnualIncomeTax(annualSalary);

            Assert.AreEqual(expectedTax, actualTax);
        }
    }
}