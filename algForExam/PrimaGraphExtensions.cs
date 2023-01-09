using algForExam.Graph;

namespace algForExam
{
    public static class PrimaGraphExtensions
    {
        public static (IList<Edge<int, TVertex>>, int) Prima<TVertex>(this Graph<TVertex, int> graph) where TVertex : IComparable
        {
            var minCost = 0;

            var notVisitedVertices = graph.Vertices.ToList();
            var visitedVertices = new List<Vertex<TVertex, int>>();

            var notVisitedEdges = graph.Edges.ToList();
            var visitedEdges = new List<Edge<int, TVertex>>();

            if (graph.Vertices.Count > 0)
            {
                // Выбираем первую вершину для просмотра
                var visitedVertex = notVisitedVertices[0];
                visitedVertices.Add(visitedVertex);
                notVisitedVertices.Remove(visitedVertex);

                while (notVisitedVertices.Count > 0)
                {
                    var indexMinEdge = -1;

                    for (var i = 0; i < notVisitedEdges.Count; i++) // Обходим не посещённые вершины
                    {
                        if (visitedVertices.IndexOf(notVisitedEdges[i].InitialVertex) != -1 && notVisitedVertices.IndexOf(notVisitedEdges[i].DestinationVertex) != -1 || 
                            visitedVertices.IndexOf(notVisitedEdges[i].DestinationVertex) != -1 && notVisitedVertices.IndexOf(notVisitedEdges[i].InitialVertex) != -1)
                        {
                            if (indexMinEdge != -1)
                            {
                                if (notVisitedEdges[i].Weight < notVisitedEdges[indexMinEdge].Weight) indexMinEdge = i;
                            }
                            else
                            {
                                indexMinEdge = i;
                            }
                        }
                    }

                    if (visitedVertices.IndexOf(notVisitedEdges[indexMinEdge].InitialVertex) != -1) // Проверка, что посещёна
                    {
                        visitedVertices.Add(notVisitedEdges[indexMinEdge].DestinationVertex);
                        notVisitedVertices.Remove(notVisitedEdges[indexMinEdge].DestinationVertex);
                    }
                    else
                    {
                        visitedVertices.Add(notVisitedEdges[indexMinEdge].InitialVertex);
                        notVisitedVertices.Remove(notVisitedEdges[indexMinEdge].InitialVertex);
                    }

                    visitedEdges.Add(notVisitedEdges[indexMinEdge]);
                    minCost += notVisitedEdges[indexMinEdge].Weight;
                    notVisitedEdges.RemoveAt(indexMinEdge);
                }
            }

            return (visitedEdges, minCost);
        }
    }
}
