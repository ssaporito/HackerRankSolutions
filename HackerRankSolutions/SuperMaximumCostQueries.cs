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
        private record struct Edge(int U, int V, int W)
        {
            public bool IsCentral(int l, int r) => W >= l && W <= r;
            public bool IsAllowed(int r) => W <= r;
        }

        public static List<int> Solve(List<List<int>> tree, List<List<int>> queries)
        {
            var edges = tree.Select(adj => new Edge(adj[0], adj[1], adj[2])).ToList();
            var edgeAdjacencies = TreeToEdgeAdjacencies(edges);
            return queries.Select(q => PathCount(edgeAdjacencies, q[0], q[1])).ToList();
        }

        private static int PathCount(Dictionary<Edge, List<Edge>> edgeAdjacencies, int l, int r)
        {
            var edges = edgeAdjacencies.Keys.ToList();
            var allowedEdges = edges.Where(e => e.IsAllowed(r)).ToList();
            //var (components, redundantCount) = ConnectedEdgeComponents(edgeAdjacencies, l, r);
            //int count = (redundantCount + allowedEdges.Count) / 2;            
            //var centralEdges = edges.Where(e => e.IsCentral(l, r)).ToList();

            //return components.Sum(c => PathCountByEdgeComponent(c, l, r));
            int count = allowedEdges.Sum(e => PathCountRec(edgeAdjacencies, l, r, e, null, false));
            //int result = (redundantResult + allowedEdges.Count) / 2;
            return count;
        }

        static Dictionary<(int l, int r, Edge edge, Edge? prev), int> _memo = new();
        static int _countMemoUses = 0;
        static int _stackCount = 1;
        private static int PathCountRec(Dictionary<Edge, List<Edge>> edgeAdjacencies, int l, int r, Edge edge, Edge? prev, bool hasCentral)
        {
            _stackCount++;
            var tuple = (l, r, edge, prev);
            if (_memo.ContainsKey(tuple))
            {
                _countMemoUses++;
                return _memo[tuple];
            }

            if (!hasCentral && edge.IsCentral(l, r))
                hasCentral = true;

            int edgeValue = hasCentral ? 1 : 0;
            var neighbors = edgeAdjacencies[edge].Where(e => e.IsAllowed(r) && e != prev);
            int neighborCount = 0;
            foreach (var neighbor in neighbors)
            {
                neighborCount += PathCountRec(edgeAdjacencies, l, r, neighbor, edge, hasCentral);
            }
            _stackCount--;
            return _memo[tuple] = neighborCount + edgeValue;
        }

        private static int PathCountByEdgeComponent(List<Edge> component, int l, int r)
        {
            int m = component.Count;
            int d = component.Count(c => !c.IsCentral(l, r));
            return (m + 1) * m / 2 - (d + 1) * d / 2;
        }

        private static (List<List<Edge>> components, int pathCount) ConnectedEdgeComponents(Dictionary<Edge, List<Edge>> edgeAdjacencies, int l, int r)
        {
            int count = 0;
            var components = new List<List<Edge>>();
            var edges = edgeAdjacencies.Keys.ToList();
            var allowedEdges = edges.Where(e => e.IsAllowed(r)).ToList();
            //var centralEdges = edgeAdjacencies.Keys.Where(e => e.IsCentral(l, r)).ToList();
            //int centralEdgeIndex = 0;            
            
            foreach (var initialEdge in allowedEdges)
            {
                var explored = new HashSet<Edge>();
                var stack = new Stack<Edge>();
                //var centralEdge = centralEdges[centralEdgeIndex];
                //if (explored.Contains(centralEdge))
                //{
                //    centralEdgeIndex++;
                //    continue;
                //}

                stack.Push(initialEdge);       
                //var component = new List<Edge>();
                //var countBranchesFromEdge = new Dictionary<Edge, int>();
                //int edgeCount = 0;
                var prev = new Dictionary<Edge, Edge>();
                var hasCentral = new Dictionary<Edge, bool>();
                int componentCount = 0;

                while (stack.Any())
                {
                    var curr = stack.Pop();
                    if (explored.Contains(curr))
                        continue;

                    //edgeCount++;                                        

                    //if (curr.IsCentral(l, r))
                    //{
                    //    countBranchesFromEdge[curr] = edgeCount;
                    //    count += countBranchesFromEdge[curr];
                    //}
                    //else
                    //{
                    //    count += countBranchesFromEdge[prevCentral[curr]];
                    //}                    

                    //if (prev.ContainsKey(curr) && prev[curr].IsCentral(l, r))
                    //{
                    //    countBranchesFromEdge[prev[curr]]++;
                    //}                   
                    hasCentral[curr] = prev.ContainsKey(curr) ? hasCentral[prev[curr]] : curr.IsCentral(l, r);
                    componentCount += hasCentral[curr] ? 1 : 0;

                    var neighborEdges = edgeAdjacencies[curr].Where(e => e.IsAllowed(r) && !explored.Contains(e));
                    foreach (var neighbor in neighborEdges)
                    {
                        prev[neighbor] = curr;
                        stack.Push(neighbor);
                    }

                    explored.Add(curr);
                    //component.Add(curr);                    
                }
                count += componentCount;
                //centralEdgeIndex++;
                //components.Add(component);
            }

            return (components, count);
        }

        private static Dictionary<Edge, List<Edge>> TreeToEdgeAdjacencies(List<Edge> edges)
        {
            Dictionary<Edge, List<Edge>> edgeAdjacencies = edges.ToDictionary(e => e, e => new List<Edge>());
            for (int i = 0; i < edges.Count; i++)
            {
                Edge edge1 = edges[i];
                int neighborCount = 0;             

                for (int j = i + 1; j < edges.Count; j++)
                {
                    Edge edge2 = edges[j];
                    if (edge1.U == edge2.U || edge1.U == edge2.V || edge1.V == edge2.U || edge1.V == edge2.V)
                    {
                        edgeAdjacencies[edge1].Add(edge2);
                        //edgeAdjacencies[edge2].Add(edge1);
                        neighborCount++;
                    }

                    if (neighborCount >= 2)
                        break;
                }
            }

            return edgeAdjacencies;
        }         
    }
}
