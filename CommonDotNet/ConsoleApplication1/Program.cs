using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
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
            var c = "aaa\aaa";
            Console.WriteLine(c.SerializeToJson());

            Console.ReadKey();
        }
    }

    enum TT
    {
        AA=0
    }

}