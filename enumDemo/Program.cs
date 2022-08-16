using System;

namespace enumDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine($"Hello, {(int)TxSeasons.Spring}");
            Console.WriteLine($"Hello, {TxSeasons.Fall}");
            Console.WriteLine($"Hello, {(int)TxSeasons.LateSpring}");
            Console.WriteLine($"Hello, {TxSeasons.Summer}");

            int x = Convert.ToInt32(TxSeasons.LateSpring) + 1; // ++ does nnot work
            Console.WriteLine($"x is {x}"); // writes 25 incremented by 1

            var t = new int();//
            Console.WriteLine(t);


            List<string> strList = new List<string>();
            strList.Add("Mark ");
            strList.Add("is ");
            strList.Add("a ");
            strList.Add("very ");
            strList.Add("cool ");
            strList.Add("guy ");

            foreach (string str in strList)
            {
                Console.Write($"{str}");
            }
            Console.WriteLine();
            
        }
            
        public enum TxSeasons
        {
            Spring = 23,
            LateSpring,
            Summer = 75,
            MiddleLateSummer = 11,
            ReallyLateSummer = 5,
            Fall = 10,
            Winter = 54
        }
    }
}

