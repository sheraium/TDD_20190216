using System;
using System.Linq;

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
            if (_budgetRepo.GetAll().Any())
            {
                return Days(start, end);
            }
            return 0;
        }

        private static double Days(DateTime start, DateTime end)
        {
            return (end - start).TotalDays + 1;
        }
    }
}