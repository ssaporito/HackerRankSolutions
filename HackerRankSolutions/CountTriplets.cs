namespace HackerRankSolutions.CountTriplets
{
    public class CountTriplets
    {
        public static long SolveCountTriplets(List<long> arr, long r)
        {
            var arrIndices = new Dictionary<long, List<int>>();
            for (int i = 0; i < arr.Count; i++)
            {
                long v = arr[i];
                if (!arrIndices.ContainsKey(v))
                    arrIndices[v] = new List<int>();
                arrIndices[v].Add(i);
            }

            long count = 0;
            var bOptions = arrIndices.Keys.Where(b => (b % r == 0) && arrIndices.ContainsKey(b / r) && arrIndices.ContainsKey(b * r)).ToList();

            foreach (var b in bOptions)
            {
                if (r == 1)
                {
                    var countTriplets = Tetrahedral((long)arrIndices[b].Count);
                    count += countTriplets;
                    continue;
                }

                var a = b / r;
                var c = b * r;

                foreach (var j in arrIndices[b])
                {
                    int aCount = CountLowerThan(arrIndices[a], 0, arrIndices[a].Count - 1, j);
                    int cCount = CountHigherThan(arrIndices[c], 0, arrIndices[c].Count - 1, j);
                    var tripletCount = aCount * cCount;
                    count += tripletCount;
                }
            }

            return count;
        }

        static int CountLowerThan(List<int> indices, int start, int end, int m)
        {
            if (indices[start] > m)
                return 0;
            if (indices[end] < m)
                return end + 1;

            int mid = start + (int)Math.Floor((end - start) / (double)2);
            if (indices[mid] > m)
            {
                if (mid == 0 || indices[mid - 1] < m)
                    return mid;
                else
                    return CountLowerThan(indices, start, mid, m);
            }
            else
            {
                if (mid + 1 >= indices.Count || indices[mid + 1] > m)
                    return mid + 1;
                else
                    return CountLowerThan(indices, mid, end, m);
            }
        }

        static int CountHigherThan(List<int> indices, int start, int end, int m)
        {
            if (indices[end] < m)
                return 0;
            if (indices[start] > m)
                return indices.Count - start;

            int mid = start + (int)Math.Floor((end - start) / (double)2);
            if (indices[mid] < m)
            {
                if (mid + 1 == indices.Count || indices[mid + 1] > m)
                    return indices.Count - mid - 1;
                else
                    return CountHigherThan(indices, mid, end, m);
            }
            else
            {
                if (mid == 0 || indices[mid - 1] < m)
                    return indices.Count - mid;
                else
                    return CountHigherThan(indices, start, mid, m);
            }
        }

        static long Tetrahedral(long n)
        {
            return n * (n - 1) * (n - 2) / 6;
        }
    }
}
