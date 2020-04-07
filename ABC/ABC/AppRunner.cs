using System;
using System.Collections.Generic;

namespace ABC
{
    public class AppRunner
    {
        private string[] Words = new[]
        {
            "A",
            "BARK",
            "BOOK",
            "TREAT",
            "COMMON",
            "SQUAD",
            "CONFUSE"
        };

        readonly WordBuilder wordBuilder = new WordBuilder();
        
        public void Run()
        {
            foreach (var word in Words)
            {
                Console.WriteLine("{0} - We {1} spell {2} with our blocks\n",
                wordBuilder.CanBlocksMakeWord(word) ? "True" : "False", wordBuilder.CanBlocksMakeWord(word) ? "can" : "can't", word);
            }
            
            
        }
    }
}