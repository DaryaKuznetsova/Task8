using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8
{
    class Graph
    {
        public Dictionary<int, Point> Points { get; set; }
        public List<int> Cliques { get; set; }

        static List<int> whereToFind = new List<int>();

        public Graph()
        {
            Points = new Dictionary<int, Point>();
            Cliques = new List<int>();
        }

        public Point GetPoint(int name)
        {
            return Points[name];
        }
       
        public bool ContainsClique(int k)
        {
            bool cliqueIsFound = false; // предполагается, что клики в графе нет
            if (k == 1) return true; // клика размерности 1 есть всегда
            else
            {
                if (Check(k)) // составим список вершин, которые могут быть в клике
                {
                    k--; // дальше будем формировать сочетания соседних вершин, значит на 1 меньше размера клики
                    foreach (int potential in whereToFind) // для каждой вершины из тех, которые могут составить клику
                    {
                        Cliques.Clear(); 
                        Cliques.Add(potential); // допустим, данная вершина в клике
                        List<int> Candidates = new List<int>();
                        List<int> SubCandidates = Intersect(Points[potential].SubPoints, whereToFind); // найдем пересечение вершин, которые могут быть в клике, и соседей данной вершины
                        if(SubCandidates.Count>=k) // если вариантов для попадения в клику достаточно
                        foreach (int[] c in Generate.Combinations(k, SubCandidates)) // для каждой комбинации соседних вершин
                        {                                                            // которая подходит по размеру клики
                            int count = 0;
                            foreach (int candidate in c) // проверяем каждую соседнюю вершину
                            {                            // на соединение с соседними вершинами текущей вершины
                                Candidates = Except(c.ToList(), candidate); // для этого убираем проверяемую вершину из списка
                                if (ContainsSubPoints(Points[candidate].SubPoints, Candidates)) // проверка сразу всех потенциальных вершин 
                                        count++; 
                            }
                            if (count == c.Length) // если все вершины в данной комбинации соединены
                            {
                                foreach (int l in c)
                                    Cliques.Add(l); // формируем клику
                                cliqueIsFound = true;
                                break;
                            }
                        }
                        if (cliqueIsFound) break;
                    }
                }                          
            }
            return cliqueIsFound;
        }

        static bool ContainsSubPoints(List<int> where, List<int> elements)
        {
            bool ok = true;
            foreach(int elem in elements)
                if (!where.Contains(elem))
                {
                    ok = false;
                    break;
                }
            return ok;
        }

        bool Check(int k)
        {
            bool ok = false;
                foreach (KeyValuePair<int, Point> node in Points)
                    if (node.Value.SubPoints.Count >= k - 1)
                        whereToFind.Add(node.Key);
                if (whereToFind.Count >= k) ok = true;      
            return ok;
        }      

        static List<int> Intersect(List<int> point, List<int> whereToFind)
        {
            var res = (from x in point select x).Intersect(from x in whereToFind select x);
            return res.ToList();
        }
        static List<int> Except(List<int> point, int potential)
        {
            List<int> whereToFind = new List<int>();
            whereToFind.Add(potential);
            var res = (from x in point select x).Except(from x in whereToFind select x);
            return res.ToList();
        }
    }
}
