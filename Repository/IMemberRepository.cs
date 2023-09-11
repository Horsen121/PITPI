using task2.Models;
using System.Collections.Generic;

namespace task2.Repository
{
    internal interface IMemberRepository
    {
        IList<Member> GetAll();
        void Add(string fio, int sport);
        void Delete(string fio);
        void Edit(string fio, int sport);
    }
}
