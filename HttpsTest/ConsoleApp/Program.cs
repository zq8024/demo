using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.DemoServiceClient client = new ServiceReference1.DemoServiceClient();
            string s = client.Hello("bbb");
            Console.WriteLine(s);

            Console.Read();
        }
    }
}
