﻿using System;
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
        public static List<int> Solve(List<List<int>> tree, List<List<int>> queries)
        {
            var edges = tree.Select(adj => new Edge(adj[0], adj[1], adj[2])).ToList();
            var edgeAdjacencies = TreeToEdgeAdjacencies(edges);
            return queries.Select(q => PathCount(edgeAdjacencies, q[0], q[1])).ToList();
        }

        private record struct Edge(int U, int V, int W)
        {
            public bool IsCentral(int l, int r) => W >= l && W <= r;
            public bool IsAllowed(int r) => W <= r;
        }

        private static int PathCount(Dictionary<Edge, List<Edge>> edgeAdjacencies, int l, int r)
        {
            var edges = edgeAdjacencies.Keys.ToList();
            var allowedEdges = edges.Where(e => e.IsAllowed(r)).ToList();
            int count = 0;
            var centralEdges = edgeAdjacencies.Keys.Where(e => e.IsCentral(l, r)).ToList();
            var explored = new HashSet<Edge>();
            var initialEdges = centralEdges.Where(e => !explored.Contains(e)).ToList();

            foreach (var initialEdge in initialEdges)
            {
                var stack = new Stack<Edge>();
                stack.Push(initialEdge);
                int edgeCount = 0;
                var distanceToCentral = new Dictionary<Edge, int>();
                var previousEdge = new Dictionary<Edge, Edge>();

                while (stack.Any())
                {
                    var curr = stack.Pop();
                    if (explored.Contains(curr))
                        continue;

                    edgeCount++;
                    distanceToCentral[curr] = curr.IsCentral(l, r) ? 0 : distanceToCentral[previousEdge[curr]] + 1;                    
                    count += edgeCount - distanceToCentral[curr];

                    var neighborEdges = edgeAdjacencies[curr].Where(e => e.IsAllowed(r) && !previousEdge.ContainsKey(e));
                    foreach (var neighbor in neighborEdges)
                    {
                        previousEdge[neighbor] = curr;
                        stack.Push(neighbor);                                              
                    }

                    explored.Add(curr);
                }
            }

            return count;
        }   

        private static int CountConnectedCentralsFrom(Dictionary<Edge, List<Edge>> edgeAdjacencies, int l, int r, HashSet<Edge> explored, Edge initialEdge)
        {
            var stack = new Stack<Edge>();
            stack.Push(initialEdge);
            int countCentrals = 0;

            while (stack.Any())
            {
                var curr = stack.Pop();
                if (curr.IsCentral(l, r))
                {
                    countCentrals++;
                    continue;
                }

                var neighborEdges = edgeAdjacencies[curr].Where(e => e.IsAllowed(r) && explored.Contains(e));
                foreach (var neighbor in neighborEdges)
                {
                    stack.Push(neighbor);
                }                              

                explored.Add(curr);
            }

            return countCentrals;
        }

        private static Dictionary<Edge, List<Edge>> TreeToEdgeAdjacencies(List<Edge> edges)
        {
            Dictionary<Edge, List<Edge>> edgeAdjacencies = edges.ToDictionary(e => e, e => new List<Edge>());
            for (int i = 0; i < edges.Count; i++)
            {
                Edge edge1 = edges[i];            

                for (int j = i + 1; j < edges.Count; j++)
                {
                    Edge edge2 = edges[j];
                    if (edge1.U == edge2.U || edge1.U == edge2.V || edge1.V == edge2.U || edge1.V == edge2.V)
                    {
                        edgeAdjacencies[edge1].Add(edge2);
                        edgeAdjacencies[edge2].Add(edge1);
                    }
                }
            }

            return edgeAdjacencies;
        }         
    }
}
