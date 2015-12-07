using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPGraphs.GraphStructures;

namespace MPGraphs.GraphSearch
{
    public class BFS<T> : IGraphSearch<T>, IDisposable where T : class, IGraphRepresentation, new()
    {
        private List<int> Numbering;
        private int CurrentlyNumbered;
        private Queue<int> SearchQueue;
        private T Graph;
        private T Remaining;
        public BFS()
        {
            Numbering = new List<int>();
            CurrentlyNumbered = 0;
            SearchQueue = new Queue<int>();
            Graph = new T();
            Remaining = new T();
        }
        public void Dispose()
        {
        }

        /// <summary>
        /// Performs a search on a <paramref name="graph"/> starting from vertex == <paramref name="root"/>.
        /// </summary>
        /// <param name="graph">Graph to search.</param>
        /// <param name="root">Vertex to start the search from.</param>
        /// <returns>
        /// <c>SearchResult&lt;T&gt;</c> containing all the information about search results.
        /// </returns>
        /// <seealso cref="SearchResult{T}"/>
        public SearchResult<T> Search(T graph, int root)
        {
            for (int i = 0; i < graph.VertexCount; i++)
            {
                Numbering.Add(0);
                Graph.AddVertex();
                Remaining.AddVertex();
            }
            Numbering[root] = 1;
            CurrentlyNumbered = 1;
            SearchQueue.Enqueue(root);
            while (SearchQueue.Count > 0)
            {
                int v = SearchQueue.Dequeue();
                List<int> Iv = graph.FindAdjacentVertices(v);
                for (int i = 0; i < Iv.Count; i++)
                {
                    int w = Iv[i];
                    if (Numbering[w] == 0)
                    {
                        CurrentlyNumbered++;
                        Numbering[w] = CurrentlyNumbered;
                        Graph.AddEdge(v, w);
                        SearchQueue.Enqueue(w);
                    }
                    else if (Numbering[v] < Numbering[w])
                    {
                        Remaining.AddEdge(v, w);
                    }
                }
            }
            return new SearchResult<T>(Numbering, Graph, Remaining);
        }
        public void Clear()
        {
            Numbering = new List<int>();
            CurrentlyNumbered = 0;
            SearchQueue = new Queue<int>();
            Graph = new T();
            Remaining = new T();
        }
    }
}
