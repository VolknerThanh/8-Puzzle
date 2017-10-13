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
                int so = 0;       // dùng để chạy số từ 0 -> n * n - 1
                n = PuzzleMap.n;  // lấy số bậc của puzzle k
                matrandich = new int[n, n];
                for(int i = 0; i < n; i++)
                {
                    for(int j = 0; j < n;j++)
                    {
                        if (i == 2 && j == 2)      // phần tử cuối của ma trận 
                            matrandich[i, j] = 0;   // cho bằng 0 tức là khoảng trống
                        else
                        {
                            so++;
                            matrandich[i, j] = so;  // tạo phần tử 
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
            public void FindPosition(int x)        // hàm này dùng để tìm vị trí của phần tử trong ma trận k ở ma trận đích
            {
                for(int i = 0; i < n; i++)
                {
                    for(int j =0; j <n; j++)
                    {
                        if(matrandich[i,j] == x)      // nếu phần tử nào trong ma trận đích có giá trị giống phần tử này
                        {
                            vtx = i;             // lưu lại vị trí
                            vty = j;
                            return;         // nếu tìm ra rồi thì thoát hàm luôn, khỏi chạy tốn công
                        }
                    }
                }
            }
        }
        public void CalculateF()
        {
            Vitri vt = new Vitri();
            vt.SetUp();               // khỏi tạo ma trận đích
            vt.Output();
            for (int i = 0; i < n; i++)
            {
                for(int j = 0;j < n; j++)
                {
                    if(matran[i,j] != 0)       // loại bỏ trường hợp f cộng luôn cái khoảng trống
                    {
                        vt.FindPosition(matran[i, j]);
                        f += Math.Abs(i - vt.vtx) + Math.Abs(j - vt.vty);       // tính f theo công thức
                    }
                }
            }
            Console.WriteLine("F = " + f);
        }
    }
}
