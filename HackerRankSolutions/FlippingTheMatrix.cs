using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankSolutions.FlippingTheMatrix
{
    class FlippingTheMatrix
    {
        public static int FlippingMatrix(List<List<int>> matrix)
        {
            int twoN = matrix.Count;
            int n = twoN / 2;
            var chosenElements = new HashSet<((int row, int col) coords, int value)>();
            var leftUpperMatrix = new List<List<int>>();
            int result = 0;
            for (int i = 0; i < n; i++)
            {                
                for (int j = 0; j < n; j++)
                {
                    var quartet = GetQuartet(matrix, i, j);
                    var availableElements = quartet.Where(x => !chosenElements.Contains(x)).ToList();
                    var maxElement = availableElements.Max(x => x.value);
                    var chosen = availableElements.First(x => x.value == maxElement);
                    chosenElements.Add(chosen);
                    result += chosen.value;
                    (matrix[i][j], matrix[chosen.coords.row][chosen.coords.col]) = (matrix[chosen.coords.row][chosen.coords.col], matrix[i][j]);
                }
            }

            for(int i = 0; i < twoN; i++)
            {
                Console.WriteLine(string.Join(" ", matrix[i]));
            }

            return result;
        }

        public static List<((int row, int col) coords, int value)> GetQuartet(List<List<int>> matrix, int i, int j)
        {
            int twoN = matrix.Count;
            var indices = new List<(int row, int col)> 
            { 
                (i,j), 
                (i, twoN - j - 1), 
                (twoN - i - 1, j), 
                (twoN - i - 1, twoN - j - 1) 
            };

            var result = indices.Select(x => ((x.row, x.col), matrix[x.row][x.col])).ToList();
            return result;
        }

        public static void Test1()
        {
            var data = new List<List<int>>
            {
                new List<int> { 1, 2 },
                new List<int> { 3, 4 }
            };

            var result = FlippingMatrix(data);
            Console.WriteLine(result);
            Debug.Assert(result == 4);
        }

        public static void Test2()
        {
            var data = new List<List<int>>
            {
                new List<int>{ 112, 42, 83, 119 },
                new List<int>{ 56, 125, 56, 49 },
                new List<int>{ 15, 78, 101, 43 },
                new List<int>{ 62, 98, 114, 108 },
            };

            var result = FlippingMatrix(data);
            Console.WriteLine(result);
            Debug.Assert(result == 414);
        }

        public static void Test3()
        {
            var data = new List<List<int>>
            {
                new List<int>{ 107, 54, 128, 15 },
                new List<int>{ 12, 75, 110, 138 },
                new List<int>{ 100, 96, 34, 85 },
                new List<int>{ 75, 15, 28, 112 },
            };
            var result = FlippingMatrix(data);
            Console.WriteLine(result);
            Debug.Assert(result == 488);
        }

        public static void SolveInput()
        {
            Test1();
            Test2();
            Test3();
        }
    }
}
