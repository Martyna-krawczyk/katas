﻿using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new ConsoleInput();
            var output = new ConsoleOutput();
            var runner = new AppRunner(input, output);
            runner.Run();
        }
    }
}