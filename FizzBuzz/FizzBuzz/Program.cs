using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {

            for (int i = 0; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else
                {
                    Console.WriteLine(i);
                }


                /////
                /// interesting hack

                //if (i % 3 == 0 || i % 5 == 0)
                //{
                //    if (i % 3 == 0)
                //    {
                //        Console.Write("Fizz");
                //    }
                //    if (i % 5 == 0)
                //    {
                //        Console.Write("Buzz");
                //    }
                //    Console.WriteLine();
                //}
                //else
                //{
                //    Console.WriteLine(i);
                //}
            }
        }
    }
}
