using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Lab02
{
    [TestClass]
    public class AccountTests
    {
        [TestMethod]
        public void no_budgets()
        {
            var accounting = new Accounting();
            var totalAmount = accounting.TotalAmount(new DateTime(2019, 4, 1), new DateTime(2019, 4, 1));
            Assert.AreEqual(0, totalAmount);
        }
    }
}