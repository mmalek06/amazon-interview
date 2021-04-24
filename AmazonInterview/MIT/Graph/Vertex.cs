using System.Collections.Generic;

namespace AmazonInterview.MIT.Graph
{
    public class Vertex<V> : IVertex
    {
        public V Value { get; private set; }

        public IEnumerable<Vertex<V>> Adjacent => _adjacentVertices;

        private HashSet<Vertex<V>> _adjacentVertices;

        public Vertex(V value)
        {
            Value = value;
            _adjacentVertices = new HashSet<Vertex<V>>();
        }

        void IVertex.AddAdjacent(IVertex vertex) =>
            _adjacentVertices.Add(vertex as Vertex<V>);
    }
}
