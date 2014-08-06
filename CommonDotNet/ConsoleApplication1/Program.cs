using System.Linq;
using System.Reflection;
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
    var s=       (string) typeof (Environment).GetMethod("GetResourceString", BindingFlags.Static | BindingFlags.NonPublic, null,
                new[] { typeof(string) }, null).Invoke(null, new object[] { "ArgumentOutOfRange_GenericPositive" });

            Console.WriteLine(s);
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