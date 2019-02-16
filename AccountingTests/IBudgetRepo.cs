using System.Collections.Generic;

namespace AccountingTests
{
    public interface IBudgetRepo
    {
        IEnumerable<Budget> GetAll();
    }
}