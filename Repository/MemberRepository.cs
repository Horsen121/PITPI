using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace task4.Repository
{
    class MemberRepository: IMemberRepository
    {
        public PtpippContext _db;

        public MemberRepository(PtpippContext db)
        {
            _db = db;
        }

        public IIncludableQueryable<Member, Sport> GetAll()
        {
            return _db.Members.Include(m => m.Sport);
        }

        public void Add(string fio, int sport_id)
        {
            Sport sport = _db.Sports.Find(sport_id);
            if (sport != null)
            {
                Member member = new Member();
                member.Sport = sport;
                member.Fio = fio;
                _db.Members.Add(member);
                _db.SaveChanges();
            }
        }

        public void Edit(string fio, int sport_id)
        {
            Member member = _db.Members.FirstOrDefault(m => m.Fio == fio);
            if (member != null)
            {
                Sport sport = _db.Sports.FirstOrDefault(s => s.Id == sport_id);
                if (sport != null)
                {
                    member.Sport = sport;
                    _db.SaveChanges();
                }
            }
        }

        public void Delete(string fio)
        {
            Member member = _db.Members.FirstOrDefault(m => m.Fio == fio);
            if (member != null)
            {
                _db.Members.Remove(member);
                _db.SaveChanges();
            }
        }
    }
}
