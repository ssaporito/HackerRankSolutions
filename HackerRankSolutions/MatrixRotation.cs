namespace HackerRankSolutions.MatrixRotation
{
    class MatrixRotation
    {
        public static void Solve(List<List<int>> matrix, int r)
        {
            int m = matrix.Count;
            int n = matrix[0].Count;

            var result = new List<List<int>>(m);
            for (int i = 0; i < m; i++)
            {
                result.Add(new List<int>(n));
                for (int j = 0; j < n; j++)
                {
                    result[i].Add(-1);
                }
            }
            for (int k = 0; k < m - k - 1 && k < n - k - 1; k++)
            {
                var kStrip = generateStrip(matrix, k);
                var rotatedStrip = RotateStrip(kStrip, r);
                for (int i = 0; i < kStrip.Count; i++)
                {
                    var prev = kStrip[i];
                    var rotated = rotatedStrip[i];
                    result[prev.Item1][prev.Item2] = matrix[rotated.Item1][rotated.Item2];
                }
            }

            PrintMatrix(result);
        }

        public static List<(int, int)> generateStrip(List<List<int>> matrix, int k)
        {
            int m = matrix.Count;
            int n = matrix[0].Count;
            var strip = new List<(int, int)>();
            for (int i = k; i < m - k - 1; i++)
            {
                strip.Add((i, k));
            }

            for (int j = k; j < n - k - 1; j++)
            {
                strip.Add((m - k - 1, j));
            }

            for (int i = m - k - 1; i > k; i--)
            {
                strip.Add((i, n - k - 1));
            }

            for (int j = n - k - 1; j > k; j--)
            {
                strip.Add((k, j));
            }

            return strip;
        }

        public static List<(int, int)> RotateStrip(List<(int, int)> strip, int r)
        {
            var rotatedStrip = Enumerable.Repeat((-1, -1), strip.Count).ToList();
            for (int i = 0; i < strip.Count; i++)
            {
                int j = (i + r) % strip.Count;
                if (j >= rotatedStrip.Count)
                {
                    Console.WriteLine("j: " + j + ", count:" + rotatedStrip.Count);
                    PrintStrip(strip);
                    PrintStrip(rotatedStrip);
                }
                rotatedStrip[j] = strip[i];
            }

            return rotatedStrip;
        }

        public static void PrintMatrix(List<List<int>> matrix)
        {
            int m = matrix.Count;
            int n = matrix[0].Count;
            for (int i = 0; i < m; i++)
            {
                string line = string.Join(" ", matrix[i]);
                Console.WriteLine(line);
            }
        }

        public static void PrintStrip(List<(int, int)> strip)
        {
            string result = "";
            for (int i = 0; i < strip.Count; i++)
            {
                string pos = strip[i].ToString();
                result += " " + pos;
            }
            Console.WriteLine(result);
        }

        public static void SolveInput()
        {
            Console.WriteLine("Starting Matrix Rotation...");
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int m = Convert.ToInt32(firstMultipleInput[0]);

            int n = Convert.ToInt32(firstMultipleInput[1]);

            int r = Convert.ToInt32(firstMultipleInput[2]);

            List<List<int>> matrix = new List<List<int>>();

            for (int i = 0; i < m; i++)
            {
                matrix.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(matrixTemp => Convert.ToInt32(matrixTemp)).ToList());
            }

            Solve(matrix, r);
        }
    }
}
