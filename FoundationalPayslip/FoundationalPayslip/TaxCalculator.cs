using System.Collections.Generic;

namespace FoundationalPayslip
{
    internal class TaxCalculator
    {


        //reading a lot about the Interface use as per https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.add?view=netframework-4.8

        public int MaxLimit { get; set; }

        public int AddTaxable { get; set; }

        public double CentsPerDollar { get; set; }


        List<TaxBracket> TaxBrackets = new List<TaxBracket>();

        TaxBrackets.Add(new TaxBracket{ MaxLimit = 180000, AddTaxable = 54232, CentsPerDollar = 0.45 });
            //(180000, 54232, 0.45),
        //    (87000, 19822, 0.37),
        //    (37000, 3572, 0.325),
        //    (18200, 1234, 0.19)
        

        public object TaxBrackets { get => taxBrackets; set => taxBrackets = value; }


}
}