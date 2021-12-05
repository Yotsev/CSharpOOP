using System;

namespace SquareRoot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();

            try
            {
                int result = 0;

                if (!(int.TryParse(number, out result)) || result < 0)
                {
                    throw new ArgumentException("Invalid number");
                }

                Console.WriteLine(Math.Pow(result, 2));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye");
            }
        }
    }
}
