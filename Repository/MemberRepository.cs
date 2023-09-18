using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using task3.Models;

namespace task3.Repository
{
    class MemberRepository: IMemberRepository
    {
        public Db _db;

        public MemberRepository(Db db)
        {
            _db = db;
        }

        public IIncludableQueryable<Member, Sport> GetAll()
        {
            return _db.Members.Include(m => m.sport);
        }

        public void Add(string fio, int sport_id)
        {
            Sport sport = _db.Sports.Find(sport_id);
            if (sport != null)
            {
                Member member = new Member();
                member.sport = sport;
                member.fio = fio;
                _db.Members.Add(member);
                _db.SaveChanges();
            }
        }

        public void Edit(string fio, int sport_id)
        {
            Member member = _db.Members.FirstOrDefault(m => m.fio == fio);
            if (member != null)
            {
                Sport sport = _db.Sports.FirstOrDefault(s => s.id == sport_id);
                if (sport != null)
                {
                    member.sport = sport;
                    _db.SaveChanges();
                }
            }
        }

        public void Delete(string fio)
        {
            Member member = _db.Members.FirstOrDefault(m => m.fio == fio);
            if (member != null)
            {
                _db.Members.Remove(member);
                _db.SaveChanges();
            }
        }
    }
}
