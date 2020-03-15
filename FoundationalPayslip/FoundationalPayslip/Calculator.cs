using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoundationalPayslip
{
    public class Calculator
    {
        public static double incomeTax;
        public static double grossIncome;
        //public static List<(int taxLimits, int additionalTaxable, double cents)> TaxBrackets = new List<(int taxLimits, int additionalTaxable, double cents)>
        //{
        //    (180000, 54232, 0.45),
        //    (87000, 19822, 0.37),
        //    (37000, 3572, 0.325),
        //    (18200, 1234, 0.19)
        //};



        public static double CalculateIncomeTax(double salary)
        {

            if (salary > TaxBrackets.taxLimits)
            {
                incomeTax = (54232 + (salary - TaxBrackets[0]) * 0.45) / 12;
            }
            else if (salary > TaxBrackets[0] && salary <= TaxBrackets[1])
            {
                incomeTax = (19822 + (salary - TaxBrackets[1]) * 0.37) / 12;
            }
            else if (salary > TaxBrackets[1] && salary <= TaxBrackets[2])
            {
                incomeTax = (3572 + (salary - TaxBrackets[2]) * 0.325) / 12;
            }
            else if (salary > TaxBrackets[3] && salary <= TaxBrackets[2])
            {
                incomeTax = ((salary - TaxBrackets[2]) * 0.19) / 12;
            }
            else
            {
                incomeTax = 0;
            }
            return incomeTax;
        }

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




        public static double CalculateSuper(double grossIncome, double superRate)
        {
            double superValue = (grossIncome * superRate) / 100;

            return superValue;
        }

    }
}
