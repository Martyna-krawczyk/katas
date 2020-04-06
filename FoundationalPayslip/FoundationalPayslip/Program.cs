using System;

namespace FoundationalPayslip
{
    class Program
    {
        static void Main(string[] args)
        {
            var validator = new Validator();
            var outputFormatter = new OutputFormatter();
            var inputManager = new InputManager(validator);
            
            var runner = new PayslipRunner(outputFormatter, inputManager);
            runner.Run();
        }
    }
}
