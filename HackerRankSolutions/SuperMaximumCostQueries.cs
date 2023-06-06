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
        private static readonly Dictionary<(int l, int r), QueryResult> _memo = new();
        private record QueryResult(List<HashSet<int>> Components, List<long> PathCounts, Dictionary<int, int> NodeLabels);        

        public static List<long> Solve(int n, List<List<int>> tree, List<List<int>> queries)
        {
            var edges = tree.Select(adj => new Edge(adj[0] - 1, adj[1] - 1, adj[2])).ToList();
            var adjacencies = TreeToAdjacencies(n, edges);            
            return queries.Select(q => PathCount(edges, adjacencies, q[0], q[1])).ToList();
        }

        private record struct Edge(int U, int V, int W, int Component = -1)
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
            try
            {
                var previousPair = _memo.Keys.First(query => query.l == l && query.r < r);
                var queryResult  = _memo[previousPair];
                var newEdges = edges.Where(e => e.W > previousPair.r && e.W <= r).ToList();
                foreach (var newEdge in newEdges)
                {
                    var edgeNeighbors = adjacencies[newEdge.U].Union(adjacencies[newEdge.V]);
                    var neighbors = edgeNeighbors.Where(e => e.weight >= previousPair.l && e.weight <= previousPair.r).Select(e => e.node);
                    var firstLabeledNeighbor = neighbors.First(v => queryResult.NodeLabels.ContainsKey(v));
                    var label = queryResult.NodeLabels[firstLabeledNeighbor];
                    var connectedComponent = queryResult.Components[label];
                    var nodeToAdd = newEdge.U == firstLabeledNeighbor ? newEdge.V : newEdge.U;
                    connectedComponent.Add(nodeToAdd);
                    queryResult.PathCounts[label] += connectedComponent.Count - 1;
                    queryResult.NodeLabels[nodeToAdd] = label;                    
                }
                _memo[(l, r)] = queryResult;
            }
            catch
            {
                var centralNodes = edges.Where(e => e.IsCentral(l, r)).Select(e => new int[2] { e.U, e.V }).SelectMany(e => e).Distinct().ToList();
                _memo[(l, r)] = GetComponents(centralNodes, adjacencies, l, r);                
            }

            return _memo[(l, r)].PathCounts.Sum();
        }

        private static QueryResult GetComponents(List<int> initialIndices, List<List<(int node, int weight)>> adjacencies, int l, int r)
        {                                           
            var components = new List<HashSet<int>>();
            var pathCounts = new List<long>();
            var nodeLabels = new Dictionary<int, int>();

            var explored = new HashSet<int>();
            foreach (var initialIndex in initialIndices.Where(i => !explored.Contains(i)))
            {
                var stack = new Stack<int>();
                var prev = new Dictionary<int, (int node, int weight)>();
                stack.Push(initialIndex);                
                var component = new HashSet<int>();
                int nodeCount = 0;
                long pathCount = 0;                

                while (stack.Any())
                {
                    var currNode = stack.Pop();
                    if (explored.Contains(currNode))
                        continue;

                    nodeCount++;
                    nodeLabels[currNode] = components.Count;
                    component.Add(currNode);
                    if (prev.ContainsKey(currNode))
                    {
                        var newEdge = new Edge(prev[currNode].node, currNode, prev[currNode].weight, components.Count);                         
                        var diff = newEdge.IsCentral(l, r) ? 0 : CountEdgesUntilCentrals(adjacencies, l, r, explored, currNode);                        
                        pathCount += nodeCount - 1 - diff;                        
                    }                                                            

                    var neighbors = adjacencies[currNode].Where(t => IsAllowed(r, t.weight) && !explored.Contains(t.node)).ToList();
                    foreach (var (neighborNode, weight) in neighbors)
                    {
                        prev[neighborNode] = (currNode, weight);
                        stack.Push(neighborNode);
                    }

                    explored.Add(currNode);
                }

                components.Add(component);
                pathCounts.Add(pathCount);
            }

            return new QueryResult(components, pathCounts, nodeLabels);
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
                foreach (var (neighborNode, weight) in neighborEdges)
                {
                    prev[neighborNode] = (currNode, weight);
                    stack.Push(neighborNode);
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
