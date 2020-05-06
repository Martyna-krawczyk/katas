using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace ABC
{
    public class AppRunner : IAppRunner
    {
        private readonly WordChecker _wordChecker = new WordChecker();
        private readonly ConsoleInput _input = new ConsoleInput();
        private bool _running = true;
        private string _selection;
        private readonly IOutput _output;
        public AppRunner(IOutput output)
        {
            _output = output;
            
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
            Welcome();
            
            while (_running)
            {
                HandleUserInput();
                _selection = _input.InputText();

                switch (_selection)
                {
                    case "1":
                        RunDefaultWords();
                        break;
                    case "2":
                        RunCustomWord(AskWord());
                        break;
                    case "3":
                        ExitApp();
                        _output.OutputText(Prompts.GoodBye);
                        break;
                }
            }
        }

        private void Welcome()
        {
            _output.OutputText(Prompts.WelcomeMessage);
        }

        private void HandleUserInput()
        {
            _output.OutputText(Prompts.MenuSelections);
        }

        public void ContinuePlaying()
        {
            _output.OutputText(Prompts.ContinuePlaying);
        }
        public string AskWord() 
        {
            string customWord;
            do
            {
                _output.OutputText(Prompts.CustomWord); 
                customWord = _input.InputText().ToUpper();

                if (!Validator.ValidWord(customWord)) 
                {
                    _output.OutputText(Prompts.WordNotValid);
                }
            } while (!Validator.ValidWord(customWord));

            return customWord;
        }
        
        private void ExitApp()
        {
            _running = false;
        }

        private void PlayAgain() 
         {
             ContinuePlaying();
             
             string play = _input.InputText();
             
             if (play != "y")
             {
                 _output.OutputText(Prompts.GoodBye);
                 ExitApp();     
             }
             
         }
        public void RunDefaultWords()
        {
            foreach (var word in _defaultWords)
            {
                _output.OutputText("{0} - We {1} spell {2} with our blocks\n",
                    _wordChecker.CanBlocksMakeWord(word) ? "True" : "False",
                    _wordChecker.CanBlocksMakeWord(word) ? "can" : "can't", word);
            }
            PlayAgain();
        }

        public void RunCustomWord(string customWord)
        {
            _output.OutputText("{0} - We {1} spell {2} with our blocks\n",
                _wordChecker.CanBlocksMakeWord(customWord) ? "True" : "False",
                _wordChecker.CanBlocksMakeWord(customWord) ? "can" : "can't", customWord);
            PlayAgain();
        }
    }
}