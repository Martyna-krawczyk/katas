using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using ABC;

namespace ABC
{
    public class UserInputFromConsole
    {

        Validator validator = new Validator();
        
        public void Welcome()
        {
            Console.WriteLine("Welcome to the ABC Word Builder Kata!");
            
        }
        
        public void HandleUserInput()
        {
            Console.WriteLine(
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
                Console.WriteLine("Please enter your custom word:");
                customWord = Console.ReadLine().ToUpper();

                if (!validator.ValidWord(customWord)) //validator is the instance - using a capital would only be
                                                      //useful on static classes and methods
                {
                    Console.WriteLine("Sorry, you can only enter letters - please try again.");
                }
            } while (!validator.ValidWord(customWord));

            return customWord;
        }

        public void ContinuePlaying()
        {
            Console.WriteLine("Would you like to play again? y/n?");
        }
    }
}