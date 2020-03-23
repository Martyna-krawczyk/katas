using System;

namespace FoundationalPayslip
{
    public interface IValidator
    {
        string ReadName();
        
        string ReadSurname();
        
        DateTime ReadStartDate();
        
        DateTime ReadEndDate();
        
        double ReadSalary();
        
        double ReadSuper();
    }
}