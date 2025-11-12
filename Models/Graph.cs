using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServicesApp.Models
{
    public class Graph
    {
        
        private Dictionary<int, List<(int to, double weight)>> adj = new Dictionary<int, List<(int, double)>>();

        public void AddNode(int id)
        {
            if (!adj.ContainsKey(id)) adj[id] = new List<(int, double)>();
        }

        public void AddEdge(int a, int b, double weight)
        {
            AddNode(a); AddNode(b);
            adj[a].Add((b, weight));
            adj[b].Add((a, weight)); 
        }

        public IEnumerable<int> Nodes => adj.Keys;

        
        public List<int> BFS(int start)
        {
            var visited = new HashSet<int>();
            var q = new Queue<int>();
            var order = new List<int>();
            if (!adj.ContainsKey(start)) return order;
            visited.Add(start); q.Enqueue(start);
            while (q.Count > 0)
            {
                var u = q.Dequeue();
                order.Add(u);
                foreach (var (v, w) in adj[u])
                    if (!visited.Contains(v)) { visited.Add(v); q.Enqueue(v); }
            }
            return order;
        }

        
        public List<int> DFS(int start)
        {
            var visited = new HashSet<int>();
            var order = new List<int>();
            if (!adj.ContainsKey(start)) return order;
            DFSInternal(start, visited, order);
            return order;
        }
        private void DFSInternal(int u, HashSet<int> visited, List<int> order)
        {
            visited.Add(u);
            order.Add(u);
            foreach (var (v, w) in adj[u])
                if (!visited.Contains(v)) DFSInternal(v, visited, order);
        }


        public List<(int a, int b, double weight)> PrimMST()
        {
            var result = new List<(int a, int b, double weight)>();
            if (adj.Count == 0) return result;

            var inMst = new HashSet<int>();
            var pq = new List<(double weight, int from, int to)>();

            int start = adj.Keys.First();
            inMst.Add(start);
            foreach (var (v, w) in adj[start])
                pq.Add((w, start, v));

            while (pq.Count > 0 && inMst.Count < adj.Count)
            {
                pq.Sort((x, y) =>
                {
                    int c = x.weight.CompareTo(y.weight);
                    if (c != 0) return c;
                    c = x.from.CompareTo(y.from);
                    if (c != 0) return c;
                    return x.to.CompareTo(y.to);
                });

                var edge = pq[0];
                pq.RemoveAt(0);

                if (inMst.Contains(edge.to)) continue;
                inMst.Add(edge.to);
                result.Add((edge.from, edge.to, edge.weight));
                foreach (var (v, w) in adj[edge.to])
                {
                    if (!inMst.Contains(v))
                        pq.Add((w, edge.to, v));
                }
            }

            return result;
        }

    }
}