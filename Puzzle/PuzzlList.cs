using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle
{
    class PuzzlList
    {
        public int n;
        public int[,] CopyArray;
        private List<PuzzleMap> ds;
        private List<int> dsF;
        public List<PuzzleMap> Ds
        {
            get
            {
                return ds;
            }

            set
            {
                ds = value;
            }
        }
        public List<int> DsF
        {
            get
            {
                return dsF;
            }

            set
            {
                dsF = value;
            }
        }

        public PuzzlList()
        {
            n = PuzzleMap.n;
            CopyArray = new int[n, n];
            DsF = new List<int>();
            ds = new List<PuzzleMap>();
        }
        public void AddItem(PuzzleMap mapk)
        {
            ds.Add(mapk);
           // mapk.CalculateF();
            //dsF.Add(mapk.f);
        }
        public void Output()
        {
            foreach(var item in ds)
            {
                item.Output();
            }
        }
        #region Tinh Toan
        public void IsThisMin(int x)
        {

        }
        public void FindMinF()
        {
            foreach(var item in ds)
            {

            }
        }
        #endregion

        

        public void CheckAndStorePosition(PuzzleMap map)
        {
            // Xác định vị trí khoảng trống để tìm ...
            map.FindTheNullPosition();
            int vtx = map.VTX; // luu lai vi tri x cua khoang trong
            int vty = map.VTY; // luu lai vi tri y cua khoang trong
            int n = map.N;
            
            if ((vtx == n - 1 || vtx == 0) && (vty == n - 1 || vty == 0))
            {
                Console.WriteLine("Corner !");
            }
            else if ((vtx > 0 && vtx < n - 1) && (vty > 0 && vty < n - 1))
                Console.WriteLine("Center !");
            else
            {
                Console.WriteLine("Side !");
                ExchangeLeft(map, vtx, vty);
                ExchangeTop(map, vtx, vty);
            }
        }
        
        public void Copy(PuzzleMap map)
        {
            for (int i = 0; i < CopyArray.GetLength(0); i++)
            {
                for (int j = 0; j < CopyArray.GetLength(1); j++)
                    CopyArray[i, j] = map.Matran[i, j];
            }
        }
        public void ReverseCopy(PuzzleMap map)
        {
            for (int i = 0; i < CopyArray.GetLength(0); i++)
            {
                for (int j = 0; j < CopyArray.GetLength(1); j++)
                    map.Matran[i, j] = CopyArray[i, j];
            }
        }
        public void CopyArray_out()
        {
            Console.WriteLine("OUT OF COPYARRAY : ");
            for (int i = 0; i < CopyArray.GetLength(0); i++)
            {
                for (int j = 0; j < CopyArray.GetLength(1); j++)
                    Console.Write(CopyArray[i, j] + " ");
                Console.WriteLine();
            }
        }
        public void ExchangeLeft(PuzzleMap map, int vtx, int vty)
        {
            Copy(map);
            for(int i = 0; i < map.Matran.GetLength(0); i++)
            {
                for(int j = 0; j < map.Matran.GetLength(1); j++)
                {
                    if(i == vtx && j == vty)
                    {
                        int tam = map.Matran[i, j];
                        map.Matran[i, j] = map.Matran[i, j - 1];
                        map.Matran[i, j - 1] = tam;
                    }
                }
            }
            Console.WriteLine("MOVE LEFT : ");
            map.Output();
            AddItem(map);
            ReverseCopy(map);
        }
        public void ExchangeTop(PuzzleMap map, int vtx, int vty)
        {
            Copy(map);
            
            for(int i = 0; i< map.Matran.GetLength(0); i++)
            {
                for(int j = 0; j< map.Matran.GetLength(1); j++)
                {
                    if (i == vtx && j == vty)
                    {
                        int tam = map.Matran[i, j];
                        map.Matran[i, j] = map.Matran[i - 1, j];
                        map.Matran[i - 1, j] = tam;
                    }
                }
            }
            Console.WriteLine("MOVE TOP : ");
            map.Output();
            AddItem(map);
            ReverseCopy(map);
        }

















        #region test / debug / draft / ...
        
        public int[,] NewArray = new int[3, 3];
        public void Copy1(PuzzleMap map)
        {
            for (int i = 0; i < NewArray.GetLength(0); i++)
            {
                for (int j = 0; j < NewArray.GetLength(1); j++)
                    NewArray[i, j] = map.Matran[i, j];
            }
        }
        public void test(PuzzleMap map)
        {
            Copy1(map);
            for (int i = 0; i < NewArray.GetLength(0); i++)
            {
                for (int j = 0; j < NewArray.GetLength(1); j++)
                    Console.Write(NewArray[i,j]+" ");
                Console.WriteLine();
            }
            Console.WriteLine();
            //////////////////////////////////////////////////////////////////
            for (int i = 0; i < map.Matran.GetLength(0); i++)
            {
                for (int j = 0; j < map.Matran.GetLength(1); j++)
                {
                    if(i == 1 && j == 2)
                    {
                        int tam = map.Matran[i, j];
                        map.Matran[i, j] = map.Matran[i - 1, j];
                        map.Matran[i - 1, j] = tam;
                    }
                }
            }
            for (int i = 0; i < map.Matran.GetLength(0); i++)
            {
                for (int j = 0; j < map.Matran.GetLength(1); j++)
                    Console.Write(map.Matran[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();


            //////////////////////////////////////////////////////////////////
            
            map.Matran = NewArray;
            for (int i = 0; i < map.Matran.GetLength(0); i++)
            {
                for (int j = 0; j < map.Matran.GetLength(1); j++)
                    Console.Write(map.Matran[i, j] + " ");
                Console.WriteLine();
            }
        }

        /*
       
        
        public void Out() { 
            Console.WriteLine("Debug : " );
            for (int i = 0; i < NewArray.GetLength(0); i++)
            {
                for (int j = 0; j < NewArray.GetLength(1); j++)
                    Console.Write(NewArray[i,j]+" ");
                Console.WriteLine();
            }
        }

        public void Trans(PuzzleMap map, int vtx, int vty)
        {
            PuzzleMap tmp = map;
            for (int i = 0; i < tmp.Matran.GetLength(0); i++)
            {
                for (int j = 0; j < tmp.Matran.GetLength(1); j++)
                {
                    if (i == vtx && j == vty)
                    {
                        int tam = tmp.Matran[i, j];
                        tmp.Matran[i, j] = tmp.Matran[i - 1, j];
                        tmp.Matran[i - 1, j] = tam;
                    }
                }
            }
            for(int i = 0;i< tmp.Matran.GetLength(0);i++)
            {
                for (int j = 0; j < tmp.Matran.GetLength(1); j++)
                    Console.Write(tmp.Matran[i,j]+ " ");
                Console.WriteLine();
            }
        }
        */
        #endregion
    }
}
