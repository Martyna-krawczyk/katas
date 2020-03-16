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

        public static List<TaxBracket> TaxBrackets = new List<TaxBracket>()
        {
            new TaxBracket(180000, 54232, 0.45),
            new TaxBracket(87000, 19822, 0.37),
            new TaxBracket(37000, 3572, 0.325),
            new TaxBracket(18200, 0, 0.19)
        };

        public static double CalculateIncomeTax(double salary)
        {

            if (salary > TaxBrackets[0].MaxLimit)
            {
                incomeTax = (TaxBrackets[0].MinimumTaxable + (salary - TaxBrackets[0].MaxLimit) * TaxBrackets[0].Rate) / 12;
            }
            else if (salary > TaxBrackets[1].MaxLimit && salary <= TaxBrackets[0].MaxLimit)
            {
                incomeTax = (TaxBrackets[1].MinimumTaxable + (salary - TaxBrackets[1].MaxLimit) * TaxBrackets[1].Rate) / 12;
            }
            else if (salary > TaxBrackets[2].MaxLimit && salary <= TaxBrackets[1].MaxLimit)
            {
                incomeTax = (TaxBrackets[2].MinimumTaxable + (salary - TaxBrackets[2].MaxLimit) * TaxBrackets[2].Rate) / 12;
            }
            else if (salary > TaxBrackets[3].MaxLimit && salary <= TaxBrackets[2].MinimumTaxable)
            {
                incomeTax = (TaxBrackets[3].MinimumTaxable + (salary - TaxBrackets[3].MaxLimit) * TaxBrackets[3].Rate) / 12;
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
