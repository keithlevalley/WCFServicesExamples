using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppServiceWeather.currentWeather;
using System.Xml;

namespace AppServiceWeather
{
    class Program
    {
        static void Main(string[] args)
        {
            currentWeather.ndfdXML weather = new ndfdXML();

            string temp = weather.LatLonListZipCode("49515");

            XmlDocument doc = new XmlDocument();

            doc.LoadXml(temp);

            doc.Save("weather.xml");

            string returnValue = weather.NDFDgenByDayLatLonList((doc.DocumentElement.FirstChild.InnerText), DateTime.Now, "1", "e", "12 hourly");

            doc.LoadXml(returnValue);

            doc.Save("returnWeather.xml");

            XmlNodeList tempNodes = doc.DocumentElement.SelectNodes("data/parameters/temperature/value");

            string high = tempNodes[0].InnerText;

            string low = tempNodes[1].InnerText;

            Console.WriteLine("High for today is {0} degrees Fehrenheit, and low is {1} degrees Fehrenheit", high, low);
            Console.ReadKey(true);
        }
    }
}