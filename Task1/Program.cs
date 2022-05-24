using System;
using System.Text;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var exceptions = new Exception[]
            {
                new ArgumentOutOfRangeException(),
                new ArgumentNullException(),
                new DivideByZeroException(),
                new TimeoutException(),
                new MyException("Unexpected bug.")
            };

            foreach (var excep in exceptions)
            {
                try
                {
                    throw excep;
                }
                catch (Exception ex) when (ex is ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Аргумент находится за пределами диапазона допустимых значений! ({0})", ex.GetType());
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex) when (ex is ArgumentNullException)
                {
                    Console.WriteLine("\nАргумент, передаваемый в метод — null! ({0})", ex.GetType());
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex) when (ex is DivideByZeroException)
                {
                    Console.WriteLine("\nЗнаменатель в операции деления или целого числа 'decimal' равен нулю! ({0})", ex.GetType());
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex) when (ex is TimeoutException)
                {
                    Console.WriteLine("\nСрок действия интервала времени, выделенного для операции, истёк! ({0})", ex.GetType());
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex) when (ex is MyException)
                {
                    Console.WriteLine("\nПроизошла ошибка, требующая немедленного исправления! ({0})", ex.GetType());
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.ReadKey();
                }
            }
        }
    }
}
