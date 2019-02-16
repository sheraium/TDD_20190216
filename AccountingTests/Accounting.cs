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
            var listOfDays = GetDaysOfYearMonthes(start, end);
            return listOfDays.Sum(d => { return CalculateAmount(listOfBudgets, d); });
        }

        private static double CalculateAmount(IEnumerable<Budget> listOfBudgets, KeyValuePair<DateTime, int> d)
        {
            var amount = listOfBudgets.FirstOrDefault(b => b.YearMonth == d.Key.ToString("yyyyMM"))?.Amount ?? 0;
            var rate = (double)d.Value / DateTime.DaysInMonth(d.Key.Year, d.Key.Month);
            return amount * rate;
        }

        private static Dictionary<DateTime, int> GetDaysOfYearMonthes(DateTime start, DateTime end)
        {
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

            return listOfDays;
        }
    }
}