using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppServiceTimeStamp.dateTimeStamp;

namespace AppServiceTimeStamp
{
    class Program
    {
        static void Main(string[] args)
        {
            dateTimeStamp.Service1 dateTimeService = new Service1();

            string dateTime = dateTimeService.getCurrentDateAndTime();
            Console.WriteLine("The current day and time is: {0}", dateTime);
            Console.ReadKey(true);
        }
    }
}
