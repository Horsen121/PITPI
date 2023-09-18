using Microsoft.EntityFrameworkCore;
using task3.Models;

namespace task3.Repository
{
    internal interface ISportRepository
    {
        DbSet<Sport> GetAll();
    }
}
