using System.Collections.Generic;
using System.Linq;

namespace Lab02
{
    public class FakeBudgetRepo : IBudgetRepo
    {
        private List<Budget> _budgets;

        public void SetBudgets(params Budget[] budgets)
        {
            _budgets = budgets.ToList();
        }
    }
}