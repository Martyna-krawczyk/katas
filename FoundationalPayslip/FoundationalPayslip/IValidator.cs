using System;

namespace FoundationalPayslip
{
    public interface IValidator
    {
        DateTime ReadStartDate();
        
        DateTime ReadEndDate();
        
        double ReadSalary();
        
        double ReadSuper();
    }
}