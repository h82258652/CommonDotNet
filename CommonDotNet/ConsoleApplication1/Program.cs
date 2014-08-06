using Common.Serialization.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ArraySegment<char> x = new ArraySegment<char>();

            Lazy<int> l = new Lazy<int>(() =>
            {
                return DateTime.Now.Second;
            });
            string s1 = l.SerializeToJson();
            string s2 = JsonConvert.SerializeObject(l);
            Console.WriteLine(s1);
            Console.WriteLine(s2);
            Console.ReadKey();
        }
    }

    public class Test
    {
        public int A
        {
            get;
            set;
        }

        public string B
        {
            get;
            set;
        }

        public DateTime C
        {
            get;
            set;
        }

        public List<double> D
        {
            get;
            set;
        }
    }
}