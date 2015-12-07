using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPGraphs.GraphStructures
{
    public abstract class GraphRepresentation<T> : Matrix<T>
    {
        public bool IsDirected;
        #region Constructors
        protected GraphRepresentation() : base()
        {
            this.IsDirected = false;
        }
        protected GraphRepresentation(bool isDirected) : base()
        {
            this.IsDirected = isDirected;
        }
        protected GraphRepresentation(Matrix<T> matrix) : base(matrix)
        {
            this.IsDirected = false;
        }
        protected GraphRepresentation(bool isDirected, Matrix<T> matrix) : base(matrix)
        {
            this.IsDirected = isDirected;
        }
        #endregion Constructors
        /// <summary>
        /// Adds new vertex to graph representation.
        /// </summary>
        public abstract void AddVertex();
        /// <summary>
        /// Removes a specified vertex at index == <paramref name="vertexIndex"/> from graph representation if it exists.
        /// </summary>
        /// <param name="vertexIndex">Index of the vertex to remove from graph representation.</param>
        /// <returns>
        /// If the vertex at index == <paramref name="vertexIndex"/> doesn't exist, return <c>false</c> (otherwise return <c>true</c>).
        /// </returns>
        public abstract bool RemoveVertex(int vertexIndex);
        /// <summary>
        /// Adds an edge to the graph representation, between two vertices at indexes: <paramref name="vertexIndexA"/> and <paramref name="vertexIndexB"/> if both those vertices exist.
        /// </summary>
        /// <param name="vertexIndexA">First vertex of the edge.</param>
        /// <param name="vertexIndexB">Second vertex of the edge.</param>
        /// <returns>
        /// If any of two specified vertices doesn't exist, returns <c>false</c> (otherwise returns <c>true</c>).
        /// </returns>
        public abstract bool AddEdge(int vertexIndexA, int vertexIndexB);
        /// <summary>
        /// Removes an edge from the graph representation, between two vertices at indexes: <paramref name="vertexIndexA"/> and <paramref name="vertexIndexB"/> if it exists.
        /// </summary>
        /// <param name="vertexIndexA">First vertex of the edge.</param>
        /// <param name="vertexIndexB">Second vertex of the edge.</param>
        /// <returns>
        /// If the edge between two specified vertices doesn't exist, return <c>false</c> (otherwise returns <c>true</c>).
        /// </returns>
        public abstract bool RemoveEdge(int vertexIndexA, int vertexIndexB);
        /// <summary>
        /// Checks if the edge between two specified vertices at indexes: <paramref name="vertexIndexA"/> and <paramref name="vertexIndexB"/> exists.
        /// </summary>
        /// <param name="vertexIndexA">First vertex of the edge.</param>
        /// <param name="vertexIndexB">Second vertex of the edge to find.</param>
        /// <returns>
        /// If the edge between specified vertices doesn't exist, returns <c>false</c> (otherwise returns <c>true</c>).
        /// </returns>
        public abstract bool FindEdge(int vertexIndexA, int vertexIndexB);
        /// <summary>
        /// Finds all adjacent edges to the edge with index == <paramref name="vertexIndex"/>.
        /// </summary>
        /// <param name="vertexIndex">Index of the vertex that the adjacent edges are to be found.</param>
        /// <returns>
        /// <c>List&lt;int&gt;</c> containing data needed to identify adjacent edges in given graph representation.
        /// If no adjacent edges are found, returns <c>null</c>.
        /// </returns>
        public List<int> FindAdjacentEdges(int vertexIndex)
        {
            List<int> adjacentEdges = new List<int>();
            int columnCount = this.ColumnCount.Item2;
            for (int i = 0; i < columnCount; i++)
            {
                if (this.FindEdge(vertexIndex, i) == true)
                {
                    adjacentEdges.Add(i);
                }
            }
            if (adjacentEdges.Count > 0)
            {
                return adjacentEdges;
            }
            else
            {
                return null;
            }
        }
    }
}
