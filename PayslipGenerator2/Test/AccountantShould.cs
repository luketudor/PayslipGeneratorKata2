using NUnit.Framework;
using PayslipGenerator2.DTO;

namespace PayslipGenerator2.Test
{
    [TestFixture]
    public class AccountantShould
    {
        [Test]
        public void CalculateDavidPayslip()
        {
            var david = new Employee
            {
                FirstName = "David",
                LastName = "Rudd",
                AnnualSalary = 60050,
                SuperRate = .09,
                PaymentStartDate = "01 March – 31 March"
            };

            var expectedPayslip = new Payslip
            {
                Name = "David Rudd",
                PayPeriod = "01 March – 31 March",
                GrossIncome = 5004,
                IncomeTax = 922,
                NetIncome = 4082,
                Super = 450
            };

            var actualPayslip = new Accountant().MakePayslip(david);

            Assert.AreEqual(expectedPayslip, actualPayslip);
        }

        [Test]
        public void CalculateRyanPayslip()
        {
            var ryan = new Employee
            {
                FirstName = "Ryan",
                LastName = "Chen",
                AnnualSalary = 120000,
                SuperRate = .1,
                PaymentStartDate = "01 March – 31 March"
            };

            var expectedPayslip = new Payslip
            {
                Name = "Ryan Chen",
                PayPeriod = "01 March – 31 March",
                GrossIncome = 10000,
                IncomeTax = 2696,
                NetIncome = 7304,
                Super = 1000
            };

            var actualPayslip = new Accountant().MakePayslip(ryan);

            Assert.AreEqual(expectedPayslip, actualPayslip);
        }
    }
}