using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace matrix
{
     class Matrix
    {
        static object locker = new object();

        Random rand;

        const string litters = "QWERTYUIOPASDFGHJKLZXCVBNM0123456789";

        public int Pillar { get; set; }

        public bool Sec { get; set; }

        public Matrix(int pillar, bool Second)
        {
            Pillar = pillar;
            rand = new Random((int)DateTime.Now.Ticks);
            Sec = Second;
        }

        private char GetChar()
        {
            return litters.ToCharArray()[rand.Next(0, 35)];
        }

        public void Move()
        {
            int lenght;
            int count;

            while (true)
            {
                count = rand.Next(4, 20);
                lenght = 0;
                Thread.Sleep(rand.Next(20, 5000));
                for (int i = 0; i < 40; i++)
                {
                    lock (locker)
                    {
                        //  Console.CursorTop = 0;

                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.CursorTop = i - lenght;
                        for (int j = i - lenght - 1; j < i; j++)
                        {
                            Console.CursorLeft = Pillar;
                            Console.WriteLine("в–€");
                        }

                        if (lenght < count)
                            lenght++;
                        else
                            if (lenght == count)
                            count = 0;
                        if (Sec && i < 20 && i > lenght + 2 && (rand.Next(1, 5) == 3))
                        {
                            new Thread((new Matrix(Pillar, false)).Move).Start();
                            Sec = false;
                        }

                        if (39 - i < lenght)
                            lenght--;
                        Console.CursorTop = i - lenght + 1;
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        for (int j = 0; j < lenght - 2; j++)
                        {
                            Console.CursorLeft = Pillar;
                            Console.WriteLine(GetChar());
                        }
                        if (lenght >= 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.CursorLeft = Pillar;
                            Console.WriteLine(GetChar());
                        }
                        if (lenght >= 1)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.CursorLeft = Pillar;
                            Console.WriteLine(GetChar());
                        }

                        Thread.Sleep(15);
                    }
                }
            }
        }
    }

}
