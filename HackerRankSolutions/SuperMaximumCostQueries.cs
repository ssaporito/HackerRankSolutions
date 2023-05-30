using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankSolutions.SuperMaximumCostQueries
{
    public class SuperMaximumCostQueries
    {
        public static List<int> Solve(int n, List<List<int>> tree, List<List<int>> queries)
        {
            var sortedTree = tree.OrderBy(adj => adj[2]).ToList();
            return queries.Select(q => PathCount(n, sortedTree, q[0], q[1])).ToList();
        }

        public static int PathCount(int n, List<List<int>> sortedTree, int l, int r)
        {
            var allowedSubtree = sortedTree.Where(adj => adj[2] >= l && adj[2] <= r).ToList();
            var adjacencyList = TreeToAdjacencyList(allowedSubtree);
            var connectedComponents = ConnectedComponents(adjacencyList);                    
            var result = connectedComponents.Sum(x => ComponentPathCount(x));
            return result;
        }
        
        public static int ComponentPathCount(List<int> component)
        {
            int n = component.Count;
            return n * (n - 1) / 2;
        }

        public static List<List<int>> ConnectedComponents(Dictionary<int, HashSet<int>> adjacencyList)
        {
            var remainingNodes = new HashSet<int>(adjacencyList.Keys);
            var components = new List<List<int>>(); 
            
            while (remainingNodes.Any())
            {
                var component = new List<int>();
                var explored = new HashSet<int>();
                var stack = new Stack<int>();
                var firstNodeInComponent = remainingNodes.First();
                stack.Push(firstNodeInComponent);

                while (stack.Any())
                {                    
                    int u = stack.Pop();
                    if (explored.Contains(u))
                        continue;
                    
                    component.Add(u);
                    remainingNodes.Remove(u);

                    var neighbors = adjacencyList[u];
                    foreach (var neighbor in neighbors)
                    {
                        if (explored.Contains(neighbor))
                            continue;

                        stack.Push(neighbor);
                    }
                    
                    explored.Add(u);
                }
                components.Add(component);
            }
            return components;
        }

        public static Dictionary<int, HashSet<int>> TreeToAdjacencyList(List<List<int>> tree)
        {
            Dictionary<int, HashSet<int>> adjList = new();
            foreach (var adj in tree)
            {
                int u = adj[0];
                int v = adj[1];
                if (!adjList.ContainsKey(u))
                    adjList[u] = new HashSet<int>();
                if (!adjList.ContainsKey(v))
                    adjList[v] = new HashSet<int>();

                adjList[u].Add(v);
                adjList[v].Add(u);
            }
            return adjList;
        }

        public static Dictionary<int, Dictionary<int, int>> TreeToWeightedAdjacencyList(List<List<int>> tree)
        {
            Dictionary<int, Dictionary<int, int>> adjList = new();            
            foreach(var adj in tree)
            {
                int u = adj[0];
                int v = adj[1];
                int w = adj[2];
                if (!adjList.ContainsKey(u))
                    adjList[u] = new Dictionary<int, int>();
                if (!adjList.ContainsKey(v))
                    adjList[v] = new Dictionary<int, int>();

                adjList[u][v] = w;
                adjList[v][u] = w;
            }
            return adjList;
        }
    }
}
