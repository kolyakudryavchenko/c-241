using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Text.Json;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Human
{
    public enum KeyWords { csharp, python, java };
    class Teacher : Human
    {
        private int salary;
        private string department;
        private int numofseats;
        private KeyWords keywords;
        private List<Student> list;

        public Teacher() : base()
        {
            list = new List<Student>();
        }
        public Teacher(string name, string surname, int age, double height,
            double weight, bool habbits, string email, Nation nation, Address address, int salary, string department, int numofseats, KeyWords keywords) : base(name, surname,
                age, height, weight, habbits, email, nation, address)
        {
            this.salary = salary;
            this.department = department;
            this.numofseats = numofseats;
            this.keywords = keywords;
            this.list = new List<Student>();
        }
        public void add(Student student)
        {
            if (check_numofset(student.Key.ToString()))
                list.Add(student);
            else
            {
                Console.WriteLine("Місць немає або інтереси не зівпадають!");
            }
        }
        public void show()
        {
            for (int n = 0; n < list.Count(); n++)
                list[n].printInfo();
        }
        public override void printInfo()
        {
            string data =
               base.toStr() + "\n" +
               "Salary: " + this.salary.ToString() + "\n" +
               "Money: " + this.department + "\n" +
                "Number of set: " + this.numofseats.ToString() + "\n" +
                "Key: " + this.keywords.ToString();
            Console.WriteLine(data);
        }
        public void write_to_json()
        {
            for (int i = 0; i < list.Count(); i++)
                File.AppendAllText("Student.json", JsonConvert.SerializeObject(list[i],
              new JsonSerializerSettings { StringEscapeHandling = StringEscapeHandling.EscapeNonAscii }));
        }
        public void read_from_file()
        {
            list.Clear();
            JsonTextReader reader = new JsonTextReader(new StreamReader("Student.json"));
            reader.SupportMultipleContent = true;
            while (true)
            {
                if (!reader.Read())
                {
                    break;
                }
                JsonSerializer serializer = new JsonSerializer();
                Student l = serializer.Deserialize<Student>(reader);
                list.Add(l);
            }
        }
        public void findName(string str)
        {
            for (int n = 0; n < list.Count(); n++)
            {
                if (list[n].Name == str)
                    list[n].printInfo();
                else
                    Console.WriteLine("Об'єкта з такими ініціалами немає в списку!");
            }
        }
        public bool check_numofset(string key)
        {
            bool flag = false;
            if ((list.Count < numofseats) && (key == keywords.ToString()))
                flag = true;
            else
            {
                flag = false;
            }
            return flag;
        }
        public void remove(string name, string surname)
        {
            for (int n = 0; n < list.Count(); n++)
            {
                if ((list[n].Name == name) && (list[n].Surname == surname))
                    list.RemoveAt(n);
            }
            Console.WriteLine("Видалення пройшло успішно!");
        }
        public void inputInfo()
        {
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Surname: ");
            string surname = Console.ReadLine();
            Console.WriteLine("Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Height: ");
            double height = double.Parse(Console.ReadLine());
            Console.WriteLine("Weight: ");
            double weight = double.Parse(Console.ReadLine());
            Console.WriteLine("Habbits: ");
            bool habbits = bool.Parse(Console.ReadLine());
            Console.WriteLine("Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Nation: ");
            Nation nation = (Nation)Enum.Parse(typeof(Nation), Console.ReadLine(), true);
            Address adr = new Address();
            Console.WriteLine("Group: ");
            int group = int.Parse(Console.ReadLine());
            Console.WriteLine("Money: ");
            int money = int.Parse(Console.ReadLine());
            Key key = (Key)Enum.Parse(typeof(Key), Console.ReadLine(), true);
            Student student_one = new Student(name, surname, age, height, weight, habbits, email, nation, adr.inputaddress(), group, money, key);
            add(student_one);
        }
        public int Salary
        {
            get { return salary; }
            set { salary = value; }
        }
        public string Department
        {
            get { return department; }
            set { department = value; }
        }
        public int NumOfSeats
        {
            get { return numofseats; }
            set { numofseats = value; }
        }
        public KeyWords KeyWords
        {
            get { return keywords; }
            set { keywords = value; }
        }
        public List<Student> List
        {
            get { return list; }
            set { list = value; }
        }
    }
}

