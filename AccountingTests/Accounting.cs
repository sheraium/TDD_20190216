using System;
using System.Linq;

namespace AccountingTests
{
    public class Accounting
    {
        private readonly IBudgetRepo _budgetRepo;

        public Accounting(IBudgetRepo budgetRepo)
        {
            _budgetRepo = budgetRepo;
        }

        public double TotalAmount(DateTime start, DateTime end)
        {
            var listOfBudgets = _budgetRepo.GetAll();
            var yearMonth = start.ToString("yyyyMM");
            return listOfBudgets.FirstOrDefault(b => b.YearMonth == yearMonth)?.Amount ?? 0;
        }
    }
}