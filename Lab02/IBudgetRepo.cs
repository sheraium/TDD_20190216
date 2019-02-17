using System.Collections.Generic;

namespace Lab02
{
    public interface IBudgetRepo
    {
        IEnumerable<Budget> GetAll();
    }
}