using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle
{
    class PuzzleMap
    {
        private int[,] matran;
        public int f;
        public static int n;
        public int[,] Matran
        {
            get
            {
                return matran;
            }

            set
            {
                matran = value;
            }
        }
        public int F
        {
            get
            {
                return f;
            }

            set
            {
                f = value;
            }
        }
        public int N
        {
            get
            {
                return n;
            }

            set
            {
                n = value;
            }
        }
        public PuzzleMap()
        {
            f = 0;
            n = 0;
            matran = new int[n,n];
        }
        public void Input()
        {
            Console.Write("Nhap vao bac cua puzzle : ");
            n = int.Parse(Console.ReadLine());
            matran = new int[n, n];
            for(int i =0;i < n; i++)
            {
                for(int j = 0;j < n; j++)
                {
                    Console.Write("[{0},{1}] : ", i,j);
                    matran[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }
        public void Output()
        {
            Console.WriteLine("Ma tran k : ");
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                    Console.Write(matran[i,j]+ " ");
                Console.WriteLine();
            }
        }
        class Vitri
        {
            public int[,] matrandich;
            public int vtx, vty;
            public int n;
            public Vitri()
            {
                n = 0;
                vtx = 0;
                vty = 0;
                matrandich = new int[n, n];
            }
            public int N { get { return n; } set { n = value; } }
            public int Vtx { get { return vtx; } set { vtx = value; } }
            public int Vty { get { return vty; } set { vty = value; } }
            public int[,] MT_dich { get { return matrandich; } set { matrandich = value; } }
            public void SetUp()
            {
                int so = 0;
                n = PuzzleMap.n;
                matrandich = new int[n, n];
                for(int i = 0; i < n; i++)
                {
                    for(int j = 0; j < n;j++)
                    {
                        if (i == 2 && j == 2)
                            matrandich[i, j] = 0;
                        else
                        {
                            so++;
                            matrandich[i, j] = so;
                        }
                    }
                }
            }
            public void Output()
            {
                Console.WriteLine("Ma tran dich : ");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                        Console.Write(matrandich[i, j] + " ");
                    Console.WriteLine();
                }
            }
            public void FindPosition(int x)
            {
                for(int i = 0; i < n; i++)
                {
                    for(int j =0; j <n; j++)
                    {
                        if(matrandich[i,j] == x)
                        {
                            vtx = i;
                            vty = j;
                            return;
                        }
                    }
                }
            }
        }
        public void CalculateF()
        {
            Vitri vt = new Vitri();
            vt.SetUp();
            vt.Output();
            for (int i = 0; i < n; i++)
            {
                for(int j = 0;j < n; j++)
                {
                    if(matran[i,j] != 0)
                    {
                        vt.FindPosition(matran[i, j]);
                        f += Math.Abs(i - vt.vtx) + Math.Abs(j - vt.vty);
                    }
                }
            }
            Console.WriteLine("F = " + f);
        }
    }
}
