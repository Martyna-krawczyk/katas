using System;

namespace FoundationalPayslip
{
    public class TaxBracket
    {

        public TaxBracket(int maxLimit, int minimumTaxable, double rate)
        {
            MaxLimit = maxLimit;
            MinimumTaxable = minimumTaxable;
            Rate = rate;
        }

        public int MaxLimit { get; set; }

        public int MinimumTaxable { get; set; }

        public double Rate { get; set; }

    }
    
}
