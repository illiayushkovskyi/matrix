using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rekursia
{
    internal class Program
    {
        static void Miles(object num)
        {
            int number = (int)num;
            if (number <= 0)
                return;
            Thread mile = new Thread(Miles);
            mile.Name = "Mile" + number;
            mile.Start(number - 1);
            Console.WriteLine(mile.Name);
        }
        private static void Main(string[] args)
        {
            Miles(20);
            Console.ReadKey();
        }


    }
}
