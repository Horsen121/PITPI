using task2.Models;
using Npgsql;
using System.Collections.Generic;

namespace task2.Repository
{
    internal class SportRepository: ISportRepository
    {
        private NpgsqlConnection _conn;

        public SportRepository(string conn) {
            _conn = new NpgsqlConnection(conn);
        }

        public IList<Sport> GetAll() {
            var res = new List<Sport>();

            _conn.Open();
            res = (List<Sport>)_conn.Query<Sport>("select id, name from sport");
            _conn.Close();

            return res;
        }
    }
}
