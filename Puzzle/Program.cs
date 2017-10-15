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
            PuzzlList list = new PuzzlList();
            list.CheckAndStorePosition(map);
            Console.WriteLine();
            //list.Output();

            /*
            list.Copy1(map);
            list.test(map);
            */
        }
    }
}
