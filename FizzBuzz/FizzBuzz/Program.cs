using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {

            for (int i = 0; i <= 100; i++)
            {
                //Why won't this print fizzbuzz, but the below one will??

                //if (i % 3 == 0)
                //{
                //    Console.WriteLine("Fizz");
                //}
                //else if (i % 5 == 0)
                //{
                //    Console.WriteLine("Buzz");
                //}
                //else if (i % 3 == 0 && i % 5 == 0)
                //{
                //    Console.WriteLine("FizzBuzz");
                //}
                //else
                //{
                //    Console.WriteLine(i);
                //}

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
            }
        }
    }
}
