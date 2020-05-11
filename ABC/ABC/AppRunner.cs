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

        private string AskWord() 
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
        
        public void RunDefaultWords()
        {
            foreach (var word in _defaultWords)
            {
                PrintResultOfDefaultWords(word);
            }
            PlayAgain();
        }

        private void PrintResultOfDefaultWords(string word)
        {
            _output.OutputText(_wordChecker.CanBlocksMakeWord(word)
                ? $"True - We can spell {word} with our blocks"
                : $"False - We can't spell {word} with our blocks");
        }

        public void RunCustomWord(string customWord)
        {
            PrintResultOfCustomWord(customWord);
            PlayAgain();
        }

        private void PrintResultOfCustomWord(string customWord)
        {
            _output.OutputText(_wordChecker.CanBlocksMakeWord(customWord)
                ? $"True - We can spell {customWord} with our blocks"
                : $"False - We can't spell {customWord} with our blocks");
        }

        private void PlayAgain() 
        {
            ContinuePlaying();
             
            var play = _input.InputText();

            if (play == "y") return;
            _output.OutputText(Prompts.GoodBye);
            ExitApp();
        }
        
        private void ContinuePlaying()
        {
            _output.OutputText(Prompts.ContinuePlaying);
        }
        
        private void ExitApp()
        {
            _running = false;
        }
    }
}