using System.Collections.Generic;
using System.Linq;

namespace AmazonInterview.MIT.Graph
{
    public class Graph<V>
    {
        private List<Vertex<V>> _vertices;

        public Graph() =>
            _vertices = new List<Vertex<V>>();

        public Vertex<V> AddVertex(V value)
        {
            var vertex = new Vertex<V>(value);

            _vertices.Add(vertex);

            return vertex;
        }

        public void AddEdge(Vertex<V> first, Vertex<V> second) =>
            ((IVertex)first).AddAdjacent(second);

        public IEnumerable<Vertex<V>> Bfs(Vertex<V> start)
        {
            var result = new List<Vertex<V>>();
            var level = new Dictionary<Vertex<V>, int>
            {
                [start] = 0
            };
            var parent = new Dictionary<Vertex<V>, Vertex<V>>
            {
                [start] = null
            };
            var i = 1;
            var frontier = new List<Vertex<V>> { start };

            while (frontier.Any())
            {
                var next = new List<Vertex<V>>();

                foreach (var vertex in frontier)
                {
                    result.Add(vertex);

                    foreach (var adjacent in vertex.Adjacent)
                    {
                        if (!level.ContainsKey(adjacent))
                        {
                            level[adjacent] = i;
                            parent[adjacent] = vertex;

                            next.Add(adjacent);
                        }
                    }
                }

                frontier = next;
                i++;
            }

            return result;
        }

        public IEnumerable<Vertex<V>> Dfs(Vertex<V> start)
        {
            var result = new List<Vertex<V>>();
            var visited = new HashSet<Vertex<V>>();

            DfsVisit(visited, start);

            return result;

            void DfsVisit(HashSet<Vertex<V>> visited, Vertex<V> vertex)
            {
                if (!visited.Contains(vertex))
                {
                    visited.Add(vertex);
                    result.Add(vertex);

                    foreach (var descendant in vertex.Adjacent)
                        DfsVisit(visited, descendant);
                }
            }
        }
    }
}
