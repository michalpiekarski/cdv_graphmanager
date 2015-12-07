using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPGraphs.GraphStructures
{
    public interface IGraphRepresentation
    {
        /// <summary>
        /// Adds new vertex to graph representation.
        /// </summary>
        void AddVertex();
        /// <summary>
        /// Removes a specified vertex at index == <paramref name="vertexIndex"/> from graph representation if it exists.
        /// </summary>
        /// <param name="vertexIndex">Index of the vertex to remove from graph representation.</param>
        /// <returns>
        /// If the vertex at index == <paramref name="vertexIndex"/> doesn't exist, return <c>false</c> (otherwise return <c>true</c>).
        /// </returns>
        bool RemoveVertex(int vertexIndex);
        /// <summary>
        /// Adds an edge to the graph representation, between two vertices at indexes: <paramref name="vertexIndexA"/> and <paramref name="vertexIndexB"/> if both those vertices exist.
        /// </summary>
        /// <param name="vertexIndexA">First vertex of the edge.</param>
        /// <param name="vertexIndexB">Second vertex of the edge.</param>
        /// <returns>
        /// If any of two specified vertices doesn't exist, returns <c>false</c> (otherwise returns <c>true</c>).
        /// </returns>
        bool AddEdge(int vertexIndexA, int vertexIndexB);
        /// <summary>
        /// Removes an edge from the graph representation, between two vertices at indexes: <paramref name="vertexIndexA"/> and <paramref name="vertexIndexB"/> if it exists.
        /// </summary>
        /// <param name="vertexIndexA">First vertex of the edge.</param>
        /// <param name="vertexIndexB">Second vertex of the edge.</param>
        /// <returns>
        /// If the edge between two specified vertices doesn't exist, return <c>false</c> (otherwise returns <c>true</c>).
        /// </returns>
        bool RemoveEdge(int vertexIndexA, int vertexIndexB);
        /// <summary>
        /// Checks if the edge between two specified vertices at indexes: <paramref name="vertexIndexA"/> and <paramref name="vertexIndexB"/> exists.
        /// </summary>
        /// <param name="vertexIndexA">First vertex of the edge.</param>
        /// <param name="vertexIndexB">Second vertex of the edge to find.</param>
        /// <returns>
        /// If the edge between specified vertices doesn't exist, returns <c>false</c> (otherwise returns <c>true</c>).
        /// </returns>
        bool FindEdge(int vertexIndexA, int vertexIndexB);
        /// <summary>
        /// Finds all adjacent edges to the edge with index == <paramref name="vertexIndex"/>.
        /// </summary>
        /// <param name="vertexIndex">Index of the vertex that the adjacent edges are to be found.</param>
        /// <returns>
        /// <c>List&lt;int&gt;</c> containing data needed to identify adjacent edges in given graph representation.
        /// If no adjacent edges are found, returns <c>null</c>.
        /// </returns>
        List<int> FindAdjacentEdges(int vertexIndex);
        /// <summary>
        /// Returns the number of vertices in calling graph representation.
        /// </summary>
        int VertexCount
        {
            get;
        }
        /// <summary>
        /// Returns the number of edges in calling graph representation.
        /// </summary>
        int EdgeCount
        {
            get;
        }
    }
}
