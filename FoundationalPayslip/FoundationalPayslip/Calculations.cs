using System;

namespace FoundationalPayslip
{
    public class Calculations
    {
            public static  double incomeTax;
            public static int grossIncome;


        public static int returnGrossIncome(int salary)
        {
            grossIncome = salary / 12;
            return grossIncome;
        }


        public static double CalculateIncomeTax(int salary)
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
            return Math.Round(incomeTax, 0, MidpointRounding.AwayFromZero);
        }


        public static int ReturnNetIncome()
        {
            double v = grossIncome - incomeTax;
            int netIncome = (int)v;

            return netIncome;
        }


        public static int CalculateSuper(int grossIncome, int superRate)
        {
            double roundedSuperValue;

            double superValue = (grossIncome * superRate) / 100;

            roundedSuperValue = Math.Round(superValue, 0, MidpointRounding.AwayFromZero);

            return (int)roundedSuperValue;
        }

    }
}
