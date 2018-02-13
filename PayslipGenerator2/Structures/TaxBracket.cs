namespace PayslipGenerator2.Structures
{
    public struct TaxBracket
    {
        public int LowerBound { get; }
        public int UpperBound { get; }
        public double Rate { get; }
        public int LumpTax { get; }

        public TaxBracket(int lowerBound, int upperBound, double rate, int lumpTax)
        {
            UpperBound = upperBound;
            Rate = rate;
            LumpTax = lumpTax;
            LowerBound = lowerBound;
        }
    }
}