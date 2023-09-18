using Microsoft.EntityFrameworkCore;

namespace task4.Repository
{
    internal interface ISportRepository
    {
        DbSet<Sport> GetAll();
    }
}
