using algForExam.Graph;

namespace algForExam
{
    public static class KruskalGraphExtensions
    {
        /// <summary> Класс подмножество для алгоритма Union-find</summary>
        private class Subset<TVertex, TEdge> where TVertex : IComparable where TEdge : IComparable
        {
            public  Vertex<TVertex, TEdge>  Parent { get; set; }

            public int Rank { get; set; }
        }

        /// <summary> Метод выполняющий поиск, сжатия пути </summary>
        private static Vertex<TVertex, TEdge> Find<TVertex, TEdge>(IReadOnlyDictionary<Vertex<TVertex, TEdge>, Subset<TVertex, TEdge>> subsets, Vertex<TVertex, TEdge> parent) where TVertex : IComparable where TEdge : IComparable
        {
            // Идея: сделать найденный корень родителем 
            if (subsets[parent].Parent != parent)
                subsets[parent].Parent = Find(subsets, subsets[parent].Parent);

            return subsets[parent].Parent;
        }

        /// <summary> Метод объединения вершин для Union-find </summary>
        private static void Union<TVertex, TEdge>(IReadOnlyDictionary<Vertex<TVertex, TEdge>, Subset<TVertex, TEdge>> subsets, Vertex<TVertex, TEdge> vertex1, Vertex<TVertex, TEdge> vertex2) where TVertex : IComparable where TEdge : IComparable
        {
            var xRoot = Find(subsets, vertex1);
            var yRoot = Find(subsets, vertex2);

            // Идея: подкреплять дерево меньшей глубины под корень более глубокого дерева
            if (subsets[xRoot].Rank < subsets[yRoot].Rank)
            {
                subsets[xRoot].Parent = yRoot;
            }
            else if (subsets[xRoot].Rank > subsets[yRoot].Rank)
            {
                subsets[yRoot].Parent = xRoot;
            }
            else
            {
                subsets[yRoot].Parent = xRoot;
                ++subsets[xRoot].Rank;
            }
        }

        public static (IList<Edge<int, TVertex>>, int) Kruskal<TVertex>(this Graph<TVertex, int> graph) where TVertex : IComparable
        {
            var verticesCount = graph.Vertices.Count;
            var edges = graph.Edges.ToList();
            var result = new List<Edge<int, TVertex>>();

            var edgesCounter = 0;
            var verticesCounter = 0;
            var minCost = 0;

            edges.Sort();

            var subsets = new System.Collections.Generic.Dictionary<Vertex<TVertex, int>, Subset<TVertex, int>>();

            foreach (var vertex in graph.Vertices) // Массив множеств, вершины сами себе родители
            {
                subsets.Add(vertex, new Subset<TVertex, int>() {Parent = vertex, Rank = 0});
            }

            while (verticesCounter < verticesCount - 1)
            {
                var nextEdge = edges[edgesCounter++];

                var x = Find(subsets, nextEdge.InitialVertex);
                var y = Find(subsets, nextEdge.DestinationVertex);

                if (x != y)
                {
                    result.Add(nextEdge);
                    minCost += nextEdge.Weight;
                    verticesCounter++;

                    Union(subsets, x, y);
                }
            }

            return (result, minCost);
        }
    }
}
