using System;
using Npgsql;

namespace task1
{
    class Program {
        static void Main(string[] args) {
            var connection = new NpgsqlConnection("Host=localhost:5432;Username=postgres;Password=postgres;Database=PTPIPP");

            string action = string.Empty;
            while (action != "6") {
                Console.WriteLine("1. Список всех секций");
                Console.WriteLine("2. Список учеников");
                Console.WriteLine("3. Добавить нового ученика");
                Console.WriteLine("4. Удалить ученика");
                Console.WriteLine("5. Изменить секцию ученика");
                Console.WriteLine("6. Выход\n");

                action = Console.ReadLine();
                switch (action) {
                    case "1":
                        connection.Open();
                        using (var query = connection.CreateCommand()) {
                            query.CommandText = "select id, name from sport";
                            var reader = query.ExecuteReader();
                            while (reader.Read()) {
                                Console.WriteLine(reader["id"] + ": " + reader["name"]);
                            }
                            Console.WriteLine();
                        }
                        connection.Close();
                        break;

                    case "2":
                        connection.Open();
                        using (var query = connection.CreateCommand()) {
                            query.CommandText = "select m.fio as member, s.name as sport from member m join sport s on m.sport_id = s.id";
                            var reader = query.ExecuteReader();
                            while (reader.Read()) {
                                Console.WriteLine(reader["member"] + ": " + reader["sport"]);
                            }
                            Console.WriteLine();
                        }
                        connection.Close();
                        break;

                    case "3":
                        Console.WriteLine("Введите ФИО ученика:");
                        string member = Console.ReadLine();
                        Console.WriteLine("Выберете желаемую секцию (id):");
                        connection.Open();
                        using (var query = connection.CreateCommand()) {
                            query.CommandText = "select id, name from sport";
                            var reader = query.ExecuteReader();
                            while (reader.Read()) {
                                Console.WriteLine(reader["id"] + ": " + reader["name"]);
                            }
                        }
                        connection.Close();
                        int sport = Convert.ToInt32(Console.ReadLine());

                        connection.Open();
                        using (var command = connection.CreateCommand()) {
                            command.CommandText = "insert into member(fio, sport_id) values(@member, @sport)";
                            command.Parameters.AddWithValue("@member", member);
                            command.Parameters.AddWithValue("@sport", sport);
                            command.ExecuteNonQuery();
                            Console.WriteLine("Новый ученик добавлен\n");
                        }
                        connection.Close();
                        break;

                    case "4":
                        Console.WriteLine("Введите ФИО ученика");
                        member = Console.ReadLine();

                        connection.Open();
                        using (var command = connection.CreateCommand()) {
                            command.CommandText = "delete from member where fio=@fio";
                            command.Parameters.AddWithValue("@fio", member);
                            command.ExecuteNonQuery();
                        }
                        Console.WriteLine("Ученик удалён\n");
                        connection.Close();
                        break;

                    case "5":
                        Console.WriteLine("Введите ФИО ученика");
                        member = Console.ReadLine();
                        Console.WriteLine("Выберете желаемую секцию (id):");
                        connection.Open();
                        using (var query = connection.CreateCommand()) {
                            query.CommandText = "select id, name from sport";
                            var reader = query.ExecuteReader();
                            while (reader.Read()) {
                                Console.WriteLine(reader["id"] + ": " + reader["name"]);
                            }
                        }
                        connection.Close();
                        sport = Convert.ToInt32(Console.ReadLine());

                        connection.Open();
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = "update member set sport_id=@sport where fio=@fio";
                            command.Parameters.AddWithValue("@sport", sport);
                            command.Parameters.AddWithValue("@fio", member);
                            command.ExecuteNonQuery();
                        }
                        Console.WriteLine();
                        connection.Close();

                        break;
                }
            }
        }
    }
}
