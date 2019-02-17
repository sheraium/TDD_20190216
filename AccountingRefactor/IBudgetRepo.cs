using System.Collections.Generic;

namespace AccountingRefactor
{
    public interface IBudgetRepo
    {
        IEnumerable<Budget> GetAll();
    }
}