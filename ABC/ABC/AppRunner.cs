using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace ABC
{
    public class AppRunner : IAppRunner
    {
        private readonly WordBuilder _wordBuilder = new WordBuilder();
        private readonly Input _input = new Input();
        private readonly UserInputRunner _userInputRunner;
        private bool _running = true;
        private string _selection;
        
        private readonly IOutput _output;
        public AppRunner(IOutput output)
        {
            _output = output;
            _userInputRunner = new UserInputRunner(_output);
        }

        private readonly string[] _defaultWords = 
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

            while (_running)
            {
                _selection = _input.InputText();

                switch (_selection)
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

        private void ExitApp()
        {
            _running = false;
        }

        private void PlayAgain() 
         {
             _userInputRunner.ContinuePlaying();
             
             string play = _input.InputText();
            
             if (play != "y")
             {
                 _output.OutputText("Bye");
                 ExitApp();     
             }
             _userInputRunner.HandleUserInput();
         }
        public void RunDefaultWords()
        {
            foreach (var word in _defaultWords)
            {
                _output.OutputText("{0} - We {1} spell {2} with our blocks\n",
                    _wordBuilder.CanBlocksMakeWord(word) ? "True" : "False",
                    _wordBuilder.CanBlocksMakeWord(word) ? "can" : "can't", word);
            }
            PlayAgain();
        }

        public void RunCustomWord(string customWord)
        {
            _output.OutputText("{0} - We {1} spell {2} with our blocks\n",
                _wordBuilder.CanBlocksMakeWord(customWord) ? "True" : "False",
                _wordBuilder.CanBlocksMakeWord(customWord) ? "can" : "can't", customWord);
            PlayAgain();
        }
    }
}