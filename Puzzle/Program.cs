using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            PuzzleMap map = new PuzzleMap();
            map.Input();
            map.Output();
            map.CalculateF();
        }
    }
}
