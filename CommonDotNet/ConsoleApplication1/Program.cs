using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var m = typeof (Task).GetMethods(BindingFlags.Static | BindingFlags.NonPublic).First(temp => temp.Name ==
                                                                                                         "FromCancellation" &&
                                                                                                         temp
                                                                                                             .IsGenericMethod &&
                                                                                                         temp
                                                                                                             .GetParameters
                                                                                                             ()[0]
                                                                                                             .ParameterType ==
                                                                                                         typeof
                                                                                                             (
                                                                                                             CancellationToken
                                                                                                             ));
            Console.WriteLine(m);
            Console.WriteLine(m.MakeGenericMethod(typeof(int)));

            var xxx =
                typeof (Task).GetMethods(BindingFlags.Static | BindingFlags.NonPublic)
                    .Where(temp => temp.Name == "FromCancellation" && temp.GetParameters()[0].ParameterType == typeof(CancellationToken));
            foreach (var methodInfo in xxx)
            {
                Console.WriteLine(methodInfo.IsGenericMethod);
                Console.WriteLine(methodInfo.IsGenericMethodDefinition);
                Console.WriteLine();
            }


            Console.ReadKey();
        }
    }

}