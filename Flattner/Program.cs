using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Write some code, that will flatten an array of arbitrarily nested arrays of integers into a 
flat array of integers. e.g. [[1,2,[3]],4] -> [1,2,3,4]
    */

namespace Flattner
{
    class Program
    {
        static void Main(string[] args)
        {
            var arrs = new Object[] { 1, 2, new Object[] { 3 }, 4 };

            var arr = Flattner(arrs);

            arr.ForEach(Console.WriteLine);

            Console.ReadLine();
        }

        static List<int> Flattner(Object[] arrs)
        {
            var result = new List<int>();

            foreach (var item in arrs)
            {
                if (item is int)
                {
                    result.Add((int)item);
                    //Console.Write(item);
                }
                else
                {
                    result.AddRange(Flattner((Object[])item));
                }
            }

            return result;
        }
    }
}
