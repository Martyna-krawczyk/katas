using System;
using System.Collections.Generic;

namespace ABC
{
    public class AppRunner
    {
        public bool running = true;
        
        readonly WordBuilder wordBuilder = new WordBuilder();
        readonly UserInputFromConsole userInputFromConsole = new UserInputFromConsole(); 
        
        private string[] DefaultWords = new[]
        {
            "A",
            "BARK",
            "BOOK",
            "TREAT",
            "COMMON",
            "SQUAD",
            "CONFUSE"
        };


        public void Run()
        {
            userInputFromConsole.Intro();

            while (running)
            {
                var selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        RunDefaultWords();
                        break;
                    case "2":
                        RunCustomWord(userInputFromConsole.AskWord());
                        break;
                    case "3":
                        GameOver();
                        break;
                }

               

             void GameOver()
            {
                running = false;
            }

                
                void RunDefaultWords()
                {
                    foreach (var word in DefaultWords)
                    {
                        Console.WriteLine("{0} - We {1} spell {2} with our blocks\n",
                            wordBuilder.CanBlocksMakeWord(word) ? "True" : "False",
                            wordBuilder.CanBlocksMakeWord(word) ? "can" : "can't", word);
                    }
                    userInputFromConsole.PlayAgain();
                }

                void RunCustomWord(string customWord)
                {
                    Console.WriteLine("{0} - We {1} spell {2} with our blocks\n",
                        wordBuilder.CanBlocksMakeWord(customWord) ? "True" : "False",
                        wordBuilder.CanBlocksMakeWord(customWord) ? "can" : "can't", customWord);
                    userInputFromConsole.PlayAgain();
                }
            }
        }
    }
}