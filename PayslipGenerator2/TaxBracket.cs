namespace PayslipGenerator2
{
    public struct TaxBracket
    {
        public int CutOff { get; }
        public double Rate { get; }
        public int LumpTax { get; }

        public TaxBracket(int cutOff, double rate, int lumpTax)
        {
            CutOff = cutOff;
            Rate = rate;
            LumpTax = lumpTax;
        }
    }
}