using System;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            //fetching file system path of input file
            Console.WriteLine("Please enter the URL path of the input file");
            var path = Console.ReadLine();

            //processing input passed
            var success = Helper.ProcessInput(path);

            //if input processing failed, exit app
            if (!success)
            {
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
                return;
            }

            //else print output
            Helper.GenerateOutput();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
