using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace ABC
{
    public class AppRunner
    {
        public bool running = true;
        public string selection;
        
        readonly WordBuilder wordBuilder = new WordBuilder();
        readonly UserInputFromConsole userInputFromConsole = new UserInputFromConsole();
        
        private string[] DefaultWords = 
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
            userInputFromConsole.Welcome();
            userInputFromConsole.HandleUserInput();

            while (running)
            {
                selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        RunDefaultWords();
                        break;
                    case "2":
                        RunCustomWord(userInputFromConsole.AskWord());
                        break;
                    case "3":
                        ExitApp();
                        break;
                }
            }
        }

        public void ExitApp()
        {
            running = false;
        }

         public void PlayAgain() 
         {
             userInputFromConsole.ContinuePlaying();
             
             string play = Console.ReadLine();
            
             if (play != "y")
             {
                 Console.WriteLine("Bye");
                 ExitApp();     
             }
             userInputFromConsole.HandleUserInput();
         }
        void RunDefaultWords()
        {
            foreach (var word in DefaultWords)
            {
                Console.WriteLine("{0} - We {1} spell {2} with our blocks\n",
                    wordBuilder.CanBlocksMakeWord(word) ? "True" : "False",
                    wordBuilder.CanBlocksMakeWord(word) ? "can" : "can't", word);
            }
            PlayAgain();
        }

        void RunCustomWord(string customWord)
        {
            Console.WriteLine("{0} - We {1} spell {2} with our blocks\n",
                wordBuilder.CanBlocksMakeWord(customWord) ? "True" : "False",
                wordBuilder.CanBlocksMakeWord(customWord) ? "can" : "can't", customWord);
            PlayAgain();
        }
    }
}