using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace ABC
{
    public class AppRunner : IAppRunner
    {
        readonly WordBuilder wordBuilder = new WordBuilder();
        readonly Input input = new Input();
        private readonly UserInputRunner _userInputRunner;
        public bool running = true;
        public string selection;
        
        private readonly IOutput _output;
        public AppRunner(IOutput output)
        {
            _output = output;
            _userInputRunner = new UserInputRunner(_output);
        }

        private readonly string[] DefaultWords = 
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
            _userInputRunner.Welcome();
            _userInputRunner.HandleUserInput();

            while (running)
            {
                selection = input.InputText();

                switch (selection)
                {
                    case "1":
                        RunDefaultWords();
                        break;
                    case "2":
                        RunCustomWord(_userInputRunner.AskWord());
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
             _userInputRunner.ContinuePlaying();
             
             string play = input.InputText();
            
             if (play != "y")
             {
                 _output.OutputText("Bye");
                 ExitApp();     
             }
             _userInputRunner.HandleUserInput();
         }
        public void RunDefaultWords()
        {
            foreach (var word in DefaultWords)
            {
                _output.OutputText("{0} - We {1} spell {2} with our blocks\n",
                    wordBuilder.CanBlocksMakeWord(word) ? "True" : "False",
                    wordBuilder.CanBlocksMakeWord(word) ? "can" : "can't", word);
            }
            PlayAgain();
        }

        public void RunCustomWord(string customWord)
        {
            _output.OutputText("{0} - We {1} spell {2} with our blocks\n",
                wordBuilder.CanBlocksMakeWord(customWord) ? "True" : "False",
                wordBuilder.CanBlocksMakeWord(customWord) ? "can" : "can't", customWord);
            PlayAgain();
        }
    }
}