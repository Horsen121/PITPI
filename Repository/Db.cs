using Microsoft.EntityFrameworkCore;
using task3.Models;

namespace task3.Repository
{
    class Db : DbContext
    {
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Member> Members { get; set; }
        private string _conn;

        public Db(string conn) { _conn = conn; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_conn); // "Host=localhost:5432;Username=postgres;Password=postgres;Database=PTPIPP"
        }
    }
}
