using System;

namespace ManualBuildDebugConsoleAppDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(ReaderManualBuild.Debug.Reader.DecodeMultiple(10));

            Console.WriteLine("Type a key to close");
            Console.ReadKey();
        }
    }
}
