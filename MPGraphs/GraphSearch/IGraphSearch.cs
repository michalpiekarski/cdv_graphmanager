using MPGraphs.GraphStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPGraphs.GraphSearch
{
    public interface IGraphSearch<T> where T : class, IGraphRepresentation, new()
    {
        SearchResult<T> Search(T Graph, int root);
        void Clear();
    }
}
