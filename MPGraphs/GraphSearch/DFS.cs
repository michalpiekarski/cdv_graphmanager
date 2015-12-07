using MPGraphs.GraphStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPGraphs.GraphSearch
{
    public class DFS<T> : IGraphSearch<T>, IDisposable where T : class, IGraphRepresentation, new()
    {
        private List<int> Numer;
        private int Ponumerowano;
        private Queue<int> Kolejka;
        private T Drzewo;
        private T Pozostałe;
        private bool FirstRun;
        public DFS()
        {
            Numer = new List<int>();
            Ponumerowano = 0;
            Kolejka = new Queue<int>();
            Drzewo = new T();
            Pozostałe = new T();
            FirstRun = true;
        }
        public void Clear()
        {
            Numer = new List<int>();
            Ponumerowano = 0;
            Kolejka = new Queue<int>();
            Drzewo = new T();
            Pozostałe = new T();
            FirstRun = true;
        }

        public void Dispose()
        {
        }

        public SearchResult<T> Search(T G, int x)
        {
            int v = x;
            if (FirstRun == true)
            {
                for (int i = 0; i < G.VertexCount; i++)
                {
                    Numer.Add(0);
                    Drzewo.AddVertex();
                    Pozostałe.AddVertex();
                }
                Ponumerowano = 1;
                Numer[v] = 1;
                FirstRun = false;
            }
            List<int> N = G.FindAdjacentEdges(v);
            foreach (int w in N)
            {
                if (Numer[w] == 0)
                {
                    Ponumerowano++;
                    Numer[w] = Ponumerowano;
                    Drzewo.AddEdge(v, w);
                    Search(G, w);
                }
                else if (Numer[w] < Numer[v])
                {
                    Pozostałe.AddEdge(v, w);
                }
            }
            return new SearchResult<T>(Numer, Drzewo, Pozostałe);
        }
    }
}
