using algForExam.Graph;

namespace algForExam
{
    public static class DfsGraphExtensions
    {
        public static IEnumerable<Vertex<TVertex, TEdge>> Dfs<TVertex, TEdge>(this Vertex<TVertex, TEdge> startVertex) where TVertex : IComparable where TEdge : IComparable
        {
            var stack = new Stack<Vertex<TVertex, TEdge>>();
            var visitedVertices = new List<Vertex<TVertex, TEdge>>();
            var visitedEdges = new List<Edge<TEdge, TVertex>>();

            stack.Push(startVertex);

            while (stack.Count > 0)
            {
                var currentVertex = stack.Pop();
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
                            stack.Push(el);
                        }
                    }
                }
            }
        }
    }
}
