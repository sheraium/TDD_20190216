using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Lab02
{
    [TestClass]
    public class AccountTests
    {
        private Accounting _accounting = new Accounting();

        [TestMethod]
        public void no_budgets()
        {
            TotalAmountShouldBe(0,
                new DateTime(2019, 4, 1),
                 new DateTime(2019, 4, 1));
        }

        private void TotalAmountShouldBe(int expected, DateTime start, DateTime end)
        {
            var totalAmount = _accounting.TotalAmount(start, end);
            Assert.AreEqual(expected, totalAmount);
        }
    }
}