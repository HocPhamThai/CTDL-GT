using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class IndexedGraph
    {
        private readonly int size;
        // g = list(Graph) with list using a hashtable per bucket;
        private readonly List<HashSet<int>> graph;
        private readonly bool[] _visited;

        public IndexedGraph(int n)
        {
            if (n <= 0) throw new ArgumentOutOfRangeException("n > 0");

            this.size = n;
            graph = [];
            for (int i = 0; i < this.size; i++) graph.Add(new HashSet<int>());
            _visited = new bool[this.size];
        }

        public void AddEdge(int u, int v)
        {
            ValidateIndex(u);
            ValidateIndex(v);

            graph[u].Add(v);
            graph[v].Add(u);
        }
        public void ValidateIndex(int i) { if (i >= size) throw new ArgumentOutOfRangeException("Index out of range"); }

        public void ResetVisited() => Array.Fill(_visited, false);
        
        public List<int> Dfs(int nodeIndex)
        {
            ValidateIndex(nodeIndex);
            ResetVisited();

            List<int> order = [];
            void DfsVisit(int u)
            {
                //if node visited => return
                if (_visited[u]) return;

                _visited[u] = true;
                order.Add(u);

                foreach (var neighbor in graph[u])
                {
                    DfsVisit(neighbor);
                }
            }

            DfsVisit(nodeIndex);
            return order;
        }

        public List<int> DfsFromZero => Dfs(0);
    }
}
