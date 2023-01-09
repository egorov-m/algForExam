namespace algForExam.Graph
{
    public class Edge<TEdge, TVertex> : IComparable<Edge<TEdge, TVertex>> 
                                            where TEdge : IComparable
                                            where TVertex: IComparable
        {
            public Vertex<TVertex, TEdge> InitialVertex { get; set; }

            public Vertex<TVertex, TEdge> DestinationVertex { get; set; }

            private TEdge _weight;
            public TEdge Weight
            {
                get => _weight;
                set
                {
                    if (!HasSetWeight(value)) throw new ArgumentNullException(nameof(value));
                    _weight = value;
                }
            }

            public Edge(Vertex<TVertex, TEdge> initialVertex, Vertex<TVertex, TEdge> destinationVertex,  TEdge weight)
            {
                InitialVertex = initialVertex;
                DestinationVertex = destinationVertex;
                Weight = weight;
            }

            public bool HasSetWeight(TEdge? weight) => weight != null;

            public int CompareTo(Edge<TEdge, TVertex>? other)
            {
                if (other == null) throw new ArgumentNullException(nameof(other));
                return Weight.CompareTo(other.Weight);
            }

            public override bool Equals(object? obj)
            {
                if (obj is not Edge<TEdge, TVertex> edge) return false;
                return Equals(edge);
            }

            protected bool Equals(Edge<TEdge, TVertex> other)
            {
                if (other == null) throw new ArgumentNullException(nameof(other));
                return InitialVertex == other.InitialVertex && DestinationVertex == other.DestinationVertex && Weight.Equals(other.Weight);
            }

            public override int GetHashCode()
            {
                return InitialVertex.GetHashCode() ^ DestinationVertex.GetHashCode() * Weight.GetHashCode();
            }

            public override string ToString()
            {
                return $"{InitialVertex} — ({Weight}) — {DestinationVertex}";
            }
        }
}
