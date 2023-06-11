namespace HackerRankSolutions.KnightLOnAChessboard
{
    public class KnightLOnAChessboard
    {
        private record struct Position(int X, int Y);

        public static List<List<int>> SolveKnightLOnAChessboard(int n)
        {
            var result = new List<List<int>>();

            for (int i = 1; i < n; i++)
            {
                result.Add(new List<int>());
                for (int j = 1; j < n; j++)
                {
                    var moves = KnightL(n, i, j);
                    result[i - 1].Add(moves);
                }
            }
            return result;
        }

        private static int KnightL(int n, int a, int b)
        {
            var start = new Position(0, 0);
            var end = new Position(n - 1, n - 1);
            var movesUntil = new Dictionary<Position, int> { [start] = 0 };          
            var explored = new HashSet<Position>();
            var minQueue = new PriorityQueue<Position, int>();
            minQueue.Enqueue(start, movesUntil[start]);

            while (minQueue.TryDequeue(out Position curr, out int movesUntilCurr))
            {
                if (explored.Contains(curr))
                    continue;

                var neighbors = Neighbors(n, a, b, curr).Where(p => !explored.Contains(p)).ToList();
                foreach(var neighbor in neighbors)
                {
                    var previousDist = movesUntil.ContainsKey(neighbor) ? movesUntil[neighbor] : int.MaxValue;
                    var newDist = movesUntilCurr + 1;
                    movesUntil[neighbor] = Math.Min(newDist, previousDist);
                    minQueue.Enqueue(neighbor, movesUntil[neighbor]);
                }

                explored.Add(curr);
            }

            return movesUntil.ContainsKey(end) ? movesUntil[end] : -1;
        }

        private static List<Position> Neighbors(int n, int a, int b, Position pos)
        {
            var neighbors = new List<Position>();
            var increments = new List<(int x, int y)> { (-a, -b), (-a, b), (a, -b), (a, b) };
            increments.AddRange(increments.Select(t => (t.y, t.x)).ToList());
            foreach (var (x, y) in increments)
            {
                var newPos = new Position(pos.X + x, pos.Y + y);
                if (newPos.X < 0 || newPos.X >= n || newPos.Y < 0 || newPos.Y >= n)
                    continue;

                neighbors.Add(newPos);
            }
            return neighbors;
        }
    }
}
