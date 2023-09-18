using Microsoft.EntityFrameworkCore.Query;
using task3.Models;

namespace task3.Repository
{
    internal interface IMemberRepository
    {
        IIncludableQueryable<Member, Sport> GetAll();
        void Add(string fio, int sport);
        void Delete(string fio);
        void Edit(string fio, int sport);
    }
}
