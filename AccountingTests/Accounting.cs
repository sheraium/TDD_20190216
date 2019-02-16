using System;
using System.Collections.Generic;
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
            var listOfDays = new Dictionary<DateTime, int>();
            while (start <= end)
            {
                var yearMonth = new DateTime(start.Year, start.Month, 1);
                if (listOfDays.ContainsKey(yearMonth))
                {
                    listOfDays[yearMonth]++;
                }
                else
                {
                    listOfDays.Add(yearMonth, 1);
                }
                start = start.AddDays(1);
            }

            return listOfDays.Sum(d =>
             {
                 var amount = listOfBudgets.FirstOrDefault(b => b.YearMonth == d.Key.ToString("yyyyMM"))?.Amount ?? 0;
                 var rate = (double)d.Value / DateTime.DaysInMonth(d.Key.Year, d.Key.Month);
                 return amount * rate;
             });
        }
    }
}