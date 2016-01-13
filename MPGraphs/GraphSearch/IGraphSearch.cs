using MPGraphs.GraphStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPGraphs.GraphSearch
{
    public interface IGraphSearch<T, V>
        where T : GraphRepresentation<V>, new()
        where V : struct
    {
        /// <summary>
        /// Performs a search on a <paramref name="graph"/> starting from vertex == <paramref name="root"/>.
        /// </summary>
        /// <param name="graph">Graph to search.</param>
        /// <param name="root">Vertex to start the search from.</param>
        /// <returns>
        /// <c>SearchResult&lt;T&gt;</c> containing all the information about search results.
        /// </returns>
        /// <seealso cref="SearchResult{T}"/>
        SearchResult<T, V> Search(T graph, int root);
        /// <summary>
        /// Reinitializes the search algorithm data for performing next search.
        /// </summary>
        void Clear();
    }
}
