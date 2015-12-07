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
        private List<int> Numer;
        private int Ponumerowano;
        private Queue<int> Kolejka;
        private T Drzewo;
        private T Pozostałe;
        public BFS()
        {
            this.Numer = new List<int>();
            this.Ponumerowano = 0;
            this.Kolejka = new Queue<int>();
            this.Drzewo = new T();
            this.Pozostałe = new T();
        }
        public void Dispose()
        {
        }

        public SearchResult<T> Search(T Graph, int Root)
        {
            for (int i = 0; i < G.VertexCount; i++)
            {
                this.Numer.Add(0);
                this.Drzewo.AddVertex();
                this.Pozostałe.AddVertex();
            }
            Numer[x] = 1;
            Ponumerowano = 1;
            Kolejka.Enqueue(x);
            while (Kolejka.Count > 0)
            {
                int v = Kolejka.Dequeue();
                List<int> Iv = G.FindAdjacentEdges(v);
                for (int i = 0; i < Iv.Count; i++)
                {
                    int w = Iv[i];
                    if (Numer[w] == 0)
                    {
                        Ponumerowano = Ponumerowano + 1;
                        Numer[w] = Ponumerowano;
                        Drzewo.AddEdge(v, w);
                        Kolejka.Enqueue(w);
                    }
                    else { Pozostałe.AddEdge(v, w); }
                }
            }
            return new SearchResult<T>(Numer, Drzewo, Pozostałe);
        }
        public void Clear()
        {
            this.Numer = new List<int>();
            this.Ponumerowano = 0;
            this.Kolejka = new Queue<int>();
            this.Drzewo = new T();
            this.Pozostałe = new T();
        }
    }
}
