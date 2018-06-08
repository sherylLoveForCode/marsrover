using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using static MarsRover.Globals;

namespace MarsRover
{
     internal class Helper
    {
        public static readonly List<string> directions = new List<string> { "N", "E", "W", "S" };
        public static readonly List<char> allowedMoves = new List<char> { 'L', 'R', 'M' };

        //processing input by parsing text in file
        public static Boolean ProcessInput(string path)
        {
            string[] input = File.ReadAllLines(path);

            //get size of the land
            maxX = Convert.ToInt32(input[0].Split(' ')[0]);
            maxY = Convert.ToInt32(input[0].Split(' ')[1]);

            //assign values for rover
            for (int i = 1; i < input.Length; i = i + 2)
            {
                Rover newRov = new Rover()
                {
                    X = Convert.ToInt32(input[i].Split(' ')[0]),
                    Y = Convert.ToInt32(input[i].Split(' ')[1]),
                    Dir = input[i].Split(' ')[2],
                    Moves = input[i + 1].ToList()
                };
                if (!ValidateInput(newRov))
                {
                    return false;
                }
                newRov.ExecuteMoves();
            }
            return true;
        }

        //validate user input
        private static Boolean ValidateInput(Rover newRov)
        {
            //check if the input given is wrong
            if (newRov.X > maxX | newRov.X < 0 |
                newRov.Y > maxY | newRov.Y < 0 |
                !directions.Any(d => d.Equals(newRov.Dir)) |
                !newRov.collisionCheck(newRov.X, newRov.Y, newRov.Dir))
            {
                Console.WriteLine("Invalid Input!");
                return false;
            }
            foreach (var m in newRov.Moves)
            {
                if (!allowedMoves.Any(x => x.Equals(m)))
                {
                    Console.WriteLine("Invalid Input!");
                    return false;
                }
            }
            return true;
        }
        
        //output final positions of the rovers
        public static void GenerateOutput()
        {
            foreach (var rov in allRovers)
            {
                Console.WriteLine(rov.X + " " + rov.Y + " " + rov.Dir + "\n");
            }
        }
    }
}
