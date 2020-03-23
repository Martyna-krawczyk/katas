using System;

namespace FoundationalPayslip
{
    public class PayslipRunner
    {
        private readonly IValidator _inputValidator;
        private readonly IFormatter _outputFormatter;
        
        public PayslipRunner(IValidator inputValidator, IFormatter outputFormatter)
        {
            _inputValidator = inputValidator;
            _outputFormatter = outputFormatter;
        }
        
        public void Run()
        {
            var name = _inputValidator.ReadName();
            var surname = _inputValidator.ReadSurname();
            double salary = _inputValidator.ReadSalary();
            double super = _inputValidator.ReadSuper();
            DateTime startDate = _inputValidator.ReadStartDate();
            DateTime endDate = _inputValidator.ReadEndDate();

            Employee employee = new Employee(_outputFormatter.FormatName(name), _outputFormatter.FormatSurname(surname), salary, super);

            Payslip payslip = new Payslip(startDate.ToString(), endDate.ToString());

            _outputFormatter.PrintPayslip(employee, payslip);
        }
    }
}