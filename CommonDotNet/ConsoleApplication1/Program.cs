using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Common.Serialization.Json;
using Newtonsoft.Json;

namespace ConsoleApplication1
{
    class Program
    {

        static void Main(string[] args)
        {
            var test = new Test();
            test.A = 5;
            test.B = "ggggo   aaa";
            test.C = DateTime.Now;
            test.D = new List<double>();
            test.D.Add(2.5);
            test.D.Add(8.6443);

            Console.WriteLine(JsonHelper.SerializeToJson(test));

            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(test));

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
