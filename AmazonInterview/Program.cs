using AmazonInterview.MIT.Graph;
using System.Linq;

namespace AmazonInterview
{
    class Program {
        static void Main(string[] args) {
            var graph = new Graph<char>();
            var a = graph.AddVertex('a');
            var b = graph.AddVertex('b');
            var c = graph.AddVertex('c');
            var d = graph.AddVertex('d');
            var e = graph.AddVertex('e');
            var f = graph.AddVertex('f');

            graph.AddEdge(a, b);
            graph.AddEdge(a, d);
            graph.AddEdge(b, e);
            graph.AddEdge(e, d);
            graph.AddEdge(c, e);
            graph.AddEdge(c, f);
            //graph.AddEdge(f, f);

            var result = graph.Dfs(a);
            var resultReversed = result.Reverse().ToList();
        }
    }
}
