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

        [TestMethod]
        public void NodataInMonth()
        {
            PresetData(new List<Budget>()
            {
                new Budget(){YearMonth = "201902", Amount = 280},
            });

            TotalAmountShouldBe(
                new DateTime(2019, 1, 1),
                new DateTime(2019, 1, 31),
                0);
        }

        [TestMethod]
        public void MultipleDaysInOneMonth()
        {
            PresetData(new List<Budget>()
            {
                new Budget(){YearMonth = "201901", Amount = 31},
            });

            TotalAmountShouldBe(
                new DateTime(2019, 1, 1),
                new DateTime(2019, 1, 10),
                10);
        }

        [TestMethod]
        public void TwoMonths()
        {
            PresetData(new List<Budget>()
            {
                new Budget(){YearMonth = "201901", Amount = 31},
                new Budget(){YearMonth = "201902", Amount = 280},
            });

            TotalAmountShouldBe(
                new DateTime(2019, 1, 31),
                new DateTime(2019, 2, 1),
                11);
        }

        [TestMethod]
        public void OneDay()
        {
            PresetData(new List<Budget>()
            {
                new Budget(){YearMonth = "201901", Amount = 31},
            });

            TotalAmountShouldBe(
                new DateTime(2019, 1, 1),
                new DateTime(2019, 1, 1),
                1);
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