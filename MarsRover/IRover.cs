using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    interface IRover
    {
        int X { get; set; }
        int Y { get; set; }
        string Dir { get; set; }
        List<char> Moves { get; set; }    
    }
}
