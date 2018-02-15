using System;
using NUnit.Framework;
using PayslipGenerator2.DTO;

namespace PayslipGenerator2.Test
{
    [TestFixture]
    public class CalculatorShould
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
            var table = new Calculator(new[]
                {
                    new TaxBracket {LowerBound = 0, UpperBound = 18200, Rate = 0, LumpTax = 0},
                    new TaxBracket {LowerBound = 18200, UpperBound = 37000, Rate = .19, LumpTax = 0},
                    new TaxBracket {LowerBound = 37000, UpperBound = 80000, Rate = .325, LumpTax = 3572},
                    new TaxBracket {LowerBound = 80000, UpperBound = 180000, Rate = .37, LumpTax = 17547},
                    new TaxBracket {LowerBound = 180000, UpperBound = int.MaxValue, Rate = .45, LumpTax = 54547},
                },
                12
            );
            var actualTax = table.AnnualIncomeTax(annualSalary);

            Assert.AreEqual(expectedTax, actualTax);
        }

        [Test]
        public void ThrowOnOutOfRangeSalary()
        {
            var table = new Calculator(new[]
                {
                    new TaxBracket {LowerBound = 0, UpperBound = 18200, Rate = 0, LumpTax = 0},
                    new TaxBracket {LowerBound = 18200, UpperBound = 37000, Rate = .19, LumpTax = 0},
                    new TaxBracket {LowerBound = 37000, UpperBound = 80000, Rate = .325, LumpTax = 3572},
                    new TaxBracket {LowerBound = 80000, UpperBound = 180000, Rate = .37, LumpTax = 17547},
                },
                12
            );
            const int annualSalary = 200000;

            Assert.Catch<Exception>(() => table.AnnualIncomeTax(annualSalary));
        }

        [TestCase(60050, 11063.25)]
        [Test]
        public void CalculateTaxForUnorderedBrackets(double annualSalary, double expectedTax)
        {
            var table = new Calculator(new[]
                {
                    new TaxBracket {LowerBound = 37000, UpperBound = 80000, Rate = .325, LumpTax = 3572},
                    new TaxBracket {LowerBound = 180000, UpperBound = int.MaxValue, Rate = .45, LumpTax = 54547},
                    new TaxBracket {LowerBound = 18200, UpperBound = 37000, Rate = .19, LumpTax = 0},
                    new TaxBracket {LowerBound = 80000, UpperBound = 180000, Rate = .37, LumpTax = 17547},
                    new TaxBracket {LowerBound = 0, UpperBound = 18200, Rate = 0, LumpTax = 0},
                },
                12
            );
            var actualTax = table.AnnualIncomeTax(annualSalary);

            Assert.AreEqual(expectedTax, actualTax);
        }
    }
}