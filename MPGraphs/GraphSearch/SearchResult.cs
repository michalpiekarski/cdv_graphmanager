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
        public List<int> Numbering;
        public T Graph;
        public T Remaining;
        public SearchResult(List<int> numbering, T graph, T remaining)
        {
            Numbering = numbering;
            Graph = graph;
            Remaining = remaining;
        }
    }
}
