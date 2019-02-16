using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;

namespace AccountingTests
{
    [TestClass]
    public class AccountingTests
    {
        [TestMethod]
        public void NoData()
        {
            var budgetRepo = Substitute.For<IBudgetRepo>();
            budgetRepo.GetAll().Returns(new List<Budget>());
            Accounting accounting = new Accounting(budgetRepo);

            var actual = accounting.TotalAmount(
                new DateTime(2019, 1, 1),
                new DateTime(2019, 1, 1));
            Assert.AreEqual(0, actual);
        }
    }
}