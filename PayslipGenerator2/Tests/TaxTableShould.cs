using System;
using NUnit.Framework;
using PayslipGenerator2.Structures;

namespace PayslipGenerator2.Tests
{
    [TestFixture]
    public class TaxTableShould
    {
        [TestCase(0, 0)]
        [TestCase(18200, 0)]
        [TestCase(19000, 152)]
        [TestCase(60050, 11063.25)]
        [TestCase(100000, 24947)]
        [TestCase(200000, 63547)]
        [Test]
        public void CalculateAnnualIncomeTax(double annualSalary, double expectedTax)
        {
            var table = new TaxTable(new[]
                {
                    new TaxBracket(0, 18200, 0, 0),
                    new TaxBracket(18200, 37000, .19, 0),
                    new TaxBracket(37000, 80000, .325, 3572),
                    new TaxBracket(80000, 180000, .37, 17547),
                    new TaxBracket(180000, int.MaxValue, .45, 54547) 
                }
            );
            var actualTax = table.AnnualIncomeTax(annualSalary);

            Assert.AreEqual(expectedTax, actualTax);
        }

        [Test]
        public void ThrowOnOutOfRangeSalary()
        {
            var table = new TaxTable(new[]
                {
                    new TaxBracket(0, 18200, 0, 0),
                    new TaxBracket(18200, 37000, .19, 0),
                    new TaxBracket(37000, 80000, .325, 3572),
                    new TaxBracket(80000, 180000, .37, 17547)
                }
            );
            const int annualSalary = 200000;

            Assert.Catch<Exception>(() => table.AnnualIncomeTax(annualSalary));
        }
    }
}