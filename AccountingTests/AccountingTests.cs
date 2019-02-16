using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;

namespace AccountingTests
{
    [TestClass]
    public class AccountingTests
    {
        private Accounting _accounting;

        [TestMethod]
        public void NoData()
        {
            PresetData(new List<Budget>());

            TotalAmountShouldBe(
                new DateTime(2019, 1, 1),
                new DateTime(2019, 1, 1),
                0);
        }

        [TestMethod]
        public void WholeMonth()
        {
            PresetData(new List<Budget>()
            {
                new Budget(){YearMonth = "201901", Amount = 31},
            });

            TotalAmountShouldBe(
                new DateTime(2019, 1, 1),
                new DateTime(2019, 1, 31),
                31);
        }

        private void TotalAmountShouldBe(DateTime start, DateTime end, double expected)
        {
            var actual = _accounting.TotalAmount(
                start,
                end);
            Assert.AreEqual(expected, actual);
        }

        private void PresetData(List<Budget> data)
        {
            var budgetRepo = Substitute.For<IBudgetRepo>();
            budgetRepo.GetAll().Returns(data);
            _accounting = new Accounting(budgetRepo);
        }
    }
}