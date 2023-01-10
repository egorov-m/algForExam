using algForExam.Graph;

namespace algForExam
{
    public static class DijkstraGraphExtensions
    {
        private class DijkstraData<TVertex, TEdge> where TVertex : IComparable where TEdge : IComparable
        {
            public int Price { get; init; }

            public Vertex<TVertex, TEdge>? Previous { get; init; }
        }

        public static IEnumerable<Vertex<TVertex, int>> Dijkstra<TVertex>(this Graph<TVertex, int> graph, Vertex<TVertex, int> start, Vertex<TVertex, int> end) where TVertex : IComparable
        {
            var noVisitedVertices = graph.Vertices.ToList();

            var track = new System.Collections.Generic.Dictionary<Vertex<TVertex, int>, DijkstraData<TVertex, int>>();

            track[start] = new DijkstraData<TVertex, int> {Previous = null, Price = 0};

            while (true)
            {
                Vertex<TVertex, int>? toOpen = null;
                var bestPrice = int.MaxValue;

                foreach (var vertexElement in noVisitedVertices)
                {
                    if (track.ContainsKey(vertexElement) && track[vertexElement].Price < bestPrice)
                    {
                        toOpen = vertexElement;
                        bestPrice = track[vertexElement].Price;
                    }
                }

                if (toOpen != null && toOpen.Equals(end))
                {
                    break;
                }

                if (toOpen != null)
                {
                    foreach (var edge in toOpen.EdgesList)
                    {
                        var currentPrice = track[toOpen].Price + edge.Weight;

                        var nextVertex = edge.InitialVertex.Equals(toOpen) ? edge.DestinationVertex : edge.InitialVertex;

                        if (!track.ContainsKey(nextVertex) || track[nextVertex].Price > currentPrice)
                        {
                            track[nextVertex] = new DijkstraData<TVertex, int> {Price = currentPrice, Previous = toOpen};
                        }
                    }

                    noVisitedVertices.Remove(toOpen);
                }
            }

            var result = new List<Vertex<TVertex, int>>();
            
            var tmp = end;
            while (tmp != null)
            {
                result.Add(tmp);
                tmp = track[tmp].Previous;
            }

            result.Reverse();

            return result;
        }
    }
}
