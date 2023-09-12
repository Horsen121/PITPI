using task2.Models;
using Npgsql;
using System.Collections.Generic;

namespace task2.Repository
{
    class MemberRepository: IMemberRepository
    {
        private NpgsqlConnection _conn;
        public MemberRepository(string conn)
        {
            _conn = new NpgsqlConnection(conn);
        }

        public IList<Member> GetAll()
        {
            var res = new List<Member>();

            _conn.Open();
            res = (List<Member>)_conn.Query<Member>("select id, fio, sport_id from member");
            _conn.Close();

            return res;
        }

        public void Add(string fio, int sport)
        {
            _conn.Open();
            using (var command = _conn.CreateCommand())
            {
                command.CommandText = "insert into member(fio, sport_id) values(@member, @sport)";
                command.Parameters.AddWithValue("@member", fio);
                command.Parameters.AddWithValue("@sport", sport);
                command.ExecuteNonQuery();
            }
            _conn.Close();
        }

        public void Edit(string fio, int sport)
        {
            _conn.Open();
            using (var command = _conn.CreateCommand())
            {
                command.CommandText = "update member set sport_id=@sport where fio=@fio";
                command.Parameters.AddWithValue("@sport", sport);
                command.Parameters.AddWithValue("@fio", fio);
                command.ExecuteNonQuery();
            }
            _conn.Close();
        }

        public void Delete(string fio)
        {
            _conn.Open();
            using (var command = _conn.CreateCommand())
            {
                command.CommandText = "delete from member where fio=@fio";
                command.Parameters.AddWithValue("@fio", fio);
                command.ExecuteNonQuery();
            }
            _conn.Close();
        }
    }
}
