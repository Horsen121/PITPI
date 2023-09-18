using Microsoft.EntityFrameworkCore;
using task3.Repository;

namespace task3
{
    class Program
    {
        const string conn = "Host=localhost:5432;Username=postgres;Password=postgres;Database=PTPIPP";
        static void Main(string[] args)
        {
            Db db = new Db(conn);
            var sportRepo = new SportRepository(db);
            var memberRepo = new MemberRepository(db);

            string action = string.Empty;
            while (action != "6")
            {
                Console.WriteLine("1. Список всех секций");
                Console.WriteLine("2. Список учеников");
                Console.WriteLine("3. Добавить нового ученика");
                Console.WriteLine("4. Удалить ученика");
                Console.WriteLine("5. Изменить секцию ученика");
                Console.WriteLine("6. Выход\n");

                action = Console.ReadLine();
                switch (action)
                {
                    case "1":
                        foreach (var item in sportRepo.GetAll())
                        {
                            Console.WriteLine($"{item.id}: {item.name}");
                        }
                        Console.WriteLine();
                        break;

                    case "2":
                        //var items = db.Members.Include(m => m.sport);
                        foreach (var item in memberRepo.GetAll())
                        {
                            Console.WriteLine($"{item.fio}: {item.sport.name}");
                        }
                        Console.WriteLine();
                        break;

                    case "3":
                        Console.WriteLine("Введите ФИО ученика:");
                        string member = Console.ReadLine();
                        Console.WriteLine("Выберете желаемую секцию (id):");
                        foreach (var item in sportRepo.GetAll())
                        {
                            Console.WriteLine($"{item.id}: {item.name}");
                        }
                        int sport = Convert.ToInt32(Console.ReadLine());

                        memberRepo.Add(member, sport);
                        Console.WriteLine("Ученик добавлен");
                        break;

                    case "4":
                        Console.WriteLine("Введите ФИО ученика");
                        member = Console.ReadLine();
                        memberRepo.Delete(member);
                        Console.WriteLine("Ученик удалён\n");
                        break;

                    case "5":
                        Console.WriteLine("Введите ФИО ученика");
                        member = Console.ReadLine();
                        Console.WriteLine("Выберете желаемую секцию (id):");
                        foreach (var item in sportRepo.GetAll())
                        {
                            Console.WriteLine($"{item.id}: {item.name}");
                        }
                        sport = Convert.ToInt32(Console.ReadLine());

                        memberRepo.Edit(member, sport);
                        Console.WriteLine("Данные ученика изменены");

                        break;
                }
            }
        }
    }
}
