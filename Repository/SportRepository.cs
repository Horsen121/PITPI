using Microsoft.EntityFrameworkCore;

namespace task4.Repository
{
    internal class SportRepository: ISportRepository
    {
        public PtpippContext _db;

        public SportRepository(PtpippContext db)
        {
            _db = db;
        }

        public DbSet<Sport> GetAll() {
            return _db.Sports;
        }
    }
}
