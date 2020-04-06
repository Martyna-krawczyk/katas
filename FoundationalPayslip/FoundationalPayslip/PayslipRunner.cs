using System;

namespace FoundationalPayslip
{
    public class PayslipRunner
    {
        
        private readonly IFormatter _outputFormatter;
        private readonly InputManager _inputManager;
        
        public PayslipRunner(IFormatter outputFormatter, InputManager inputManager)
        {
            
            _outputFormatter = outputFormatter;
            _inputManager = inputManager;
        }
        
        public void Run()
        {
            var name = _inputManager.AskName();
            var surname = _inputManager.AskSurname();
            double salary = _inputManager.AskSalary();
            double super = _inputManager.AskSuper();
            DateTime startDate = _inputManager.AskStartDate();
            DateTime endDate = _inputManager.AskEndDate();

            Employee employee = new Employee(_outputFormatter.FormatName(name), _outputFormatter.FormatSurname(surname), salary, super);

            Payslip payslip = new Payslip(startDate, endDate);

            _outputFormatter.PrintPayslip(employee, payslip);
        }
    }
}