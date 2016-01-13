using MPGraphs.GraphStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPGraphs.GraphSearch
{
    public class SearchResult<T, V>
        where T : GraphRepresentation<V>, new()
        where V : struct
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
