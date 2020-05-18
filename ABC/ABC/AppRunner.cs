using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace ABC
{
    public class AppRunner : IAppRunner
    {
        public bool Running { get; private set; } = true;
        private string _selection;
        
        private readonly IInput _input;
        private readonly IOutput _output;
        private readonly IWordChecker _wordChecker;
        public AppRunner(IOutput output, IWordChecker wordChecker, IInput input)
        {
            _output = output;
            _wordChecker = wordChecker;
            _input = input;
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
            _output.OutputText(Prompts.WelcomeMessage);
            
            while (Running)
            {
                _output.OutputText(Prompts.MenuSelections);
                _selection = _input.InputText();

                switch (_selection)
                {
                    case "1":
                        RunWords();
                        PlayAgain();
                        break;
                    case "2":
                        RunWords(AskWord());
                        PlayAgain();
                        break;
                    case "3":
                        ExitApp();
                        _output.OutputText(Prompts.GoodBye);
                        break;
                }
            }
        }

        private void RunWords()
        {
            foreach (var word in _defaultWords)
            {
                RunWords(word);
            }
        }
        
        private void RunWords(string word)
        {
            var result = _wordChecker.CanBlocksMakeWord(word);
            PrintResult(word, result);
        }
        
        private string AskWord() 
        {
            string word;
            do
            {
                _output.OutputText(Prompts.CustomWord); 
                word = _input.InputText().ToUpper();

                if (!Validator.ValidWord(word)) 
                {
                    _output.OutputText(Prompts.WordNotValid);
                }
            } while (!Validator.ValidWord(word));

            return word;
        }

        private void PrintResult(string word, bool result)
        {
            _output.OutputText(string.Format( 
                result ? Prompts.SuccessMessage : Prompts.FailureMessage, word));
        }

        private void PlayAgain() 
        {
            _output.OutputText(Prompts.ContinuePlaying);
             
            var play = _input.InputText();

            if (play == "y") return;
            _output.OutputText(Prompts.GoodBye);
            ExitApp();
        }

        private void ExitApp()
        {
            Running = false;
        }
    }
}