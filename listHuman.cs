using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human
{
    class listHuman
    {
        private List<Human> listHumans;

        public listHuman()
        {
            listHumans = new List<Human>();
        }
        public void add(Human human)
        {
            listHumans.Add(human);
        }

        public void show()
        {
            for (int n = 0; n < listHumans.Count(); n++)
                listHumans[n].printInfo();
        }
        public string show(int a)
        {
            string data = "";
            for (int n = 0; n < listHumans.Count(); n++)
                data += listHumans[n].toStr();
            return data;
        }
        public void findCountry_Nation(string str)
        {
            for (int n = 0; n < listHumans.Count(); n++)
                if (listHumans[n].Address.Country == str &&
                    listHumans[n].Nation.ToString() == "French")
                    listHumans[n].printInfo();
        }
        public void findName(string str)
        {
            for (int n = 0; n < listHumans.Count(); n++)
            {
                if (listHumans[n].Name == str)
                    listHumans[n].printInfo();
                else
                    Console.WriteLine("Об'єкта з такими ініціалами немає в переліку!");
            }
        }
        public void remove(string name, string surname)
        {
            for (int n = 0; n < listHumans.Count(); n++)
            {
                if ((listHumans[n].Name == name) && (listHumans[n].Surname == surname))
                    listHumans.RemoveAt(n);
            }
            Console.WriteLine("Видалення пройшло успішно!");
        }
        public void average_age()
        {
            int age = 0;
            for (int n = 0; n < listHumans.Count(); n++)
                age += listHumans[n].Age;
            if (listHumans.Count() != 0)
            {
                float result = age / listHumans.Count();
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Список пустий");
            }
        }
        public void show(bool b)
        {
            foreach (Human obj in listHumans)
                obj.printInfo();
        }
        public void sort_surname()
        {
            Human reserv = new Human();
            for (int j = 1; j < listHumans.Count(); j++)
                for (int i = 0; i < listHumans.Count() - 1; i++)
                    if (listHumans[i].Surname[0] > listHumans[i + 1].Surname[0])
                    {
                        reserv = listHumans[i];
                        listHumans[i] = listHumans[i + 1];
                        listHumans[i + 1] = reserv;
                    }
            for (int n = 0; n < listHumans.Count(); n++)
                listHumans[n].printInfo();
        }
    }
}
