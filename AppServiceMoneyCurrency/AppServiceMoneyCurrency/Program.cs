using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppServiceMoneyCurrency.currencyConverter;

namespace AppServiceMoneyCurrency
{
    class Program
    {
        static void Main(string[] args)
        {
            currencyConverter.CurrencyConvertor converter = new CurrencyConvertor();

            double temp = converter.ConversionRate(Currency.USD, Currency.CNY);

            Console.Write("Enter value to convert: ");

            try
            {
                double input = double.Parse(Console.ReadLine());
                Console.WriteLine(temp * input);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid value entered");
            }
            
            Console.ReadKey(true);
        }
    }
}
