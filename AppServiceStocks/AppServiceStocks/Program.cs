using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppServiceStocks.stockPrice;
using System.Xml;

namespace AppServiceStocks
{
    class Program
    {
        static void Main(string[] args)
        {
            stockPrice.StockQuote stockService = new StockQuote();

            Console.Write("Please enter Stock symbol: ");
            string input = Console.ReadLine();

            string quote = stockService.GetQuote(input.ToUpper()).ToString();

            XmlDocument doc = new XmlDocument();

            doc.LoadXml(quote);

            String temp = doc.DocumentElement.SelectSingleNode("Stock/Last").InnerText;

            doc.Save("quote.xml");

            Console.WriteLine(temp);
            Console.ReadKey(true);
        }
    }
}
