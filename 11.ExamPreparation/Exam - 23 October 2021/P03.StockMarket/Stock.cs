using System;

namespace StockMarket
{
    public class Stock
    {
        public Stock(string companyName, string director, decimal pricePerShare, int totalNumberOfShares)
        {
            this.CompanyName = companyName;
            this.Director = director;
            this.PricePerShare = pricePerShare;
            this.TotalNumberOfShares = totalNumberOfShares;
            this.MarketCapitalization = pricePerShare * totalNumberOfShares;
        }

        public string CompanyName { get; set; }

        public string Director { get; set; }

        public decimal PricePerShare { get; set; }

        public int TotalNumberOfShares { get; set; }

        public decimal MarketCapitalization { get; set; }

        public override string ToString()
        {
            return $"Company: {CompanyName}{Environment.NewLine}" +
                   $"Director: { Director}{Environment.NewLine}" +
                   $"Price per share: ${ PricePerShare}{Environment.NewLine}" +
                   $"Market capitalization: ${ MarketCapitalization}";
        }
    }
}
