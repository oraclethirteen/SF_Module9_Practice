using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    class Program
    {
        static List<Human> humansList = GetList();

        static void Main(string[] args)
        {
            Console.WriteLine("\t***СОРТИРОВЩИК ФАМИЛИЙ***");

            NumCheck numCheck = new NumCheck();
            numCheck.NumEvent += Sort;

            HumansShow(humansList);

            while (true)
            {
                try
                {
                    numCheck.Check();
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nНекорректное значение!\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        static List<Human> GetList()
        {
            List<Human> humans = new List<Human>();

            humans.Add(new Human() { SecondName = "Иванов" });
            humans.Add(new Human() { SecondName = "Петров" });
            humans.Add(new Human() { SecondName = "Сидоров" });
            humans.Add(new Human() { SecondName = "Котёночкин" });
            humans.Add(new Human() { SecondName = "Васнецов" });

            return humans;
        }

        static void Sort(int num)
        {
            switch (num)
            {
                case 1:
                    HumansShow(SortAZ(humansList));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nСписок отсортирован! (от А до Я)");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 2:
                    HumansShow(SortZA(humansList));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nСписок отсортирован! (от Я до А)");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Необходимо ввести нужную цифру!");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }

        static void HumansShow(List<Human> humans)
        {
            Console.WriteLine("\nСписок фамилий:\n");

            foreach (var human in humans)
            {
                Console.WriteLine(human.SecondName);
            }
        }

        static List<Human> SortAZ(List<Human> humans)
        {
            humans.Sort(delegate (Human humanFirst, Human humanSecond)
            {
                return humanFirst.SecondName.CompareTo(humanSecond.SecondName);
            });

            return humans;
        }

        static List<Human> SortZA(List<Human> humans)
        {
            humans.Sort(delegate (Human humanFirst, Human humanSecond)
            {
                return humanSecond.SecondName.CompareTo(humanFirst.SecondName);
            });

            return humans;
        }
    }
}
