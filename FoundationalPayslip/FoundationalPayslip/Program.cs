using System;

namespace FoundationalPayslip
{
    class Program
    {
        static void Main(string[] args)
        {
            var validator = new Validator();
            var outputFormatter = new OutputFormatter();
            var inputManager = new InputManager();
            
            var runner = new PayslipRunner(validator, outputFormatter, inputManager);
            runner.Run();
        }
    }
}
