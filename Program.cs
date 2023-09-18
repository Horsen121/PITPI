using task4.Repository;

namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new PtpippContext();
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
                            Console.WriteLine($"{item.Id}: {item.Name}");
                        }
                        Console.WriteLine();
                        break;

                    case "2":
                        foreach (var item in memberRepo.GetAll())
                        {
                            Console.WriteLine($"{item.Fio}: {item.Sport.Name}");
                        }
                        Console.WriteLine();
                        break;

                    case "3":
                        Console.WriteLine("Введите ФИО ученика:");
                        string member = Console.ReadLine();
                        Console.WriteLine("Выберете желаемую секцию (id):");
                        foreach (var item in sportRepo.GetAll())
                        {
                            Console.WriteLine($"{item.Id}: {item.Name}");
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
                            Console.WriteLine($"{item.Id}: {item.Name}");
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
