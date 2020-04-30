using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using ABC;

namespace ABC
{
    public class UserInputRunner : IUserInputRunner
    {
        readonly Validator validator = new Validator();
        readonly Input input = new Input();
        private readonly IOutput _output;
        public UserInputRunner(IOutput output)
        {
            _output = output;
        }

        public void Welcome()
        {
            _output.OutputText("Welcome to the ABC Word Builder Kata!");
            
        }
        
        public void HandleUserInput()
        {
            _output.OutputText(
                "Would you like to run the default words or your own custom word?\n " +
                "1: DEFAULT\n " +
                "2: CUSTOM\n " +
                "3: EXIT");
        }
        
        public string AskWord()
        {
            string customWord;
            do
            {
                _output.OutputText("Please enter your custom word:");
                customWord = input.InputText().ToUpper();

                if (!validator.ValidWord(customWord)) 
                {
                    _output.OutputText("Sorry, you can only enter letters - please try again.");
                }
            } while (!validator.ValidWord(customWord));

            return customWord;
        }

        public void ContinuePlaying()
        {
            _output.OutputText("Would you like to play again? y/n?");
        }
    }
}