using System;
using System.Text;

namespace Task2
{
    class NumCheck
    {
        public delegate void NumDelegate(int number);
        public event NumDelegate NumEvent;

        public void Check()
        {
            Console.WriteLine("\nВведите '1' для сортировки от А до Я или '2' для сортировки от Я до А ('3' - завершит программу)\n");

            int num = Convert.ToInt32(Console.ReadLine());

            if (num != 1 && num != 2 && num != 3)
            {
                throw new FormatException();
            }

            Proceed(num);
        }

        protected virtual void Proceed(int num)
        {
            NumEvent?.Invoke(num);
        }
    }
}
