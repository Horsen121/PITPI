using Microsoft.EntityFrameworkCore;
using task3.Models;

namespace task3.Repository
{
    internal class SportRepository: ISportRepository
    {
        public Db _db;

        public SportRepository(Db db)
        {
            _db = db;
        }

        public DbSet<Sport> GetAll() {
            return _db.Sports;
        }
    }
}
