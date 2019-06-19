using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8
{
    class MatrixGenerator
    {
        public static int ReadAnswer()
        {
            int a = 0;
            bool ok = false;
            do
            {
                try
                {
                    a = Convert.ToInt32(Console.ReadLine());
                    if (a >= 0 && a <= 100)
                        ok = true;
                    else Console.WriteLine("Пожалуйста, введите целое число больше 0 и меньше 100");
                }
                catch (Exception)
                {
                    Console.WriteLine("Пожалуйста, введите целое число.");
                    ok = false;
                }
            } while (!ok);
            return a;
        }       

        public static int[,] CreateMatrix(int peak, int edge)
        {
            Random rand = new Random();
            int[,] matr = new int[peak, edge];
            for(int j=0; j<edge;j++)
            {
                int firstPeak, secondPeak = rand.Next(0, peak);
                firstPeak = secondPeak;
                while (firstPeak == secondPeak)
                    firstPeak = rand.Next(0, peak);
                matr[firstPeak, j] = matr[secondPeak, j] = 1;
            }
            return matr;
        }     

        public static void PrintMatrix(int[,] matr)
        {
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                Console.Write(i + " ");
                for (int j = 0; j < matr.GetLength(1); j++)
                {
                    Console.Write($" {matr[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        public static Graph FindSubPoints(int[,] matrix)
        {
            Graph gr = new Graph();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                gr.Points.Add(i, new Point(i));
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] == 1)
                    {
                        for (int k = 0; k < matrix.GetLength(0); k++)
                        {
                            if (k != i && matrix [k,j] == 1)
                            {
                                if(!gr.Points[i].SubPoints.Contains(k))
                                gr.Points[i].SubPoints.Add(k);
                            }
                        }
                    }
                }
            }
            return gr;            
        }
    }
}
