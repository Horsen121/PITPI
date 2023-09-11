using System.Collections.Generic;
using task2.Models;

namespace task2.Repository
{
    internal interface ISportRepository
    {
        IList<Sport> GetAll();
    }
}
