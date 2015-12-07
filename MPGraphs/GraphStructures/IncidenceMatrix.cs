using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPGraphs.GraphStructures
{
    public enum Incidence
    {
        None = 0,
        Start,
        End,
        Loop
    }
    public class IncidenceMatrix : GraphRepresentation<Incidence>
    {
        #region Constructors
        public IncidenceMatrix()
        {
        }

        public IncidenceMatrix(Matrix<Incidence> matrix) : base(matrix)
        {
        }

        public IncidenceMatrix(bool isDirected) : base(isDirected)
        {
        }

        public IncidenceMatrix(bool isDirected, Matrix<Incidence> matrix) : base(isDirected, matrix)
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
                return ColumnCount.Item2;
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
            columnCount = Math.Max(1, columnCount);
            List<Incidence> vertex = new List<Incidence>(columnCount);
            for (int i = 0; i < columnCount; i++)
            {
                vertex.Add(Incidence.None);
            }
            AddRow(vertex);
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
                List<Incidence> edge = new List<Incidence>(rowCount);
                bool isDirected = IsDirected;
                for (int i = 0; i < rowCount; i++)
                {
                    if (i == vertexIndexA)
                    {
                        if (vertexIndexA == vertexIndexB)
                        {
                            edge.Add(Incidence.Loop);
                        }
                        else
                        {
                            edge.Add(Incidence.Start);
                        }
                    }
                    else if (i == vertexIndexB && vertexIndexA != vertexIndexB)
                    {
                        if (isDirected == true)
                        {
                            edge.Add(Incidence.End);
                        }
                        else
                        {
                            edge.Add(Incidence.Start);
                        }
                    }
                    else
                    {
                        edge.Add(Incidence.None);
                    }
                }
                if (ColumnCount.Item2 == 1)
                {
                    bool noEdges = true;
                    foreach (Incidence incidence in GetColumn(0))
                    {
                        if (incidence != Incidence.None)
                        {
                            noEdges = false;
                            break;
                        }
                    }
                    if (noEdges == true)
                    {
                        ReplaceColumn(0, edge);
                    }
                    else
                    {
                        AddColumn(edge);
                    }
                }
                else
                {
                    AddColumn(edge);
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
                int columnCount = ColumnCount.Item2;
                bool isDirected = IsDirected;
                for (int i = 0; i < columnCount; i++)
                {
                    List<Incidence> edge = GetColumn(i);
                    if (vertexIndexA == vertexIndexB)
                    {
                        if (edge[vertexIndexA] == Incidence.Loop)
                        {
                            RemoveColumn(i);
                            break;
                        }
                    }
                    else
                    {
                        if (isDirected == true)
                        {
                            if (edge[vertexIndexA] == Incidence.Start && edge[vertexIndexB] == Incidence.End)
                            {
                                RemoveColumn(i);
                                break;
                            }
                        }
                        else
                        {
                            if (edge[vertexIndexA] == Incidence.Start && edge[vertexIndexB] == Incidence.Start)
                            {
                                RemoveColumn(i);
                                break;
                            }
                        }
                    }
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
                int columnCount = ColumnCount.Item2;
                bool isDirected = IsDirected;
                for (int i = 0; i < columnCount; i++)
                {
                    List<Incidence> edge = GetColumn(i);
                    if (vertexIndexA == vertexIndexB)
                    {
                        if (edge[vertexIndexA] == Incidence.Loop)
                        {
                            edgeFound = true;
                            break;
                        }
                    }
                    else
                    {
                        if (isDirected == true)
                        {
                            if (edge[vertexIndexA] == Incidence.Start && edge[vertexIndexB] == Incidence.End)
                            {
                                edgeFound = true;
                                break;
                            }
                        }
                        else
                        {
                            if (edge[vertexIndexA] == Incidence.Start && edge[vertexIndexB] == Incidence.Start)
                            {
                                edgeFound = true;
                                break;
                            }
                        }
                    }
                }
            }
            return edgeFound;
        }
        #endregion Edge Manipulation
    }
}
