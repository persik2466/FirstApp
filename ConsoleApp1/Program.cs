using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Прочитать данные пользователя в кортеж
            var (Name, LastName, Age, HasPet, Pets, favcolors) = EnterUser();
            //Вывести данные пользователя на экран
            WriteUser(Name, LastName, Age, HasPet, Pets, favcolors);

            Console.ReadKey();
        }

        //Метод для анкетирования
        static (string Name, string LastName, int Age, bool HasPet, string[] Pets, string[] favcolors) EnterUser()
        {
            (string Name, string LastName, int Age, bool HasPet, string[] Pets, string[] favcolors) User;
            
            string name;
            do
            { 
                Console.WriteLine("Введите имя");
                name = Console.ReadLine();
            } while (!CheckChar(in name));
            User.Name = name;

            do
            {
                Console.WriteLine("Введите фамилию");
                name = Console.ReadLine();
            } while (!CheckChar(in name));
            User.LastName = name;

            //Ввод возраста, пока не введено число
            string age;
            int intage;
            do
            {
                Console.WriteLine("Введите возраст цифрами");
                age = Console.ReadLine();
            } while (!CheckNum(age, out intage));
            User.Age = intage;

            //Наличие животных
            Console.WriteLine("Есть ли у вас животные? Да или Нет");
            var result = Console.ReadLine();
            if (result == "Да")
            {
                User.HasPet = true;
                //Запросить количество животных
                string cntpet;
                int intcntpet;
                do
                {
                    Console.WriteLine("Введите количество животных цифрами");
                    cntpet = Console.ReadLine();
                } while (!CheckNum(cntpet, out intcntpet));
                //вызвать метод, который возвращает имена животных
                Console.WriteLine("Введите клички ваших животных");
                User.Pets = CreateArrayStr(intcntpet);
            }
            else
            {
                User.HasPet = false;
                User.Pets = null;
            }

            //Запросить количество любимых цветов
            string cntcolor;
            int intcntcolor;
            do
            {
                Console.WriteLine("Введите количество любимых цветов цифрами");
                cntcolor = Console.ReadLine();
            } while (!CheckNum(cntcolor, out intcntcolor));
            //вызвать метод, который возвращает любимые цвета
            Console.WriteLine("Введите любимые цвета");
            User.favcolors = CreateArrayStr(intcntcolor);

            return User;
        }

        //Метод для вывода на экран полученных данных
        static void WriteUser(string Name, string LastName, int Age, bool HasPet, string[] Pets, string[] favcolors)
        {
            Console.WriteLine("\n\tДанные пользователя:");
            Console.WriteLine("Ваше имя: {0} \nВаша фамилия: {1} \nВаш возраст: {2}", Name, LastName, Age);
            if (HasPet)
            {
                Console.WriteLine("Ваши животные:");
                foreach (var pet in Pets)
                {
                    Console.WriteLine(pet);
                }
            }
            Console.WriteLine("Ваши любимые цвета:");
            foreach (var color in favcolors)
            {
                Console.WriteLine(color);
            }
        }

        //Метод для проверки ввода числа
        static bool CheckNum(string number, out int corrnumber)
        {
            if (int.TryParse(number, out int intnum))
            {
                if (intnum > 0)
                {
                    corrnumber = intnum;
                    return true;
                }
                else
                {
                    Console.WriteLine("Число должно быть больше нуля!");
                    corrnumber = 0;
                    return false;
                }
            }

            {
                Console.WriteLine("Нужно вводить только цифры!");
                corrnumber = 0;
                return false;
            }
        }

        //Метод для проверки ввода буквы
        static bool CheckChar(in string checkstr)
        {
            bool check = false;
            for (int i = 0; i < checkstr.Length; i++)
            {
                if (checkstr[i] >= 'А' && checkstr[i] <= 'Я' || checkstr[i] >= 'а' && checkstr[i] <= 'я' || checkstr[i] == ' ' || checkstr[i] == '-')
                {
                    check = true;
                }
                else
                {
                    Console.WriteLine("Нужно вводить только буквы!");
                    check = false;
                    break;
                }
            }
            return check;
        }

        //Метод для ввода строковых массивов (имён животных или цветов)
        static string[] CreateArrayStr(int num)
        {
            var result = new string[num];
            for (int i = 0; i < result.Length; i++)
            {
                 result[i] = Console.ReadLine();
            }
            return result;
        }
    }
}
