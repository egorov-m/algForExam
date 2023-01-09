using System.Collections;

namespace algForExam.Graph
{
    public class Graph<TVertex, TEdge> : IReadOnlyCollection<Vertex<TVertex, TEdge>> 
                                         where TVertex: IComparable
                                         where TEdge : IComparable
    {
        public IList<Vertex<TVertex, TEdge>> Vertices { get; }

        public IList<Edge<TEdge, TVertex>> Edges { get; }

        public int Count { get; private set; }

        public Graph(params Vertex<TVertex, TEdge>[] vertices)
        {
            Vertices = new List<Vertex<TVertex, TEdge>>();
            Edges = new List<Edge<TEdge, TVertex>>();
            foreach (var vertex in vertices)
            {
                Add(vertex);
            }
        }

        public void Add(Vertex<TVertex, TEdge> vertex)
        {
            foreach (var edge in vertex.EdgesList) if (!Edges.Contains(edge)) Edges.Add(edge);
            Vertices.Add(vertex);
            Count++;
        }

        public IEnumerator<Vertex<TVertex, TEdge>> GetEnumerator()
        {
            foreach (var vertex in Vertices)
            {
                if (vertex != null) yield return vertex;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
