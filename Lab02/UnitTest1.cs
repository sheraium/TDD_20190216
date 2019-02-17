using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Lab02
{
    [TestClass]
    public class AccountTests
    {
        private Accounting _accounting;
        private FakeBudgetRepo _fakeBudgetRepo;

        [TestInitialize]
        public void TestInit()
        {
            _accounting = new Accounting(_fakeBudgetRepo);
        }

        [TestMethod]
        public void no_budgets()
        {
            TotalAmountShouldBe(0,
                new DateTime(2019, 4, 1),
                 new DateTime(2019, 4, 1));
        }

        [TestMethod]
        public void peroid_inside_budget_month()
        {
            _fakeBudgetRepo = new FakeBudgetRepo();
            _fakeBudgetRepo.SetBudgets(new Budget() { YearMonth = "201904", Amount = 30 });
            TotalAmountShouldBe(1,
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