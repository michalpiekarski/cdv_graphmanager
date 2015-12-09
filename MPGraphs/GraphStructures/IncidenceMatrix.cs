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
        /// <summary>
        /// Merges two specified vertices at indexes: <paramref name="vertexIndexA"/> and <paramref name="vertexIndexB"/>.
        /// </summary>
        /// <param name="vertexIndexA">Vertex index to merge into.</param>
        /// <param name="vertexIndexB">Vertex index to merge from.</param>
        /// <returns>
        /// If merging possible and both vertices exist, returns <c>true</c> (otherwise returns <c>false</c>).
        /// </returns>
        public override bool MergeVertices(int vertexIndexA, int vertexIndexB)
        {
            int vertexCount = VertexCount;
            int edgeCount = EdgeCount;
            bool verticesMerged = false;
            if (vertexIndexA < vertexCount && vertexIndexB < vertexCount)
            {
                List<Incidence> vertexARow = GetRow(vertexIndexA);
                List<Incidence> vertexBRow = GetRow(vertexIndexB);
                for (int k = 0; k < edgeCount; k++)
                {
                    vertexARow[k] = MergeValue(vertexARow[k], vertexBRow[k]);
                }
                RemoveEdge(vertexIndexA, vertexIndexB);
                if(IsDirected == false)
                {
                    RemoveEdge(vertexIndexB, vertexIndexA);
                }
                RemoveVertex(vertexIndexB);
                verticesMerged = true;
            }
            return verticesMerged;
        }
        protected override Incidence MergeValue(Incidence incidenceA, Incidence incidenceB)
        {
            Incidence incidence = Incidence.Loop;
            if(incidenceA == incidenceB)
            {
                incidence = incidenceA;
            }
            else if (incidenceA == Incidence.None || incidenceB == Incidence.None)
            {
                if (incidenceA == Incidence.None)
                {
                    incidence = incidenceB;
                }
                else
                {
                    incidence = incidenceA;
                }
            }
            else if (incidenceA == Incidence.Loop || incidenceB == Incidence.Loop)
            {
                if (incidenceA == Incidence.Loop)
                {
                    incidence = incidenceB;
                }
                else
                {
                    incidence = incidenceA;
                }
            }
            return incidence;
        }
        /// <summary>
        /// Merges connected component from vertex with index == <paramref name="vertexIndex"/>.
        /// </summary>
        /// <param name="vertexIndex">Index of the vertex to merge the component from.</param>
        /// <returns>
        /// If graph merges to single vertex (aka. only 1 connected component) return <c>true</c> (otherwise return <c>false</c>).
        /// </returns>
        public override bool MergeComponent(int vertexIndex)
        {
            IncidenceMatrix m = new IncidenceMatrix(this);
            bool graphConnected = false;
            m.SwapRows(0, vertexIndex);
            do
            {
                List<Incidence> mergeRow = m.GetRow(0);
                int edgeCount = m.EdgeCount;
                int vertexCount = m.VertexCount;
                if (vertexCount == 1 || mergeRow.Count == 0)
                {
                    if(vertexCount == 1)
                    {
                        graphConnected = true;
                    } else
                    {
                        graphConnected = false;
                    } 
                    break;
                }
                int i = 0;
                while (i < edgeCount && mergeRow[i] != Incidence.Start)
                {
                    i++;
                }
                if (i == edgeCount && mergeRow[i - 1] != Incidence.Start)
                {
                    break;
                }
                else
                {
                    List<Incidence> edge = m.GetColumn(i);
                    for (int j = 1; j < vertexCount; j++)
                    {
                        if (m.IsDirected == true)
                        {
                            if (edge[j] == Incidence.End)
                            {
                                m.MergeVertices(0, j);
                                break;
                            }
                        }
                        else
                        {
                            if (edge[j] == Incidence.Start)
                            {
                                m.MergeVertices(0, j);
                                break;
                            }
                        }
                    }
                }
            } while (true);
            return graphConnected;
        }
    }
}
