using System.Collections;

namespace algForExam.Graph
{
    public class Vertex<TVertex, TEdge> : IComparable<Vertex<TVertex, TEdge>>, 
                                              IEnumerable<Edge<TEdge, TVertex>>
                                              where TVertex: IComparable 
                                              where TEdge : IComparable
        {
            private TVertex _data;

            public TVertex Data
            {
                get => _data;
                set
                {
                    if (!HasSetData(value)) throw new ArgumentNullException(nameof(value));
                    _data = value;
                }
            }

            public List<Edge<TEdge, TVertex>> EdgesList { get; protected set; }

            public Vertex(TVertex data, params Edge<TEdge, TVertex>[] edgeList)
            {
                Data = data;
                EdgesList = edgeList.ToList();
            }

            public bool HasSetData(TVertex? data) => data != null;

            public void Add(Edge<TEdge, TVertex> edge) => EdgesList.Add(edge);

            public int CompareTo(Vertex<TVertex, TEdge>? other)
            {
                if (other == null) throw new ArgumentNullException(nameof(other));
                return Data.CompareTo(other.Data);
            }

            public override bool Equals(object? obj)
            {
                if (obj is not Vertex<TVertex, TEdge> vertex) return false;
                return Equals(vertex);
            }

            protected bool Equals(Vertex<TVertex, TEdge> other)
            {
                if (other == null) throw new ArgumentNullException(nameof(other));
                if (EdgesList.Count != other.EdgesList.Count) return false;
                if (!Data.Equals(other.Data)) return false;

                foreach (var edge in EdgesList) if (!other.EdgesList.Contains(edge)) return false;

                return true;
            }

            public override int GetHashCode()
            {
                var hash = Data.ToString().GetHashCode() ^ EdgesList.Count;
                foreach (var edge in EdgesList) hash ^= edge.ToString().GetHashCode();

                return hash;
            }

            public IEnumerator<Edge<TEdge, TVertex>> GetEnumerator()
            {
                foreach (var edge in EdgesList)
                {
                    if (edge != null) yield return edge;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public override string ToString()
            {
                return $"{Data} — {EdgesList.Count} edges";
            }
        }
}
