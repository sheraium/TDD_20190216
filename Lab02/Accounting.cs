using System;

namespace Lab02
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
            return 0;
        }
    }
}