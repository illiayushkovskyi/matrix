using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potoki
{
    internal class Program
    {
        class Rec
        {
            static void Recursij(object x)
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(new string(' ', 10) + (i + 2));

                }
            }

            static void Main()
            {
                ParameterizedThreadStart rec = new ParameterizedThreadStart(Recursij);
                Thread thread = new Thread(rec);
                thread.Start(new Rec());
                Rec.Recursij(5);

            }
        }

    }
}
