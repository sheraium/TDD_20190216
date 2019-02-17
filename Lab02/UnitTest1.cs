using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Lab02
{
    [TestClass]
    public class UnitTest1
    {
        private Accounting accounting = new Accounting();

        [TestMethod]
        public void No_budget()
        {
            TotalAmountShouldBe(0,
                new DateTime(2019, 4, 1),
                new DateTime(2019, 4, 1));
        }

        private void TotalAmountShouldBe(int expected, DateTime start, DateTime end)
        {
            Assert.AreEqual(expected, accounting.TotalAmount(
                start,
                end));
        }
    }
}