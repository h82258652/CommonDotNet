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
