using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Количество вершин в графе: ");
            int peak = MatrixGenerator.ReadAnswer();
            Console.Write("Количество ребер в графе: ");
            int edge = MatrixGenerator.ReadAnswer();
            Console.Write("Размерность клики К: ");
            int k = MatrixGenerator.ReadAnswer();

            int[,] matrix = MatrixGenerator.CreateMatrix(peak, edge);
            MatrixGenerator.PrintMatrix(matrix);

            Graph graph = new Graph();
            graph = MatrixGenerator.FindSubPoints(matrix);

            if (graph.ContainsClique(k))
            {
                Console.WriteLine($"В графе есть клика размерности {k}");
                Console.Write("Например: ");
                foreach (int clq in graph.Cliques) Console.Write(clq + " ");        
            }
            else Console.WriteLine($"В графе нет клики размерности {k}");
            Console.ReadKey();
        }
    }
}
