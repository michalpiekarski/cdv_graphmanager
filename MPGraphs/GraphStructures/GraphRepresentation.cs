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
            IsDirected = false;
        }
        protected GraphRepresentation(bool isDirected) : base()
        {
            IsDirected = isDirected;
        }
        protected GraphRepresentation(GraphRepresentation<T> matrix) : base(matrix)
        {
            IsDirected = matrix.IsDirected;
        }
        #endregion Constructors
        #region Properties
        /// <summary>
        /// Returns the number of vertices in calling graph representation.
        /// </summary>
        public abstract int VertexCount
        {
            get;
        }
        /// <summary>
        /// Returns the number of edges in calling graph representation.
        /// </summary>
        public abstract int EdgeCount
        {
            get;
        }
        #endregion Properties
        #region Vertex Manipulation
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
        #endregion Vertex Manipulation
        #region Edge Manipulation
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
        #endregion Edge Manipulation
        /// <summary>
        /// Generates a complete graph with <paramref name="vertexCount"/> vertices.
        /// </summary>
        /// <param name="vertexCount">Number of vertices in generated complete graph.</param>
        public static R CompleteGraph<R, V>(int vertexCount)
            where R : GraphRepresentation<V>, new()
            where V : struct
        {
            R completeGraph = new R();
            for (int i = 0; i < vertexCount; i++)
            {
                completeGraph.AddVertex();
            }
            for (int i = 0; i < vertexCount; i++)
            {
                for (int j = 0; j < vertexCount; j++)
                {
                    if (i != j)
                    {
                        completeGraph.AddEdge(i, j);
                    }
                }
            }
            return completeGraph;
        }
        /// <summary>
        /// Finds all adjacent vertices to the vertex with index == <paramref name="vertexIndex"/>.
        /// </summary>
        /// <param name="vertexIndex">Index of the vertex that the adjacent vertices are to be found.</param>
        /// <returns>
        /// <c>List&lt;int&gt;</c> containing data needed to identify adjacent vertices in given graph representation.
        /// If no adjacent vertices are found, returns <c>null</c>.
        /// </returns>
        public List<int> FindAdjacentVertices(int vertexIndex)
        {
            List<int> adjacentVertices = null;
            int columnCount = ColumnCount.Item2;
            bool firstVertex = true;
            for (int i = 0; i < columnCount; i++)
            {
                if (FindEdge(vertexIndex, i) == true)
                {
                    if (firstVertex == true)
                    {
                        adjacentVertices = new List<int>();
                        firstVertex = false;
                    }
                    adjacentVertices.Add(i);
                }
            }
            return adjacentVertices;
        }
        /// <summary>
        /// Merges two specified vertices at indexes: <paramref name="vertexIndexA"/> and <paramref name="vertexIndexB"/>.
        /// </summary>
        /// <param name="vertexIndexA">Vertex index to merge into.</param>
        /// <param name="vertexIndexB">Vertex index to merge from.</param>
        /// <returns>
        /// If merging possible and both vertices exist, returns <c>true</c> (otherwise returns <c>false</c>).
        /// </returns>
        public abstract bool MergeVertices(int vertexIndexA, int vertexIndexB);
        protected abstract T MergeValue(T adjacencyA, T adjacencyB);
        /// <summary>
        /// Merges connected component from vertex with index == <paramref name="vertexIndex"/>.
        /// </summary>
        /// <param name="vertexIndex">Index of the vertex to merge the component from.</param>
        /// <returns>
        /// If graph merges to single vertex (aka. only 1 connected component) return <c>true</c> (otherwise return <c>false</c>).
        /// </returns>
        public abstract bool MergeComponent(int vertexIndex);
    }
}
