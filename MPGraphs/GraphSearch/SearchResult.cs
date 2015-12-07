using MPGraphs.GraphStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPGraphs.GraphSearch
{
    public class SearchResult<T> where T : class, IGraphRepresentation, new()
    {
        public List<int> Numer;
        public T Drzewo;
        public T Pozostałe;
        public SearchResult(List<int> Numer, T Drzewo, T Pozostałe)
        {
            this.Numer = Numer;
            this.Drzewo = Drzewo;
            this.Pozostałe = Pozostałe;
        }
    }
}
