using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    //class to describe Rover and properties associated with it
    public class Rover: IRover
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Dir { get; set; }
        public List<char> Moves { get; set; }

        //execute set of instructions provided in input
        public void ExecuteMoves()
        {
            //move according to letter specified in instruction
            foreach (var move in Moves)
            {
                switch (move)
                {
                    case 'L':
                        TurnLeft(); break;
                    case 'R':
                        TurnRight(); break;
                    case 'M':
                        MoveForward(); break;
                }
            }
            //add new rover to list of rovers
            Globals.allRovers.Add(this);
        }

        //if instructed to turn left
        private void TurnLeft()
        {
            switch (Dir)
            {
                case "N":
                    Dir = "W"; break; 
                case "W":
                    Dir = "S"; break;
                case "S":
                    Dir = "E"; break;
                case "E":
                    Dir = "N"; break;
            }
        }

        //if instructed to turn right
        private void TurnRight()
        {
            switch (Dir)
            {
                case "N":
                    Dir = "E"; break;
                case "E":
                    Dir = "S"; break;
                case "S":
                    Dir = "W"; break;
                case "W":
                    Dir = "N"; break;
            }
        }

        //if instructed to move forward
        private void MoveForward()
        {
            switch (Dir)
            {
                case "N":
                    if (Y < Globals.maxY && collisionCheck(X, Y + 1, Dir))
                    { Y++; }
                    break;
                case "W":
                    if (X > 0 && collisionCheck(X - 1, Y, Dir))
                    { X--; }
                    break;
                case "S":
                    if (Y > 0 && collisionCheck(X, Y - 1, Dir))
                    { Y--; }
                    break;
                case "E":
                    if (X < Globals.maxX && collisionCheck(X + 1, Y, Dir))
                    { X++; }
                    break;
            }
        }

        //check if any other rover currently placed on the location if so do not perform the move
        public Boolean collisionCheck(int x, int y, string dir)
        {
            if (Globals.allRovers.Any(R => R.X == x && R.Y == y && R.Dir.Equals(dir)))
                return false;
            return true;
        }

    }
}
