namespace PayslipGenerator2.DTO
{
    public struct TaxBracket
    {
        public int LowerBound { set; get; }
        public int UpperBound { set; get; }
        public double Rate { set; get; }
        public int LumpTax { set; get; }
    }
}