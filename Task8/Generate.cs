using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8
{
    class Generate
    {
        public static IEnumerable<int[]> Combinations(int m, List<int> alf)
        {
            int n = alf.Count;
            if (n > 0 && m > 0)
            {
                if (n >= m)
                {
                    int[] result = new int[m];
                    Stack<int> stack = new Stack<int>();
                    stack.Push(0);

                    while (stack.Count > 0)
                    {
                        int index = stack.Count - 1;
                        int value = stack.Pop();

                        while (value < n)
                        {
                            result[index++] = alf[value];
                            value++;
                            stack.Push(value);


                            if (index == m)
                            {
                                yield return result;
                                break;
                            }
                        }
                    }

                }
                else throw new IndexOutOfRangeException();
            }
            else throw new IndexOutOfRangeException();

        }
    }
}
