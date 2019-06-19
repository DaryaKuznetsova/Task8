using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8
{
    class Point
    {
        public int Name { get; set; }
        public List<int> SubPoints { get; set; }

        public Point(int n)
        {
            Name = n;
            SubPoints = new List<int>();
        }
        public override string ToString()
        {
            string s = Name.ToString() + @" +друзья:";
            foreach (int n in SubPoints)
                s += n + " ";
            return s;
        }
    }
}
