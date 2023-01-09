using algForExam.Graph;

namespace algForExam
{
    public static class BfsGraphExtensions
    {
        public static IEnumerable<Vertex<TVertex, TEdge>> Bfs<TVertex, TEdge>(this Vertex<TVertex, TEdge> startVertex) where TVertex : IComparable where TEdge : IComparable
        {
            var queue = new Queue<Vertex<TVertex, TEdge>>();
            var visitedVertices = new List<Vertex<TVertex, TEdge>>();
            var visitedEdges = new List<Edge<TEdge, TVertex>>();

            queue.Enqueue(startVertex);

            while (queue.Count > 0)
            {
                var currentVertex = queue.Dequeue();
                if (visitedVertices.Contains(currentVertex)) continue;
                visitedVertices.Add(currentVertex);

                yield return currentVertex;

                foreach (var edge in currentVertex.EdgesList)
                {
                    if (!visitedEdges.Contains(edge))
                    {
                        visitedEdges.Add(edge);
                        var el = edge.InitialVertex == currentVertex ? edge.DestinationVertex : edge.InitialVertex;
                        if (el != null)
                        {
                            queue.Enqueue(el);
                        }
                    }
                }
            }
        }
    }
}
