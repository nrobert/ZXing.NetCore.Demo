using System;

namespace ManualBuildReleaseConsoleAppDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(ReaderManualBuild.Release.Reader.DecodeMultiple(10));

            Console.WriteLine("Type a key to close");
            Console.ReadKey();
        }
    }
}
