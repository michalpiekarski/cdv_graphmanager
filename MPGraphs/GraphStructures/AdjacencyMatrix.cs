using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPGraphs.GraphStructures
{
    public enum Adjacency
    {
        None = 0,
        Edge,
        Loop
    }
    public class AdjacencyMatrix : GraphRepresentation<Adjacency>
    {
        #region Constructors
        public AdjacencyMatrix()
        {
        }

        public AdjacencyMatrix(Matrix<Adjacency> matrix) : base(matrix)
        {
        }

        public AdjacencyMatrix(bool isDirected) : base(isDirected)
        {
        }

        public AdjacencyMatrix(bool isDirected, Matrix<Adjacency> matrix) : base(isDirected, matrix)
        {
        }
        #endregion Constructors
        #region Properties
        /// <summary>
        /// Returns the number of vertices in graph.
        /// </summary>
        public override int VertexCount
        {
            get
            {
                return RowCount;
            }
        }
        /// <summary>
        /// Returns the number of edges in graph.
        /// </summary>
        public override int EdgeCount
        {
            get
            {
                int edgeCount = 0;
                int rowCount = RowCount;
                int columnCount = ColumnCount.Item2;
                if (IsDirected)
                {
                    for (int i = 0; i < rowCount; i++)
                    {
                        List<Adjacency> row = GetRow(i);
                        for (int j = 0; j < columnCount; j++)
                        {
                            if (row[j] != Adjacency.None)
                            {
                                edgeCount++;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < rowCount; i++)
                    {
                        List<Adjacency> row = GetRow(i);
                        for (int j = i; j < columnCount; j++)
                        {
                            if (row[j] != Adjacency.None)
                            {
                                edgeCount++;
                            }
                        }
                    }
                }
                return edgeCount;
            }
        }
        #endregion Properties
        #region Vertex Manipulation
        /// <summary>
        /// Adds new vertex to graph representation.
        /// </summary>
        public override void AddVertex()
        {
            int columnCount = ColumnCount.Item2;
            List<Adjacency> row;
            if (columnCount > 0)
            {
                row = new List<Adjacency>(columnCount);
                for (int i = 0; i < columnCount; i++)
                {
                    row.Add(Adjacency.None);
                }
                AddRow(row);
                int rowCount = RowCount;
                List<Adjacency> column = new List<Adjacency>(rowCount);
                for (int i = 0; i < rowCount; i++)
                {
                    column.Add(Adjacency.None);
                }
                AddColumn(column);
            }
            else
            {
                row = new List<Adjacency>(1);
                row.Add(Adjacency.None);
                AddRow(row);
            }
        }

        /// <summary>
        /// Removes a specified vertex at index == <paramref name="vertexIndex"/> from graph representation if it exists.
        /// </summary>
        /// <param name="vertexIndex">Index of the vertex to remove from graph representation.</param>
        /// <returns>
        /// If the vertex at index == <paramref name="vertexIndex"/> doesn't exist, return <c>false</c> (otherwise return <c>true</c>).
        /// </returns>
        public override bool RemoveVertex(int vertexIndex)
        {
            int rowCount = RowCount;
            bool vertexRemoved = false;
            if (vertexIndex < rowCount)
            {
                RemoveRow(vertexIndex);
                RemoveColumn(vertexIndex);
                vertexRemoved = true;
            }
            return vertexRemoved;
        }
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
        public override bool AddEdge(int vertexIndexA, int vertexIndexB)
        {
            int rowCount = RowCount;
            bool edgeAdded = false;
            if (vertexIndexA < rowCount && vertexIndexB < rowCount)
            {
                if (vertexIndexA == vertexIndexB)
                {
                    this[vertexIndexA, vertexIndexB] = Adjacency.Loop;
                }
                else
                {
                    this[vertexIndexA, vertexIndexB] = Adjacency.Edge;
                    if (IsDirected == false)
                    {
                        this[vertexIndexB, vertexIndexA] = Adjacency.Edge;
                    }
                }
                edgeAdded = true;
            }
            return edgeAdded;
        }

        /// <summary>
        /// Removes an edge from the graph representation, between two vertices at indexes: <paramref name="vertexIndexA"/> and <paramref name="vertexIndexB"/> if it exists.
        /// </summary>
        /// <param name="vertexIndexA">First vertex of the edge.</param>
        /// <param name="vertexIndexB">Second vertex of the edge.</param>
        /// <returns>
        /// If the edge between two specified vertices doesn't exist, return <c>false</c> (otherwise returns <c>true</c>).
        /// </returns>
        public override bool RemoveEdge(int vertexIndexA, int vertexIndexB)
        {
            bool edgeRemoved = false;
            if (FindEdge(vertexIndexA, vertexIndexB) == true)
            {
                this[vertexIndexA, vertexIndexB] = Adjacency.None;
                if (IsDirected == false && vertexIndexA != vertexIndexB)
                {
                    this[vertexIndexB, vertexIndexA] = Adjacency.None;
                }
                edgeRemoved = true;
            }
            return edgeRemoved;
        }

        /// <summary>
        /// Checks if the edge between two specified vertices at indexes: <paramref name="vertexIndexA"/> and <paramref name="vertexIndexB"/> exists.
        /// </summary>
        /// <param name="vertexIndexA">First vertex of the edge.</param>
        /// <param name="vertexIndexB">Second vertex of the edge to find.</param>
        /// <returns>
        /// If the edge between specified vertices doesn't exist, returns <c>false</c> (otherwise returns <c>true</c>).
        /// </returns>
        public override bool FindEdge(int vertexIndexA, int vertexIndexB)
        {
            int rowCount = RowCount;
            bool edgeFound = false;
            if (vertexIndexA < rowCount && vertexIndexB < rowCount)
            {
                edgeFound = this[vertexIndexA, vertexIndexB] != Adjacency.None;
            }
            return edgeFound;
        }
        #endregion Edge Manipulation
    }
}
