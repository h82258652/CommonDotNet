using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Serialization.Json;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string ,int > dict=new Dictionary<string, int>();
            dict.Add("fff",100);
            dict.Add("ggg",2);
            Console.WriteLine(dict.SerializeToJson());
            

            Console.ReadKey();
        }
    }
}
