using System;

namespace FoundationalPayslip
{
    public class PayslipRunner
    {
        private readonly IValidator _validator;
        private readonly IFormatter _outputFormatter;
        private readonly InputManager _inputManager;
        
        public PayslipRunner(IValidator validator, IFormatter outputFormatter, InputManager inputManager)
        {
            _validator = validator;
            _outputFormatter = outputFormatter;
            _inputManager = inputManager;
        }
        
        public void Run()
        {
            var name = _inputManager.AskName();
            var surname = _inputManager.AskSurname();
            double salary = _validator.ReadSalary();
            double super = _validator.ReadSuper();
            DateTime startDate = _validator.ReadStartDate();
            DateTime endDate = _validator.ReadEndDate();

            Employee employee = new Employee(_outputFormatter.FormatName(name), _outputFormatter.FormatSurname(surname), salary, super);

            Payslip payslip = new Payslip(startDate.ToString(), endDate.ToString());

            _outputFormatter.PrintPayslip(employee, payslip);
        }
    }
}