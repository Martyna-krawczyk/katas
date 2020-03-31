using System;
using System.Linq;
using System.Text;
namespace FoundationalPayslip
{
    public class Payslip
    {
        public Payslip(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

    } 
}



