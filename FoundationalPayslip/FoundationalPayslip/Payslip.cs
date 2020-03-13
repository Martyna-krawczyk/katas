using System;
using System.Linq;
using System.Text;
namespace FoundationalPayslip
{
    public class Payslip
    {
        public Payslip(string startDate, string endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public string StartDate { get; private set; }
        public string EndDate { get; private set; }

    } 
}



