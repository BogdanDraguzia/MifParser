using System;
using System.Text;

namespace MifParser
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var parser = new MyParser();
            parser.Parse();
            Console.ReadKey();
        }
    }
}