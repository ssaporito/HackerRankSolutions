using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankSolutions.SuperMaximumCostQueries
{
    public class SuperMaximumCostQueries
    {       
        public static List<long> Solve(int n, List<List<int>> tree, List<List<int>> queries)
        {
            var edges = tree.Select(adj => new Edge(adj[0] - 1, adj[1] - 1, adj[2])).ToList();
            var adjacencies = TreeToAdjacencies(n, edges);            
            return queries.Select(q => PathCount(edges, adjacencies, q[0], q[1])).ToList();
        }

        private record struct Edge(int U, int V, int W)
        {
            public bool IsCentral(int l, int r) => W >= l && W <= r;
            public bool IsAllowed(int r) => W <= r;
        }

        private static bool IsAllowed(int r, int w)
        {
            return w <= r;
        }
        private static bool IsCentral(int l, int r, int w)
        {
            return w >= l && w <= r;
        }

        private static bool IsAllowedNotCentral(int l, int r, int w)
        {
            return w < l;
        }

        private static long PathCount(List<Edge> edges, List<List<(int node, int weight)>> adjacencies, int l, int r)
        {            
            long count = 0;
            var centralNodes = edges.Where(e => e.IsCentral(l, r)).Select(e => new int[2] { e.U, e.V }).SelectMany(e => e).Distinct().ToList();
            var explored = new HashSet<int>();            
            var initialIndices = centralNodes;

            foreach (var initialIndex in initialIndices.Where(i => !explored.Contains(i)))
            {
                var stack = new Stack<int>();
                var prev = new Dictionary<int, (int node, int weight)>();

                stack.Push(initialIndex);
                int nodeCount = 0;

                while (stack.Any())
                {
                    var currNode = stack.Pop();
                    if (explored.Contains(currNode))
                        continue;

                    nodeCount++;
                    if (prev.ContainsKey(currNode))
                    {
                        bool isCentral = IsCentral(l, r, prev[currNode].weight);
                        var diff = isCentral ? 0 : CountEdgesUntilCentrals(adjacencies, l, r, explored, currNode);
                        count += nodeCount - 1 - diff;
                    }                                                            

                    var neighbors = adjacencies[currNode].Where(t => IsAllowed(r, t.weight) && !explored.Contains(t.node)).ToList();
                    foreach (var neighbor in neighbors)
                    {
                        prev[neighbor.node] = (currNode, neighbor.weight);
                        stack.Push(neighbor.node);
                    }

                    explored.Add(currNode);
                }
            }

            return count;
        }        

        private static int CountEdgesUntilCentrals(List<List<(int node, int weight)>> adjacencies, int l, int r, HashSet<int> explored, int initialNode)
        {
            var stack = new Stack<int>();
            stack.Push(initialNode);
            int countNodes = 0;
            var counted = new HashSet<int>();
            var prev = new Dictionary<int, (int node, int weight)>();

            while (stack.Any())
            {
                var currNode = stack.Pop();
                if (counted.Contains(currNode))
                    continue;

                countNodes++;
                var neighborEdges = adjacencies[currNode].Where(t => IsAllowedNotCentral(l, r, t.weight) && !counted.Contains(t.node) && explored.Contains(t.node)).ToList();
                foreach (var neighbor in neighborEdges)
                {
                    prev[neighbor.node] = (currNode, neighbor.weight);
                    stack.Push(neighbor.node);
                }

                counted.Add(currNode);
            }

            return countNodes - 1;
        }

        private static List<List<(int node, int weight)>> TreeToAdjacencies(int n, List<Edge> edges)
        {
            var adjacencies = Enumerable.Range(0, n).Select(i => new List<(int v, int w)>()).ToList();
            //List<Dictionary<int, int>> weights = Enumerable.Range(0, n).Select(i => new Dictionary<int, int>()).ToList();
            for (int i = 0; i < edges.Count; i++)
            {
                var edge = edges[i];
                var (u, v, w) = (edge.U, edge.V, edge.W);
                adjacencies[u].Add((v, w));
                adjacencies[v].Add((u, w));
            }
            return adjacencies;
        }    
    }
}
