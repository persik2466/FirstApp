using System;

namespace ConsoleApp1
{
	class MainClass
	{
		public static void Main(string[] args)
		{

			Console.Write("Введите свое имя: ");
			var name = Console.ReadLine();
			Console.Write("Введите свой возраст: ");
			var age = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Ваше имя {0} и возраст {1} ", name, age);
			Console.Write("Введите свою дату рождения: ");
			var birthdate = Console.ReadLine();
			Console.WriteLine("Ваш день рождения {0} ", birthdate);

			Console.ReadKey();

		}
	}
}
