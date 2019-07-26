using System;

namespace NugetConsoleAppDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(ReaderNuget.Reader.DecodeMultiple(10));

            Console.WriteLine("Type a key to close");
            Console.ReadKey();
        }
    }
}
