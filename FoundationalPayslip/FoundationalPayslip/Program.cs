using System;

namespace FoundationalPayslip
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputValidator = new InputValidator();
            var outputFormatter = new OutputFormatter();
            
            var runner = new PayslipRunner(inputValidator, outputFormatter);
            runner.Run();
        }
    }
}
