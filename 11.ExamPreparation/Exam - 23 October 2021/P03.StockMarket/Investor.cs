using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
            this.Portfolio = new List<Stock>();
        }

        public List<Stock> Portfolio { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }
        public int Count => this.Portfolio.Count;

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && this.MoneyToInvest >= stock.PricePerShare)
            {
                this.MoneyToInvest -= stock.PricePerShare;
                this.Portfolio.Add(stock);
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            Stock stock = this.Portfolio.FirstOrDefault(s => s.CompanyName == companyName);

            if (stock == null)
            {
                return $"{companyName} does not exist.";
            }


            else if (sellPrice < stock.PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }

            this.Portfolio.Remove(stock);
            this.MoneyToInvest += sellPrice;
            return $"{companyName} was sold.";
        }

        public Stock FindStock(string companyName) => this.Portfolio.FirstOrDefault(s => s.CompanyName == companyName);

        public Stock FindBiggestCompany() => this.Portfolio.OrderByDescending(s => s.MarketCapitalization).FirstOrDefault();

        public string InvestorInformation()
        {
            StringBuilder InvestitorInfo = new StringBuilder();

            InvestitorInfo.AppendLine($"The investor {this.FullName} with a broker {this.BrokerName} has stocks:");
            foreach (Stock stock in this.Portfolio)
            {
                InvestitorInfo.AppendLine(stock.ToString());
            }

            return InvestitorInfo.ToString().TrimEnd();
        }
    }
}
