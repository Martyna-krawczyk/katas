using System;

namespace FoundationalPayslip
{
    public class Calculations
    {
        public static double incomeTax;
        public static double grossIncome;

        public static double ReturnNetIncome()
        {
            double netIncome = grossIncome - incomeTax;
            return netIncome;
        }


        public static double ReturnGrossIncome(double salary)
        {
            grossIncome = salary / 12;
            return grossIncome;
        }


        public static double CalculateIncomeTax(double salary)
        {

            if (salary >= 180001)
            {
                incomeTax = (54232 + (salary - 180000) * 0.45) / 12;
            }
            else if (salary >= 87001 && salary <= 180000)
            {
                incomeTax = (19822 + (salary - 87000) * 0.37) / 12;
            }
            else if (salary >= 37001 && salary <= 87000)
            {
                incomeTax = (3572 + (salary - 37000) * 0.325) / 12;
            }
            else if (salary >= 18201 && salary <= 37000)
            {
                incomeTax = ((salary - 18200) * 0.19) / 12;
            }
            else
            {
                incomeTax = 0;
            }
            return incomeTax;
        }


        public static double CalculateSuper(double grossIncome, double superRate)
        {
            double superValue = (grossIncome * superRate) / 100;

            return superValue;
        }

    }
}
