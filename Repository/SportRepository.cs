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
            using (var query = _conn.CreateCommand())
            {
                query.CommandText = "select id, name from sport";
                var reader = query.ExecuteReader();
                while (reader.Read())
                {
                    res.Add(
                        new Sport
                        {
                            id = reader.GetInt32(reader.GetOrdinal("id")),
                            name = reader.GetString(reader.GetOrdinal("name"))
                        }
                    );
                }
            }
            _conn.Close();

            return res;
        }
    }
}
