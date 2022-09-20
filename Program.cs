using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Human> listHuman = new List<Human>();
            Address add1 = new Address("Ukraine", "Kherson", "Vilove", 10);
            listHuman list = new listHuman();

            listTeacher listTeacher = new listTeacher();
            Student st_one = new Student("Olga", "Borisova", 20, 1.78, 65, false, "la@gmail.com", Nation.Ukranian, new Address("Ukraine", "Kherson", "Hover", 20), 241, 3000, Key.csharp);
            Teacher one_th = new Teacher("Viktoria", "Lavrova", 30, 1.83, 65, false, "j@gmail.com", Nation.French, new Address("France", "Paris", "Agrev", 54), 20000, "FKNFM", 2, KeyWords.csharp);
            one_th.add(st_one);
            string choice = null;
            while (choice != "0")
            {
                Console.WriteLine("Оберіть дію ");
                Console.WriteLine("0 - вийти з додатку.");
                Console.WriteLine("1 - роздрукувати всі об'єкти");
                Console.WriteLine("2 - записати список студентів у файл");
                Console.WriteLine("3 - прочитати файл зі списком студентів");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "0":
                        Console.WriteLine("Допобачення!");
                        break;
                    case "1":
                        one_th.show();
                        break;
                    case "2":
                        one_th.write_to_json();
                        break;
                    case "3":
                        one_th.read_from_file();
                        one_th.show();
                        break;

                    default:
                        Console.WriteLine("Ви ввели невірний номер!");
                        break;

                }
            }
            Console.ReadLine();
        }
    }
}
