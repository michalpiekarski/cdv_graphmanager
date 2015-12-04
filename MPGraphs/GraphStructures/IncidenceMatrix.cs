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

        /// <summary>
        /// Adds new vertex to graph representation.
        /// </summary>
        public override void AddVertex()
        {
            int columnCount = this.ColumnCount.Item2;
            columnCount = Math.Max(1, columnCount);
            List <Incidence> vertex = new List<Incidence>(columnCount);
            for (int i = 0; i < columnCount; i++)
            {
                vertex.Add(Incidence.None);
            }
            this.AddRow(vertex);
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
            int rowCount = this.RowCount;
            if (vertexIndex < rowCount)
            {
                this.RemoveRow(vertexIndex);
                return true;
            }
            else
            {
                return false;
            }
        }

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
            int rowCount = this.RowCount;
            if (vertexIndexA < rowCount && vertexIndexB < rowCount)
            {
                List<Incidence> edge = new List<Incidence>(rowCount);
                bool isDirected = this.IsDirected;
                for (int i = 0; i < rowCount; i++)
                {
                    if (i == vertexIndexA)
                    {
                        if(vertexIndexA == vertexIndexB)
                        {
                            edge.Add(Incidence.Loop);
                        } else
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
                if(this.ColumnCount.Item2 == 1)
                {
                    bool noEdges = true;
                    foreach(Incidence incidence in this.GetColumn(0))
                    {
                        if(incidence != Incidence.None)
                        {
                            noEdges = false;
                            break;
                        }
                    }
                    if (noEdges == true)
                    {
                        this.ReplaceColumn(0, edge);
                    }
                    else
                    {
                        this.AddColumn(edge);
                    }
                } else
                {
                    this.AddColumn(edge);
                }
                return true;
            }
            else
            {
                return false;
            }
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
            int rowCount = this.RowCount;
            if (vertexIndexA < rowCount && vertexIndexB < rowCount)
            {
                int columnCount = this.ColumnCount.Item2;
                bool isDirected = this.IsDirected;
                for (int i = 0; i < columnCount; i++)
                {
                    List<Incidence> edge = this.GetColumn(i);
                    if(vertexIndexA == vertexIndexB)
                    {
                        if(edge[vertexIndexA] == Incidence.Loop)
                        {
                            return true;
                        }
                    } else
                    {
                        if (isDirected == true)
                        {
                            if (edge[vertexIndexA] == Incidence.Start && edge[vertexIndexB] == Incidence.End)
                            {
                                return true;
                            }
                        }
                        else
                        {
                            if (edge[vertexIndexA] == Incidence.Start && edge[vertexIndexB] == Incidence.Start)
                            {
                                return true;
                            }
                        }
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
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
            if (this.FindEdge(vertexIndexA, vertexIndexB) == true)
            {
                int columnCount = this.ColumnCount.Item2;
                bool isDirected = this.IsDirected;
                for (int i = 0; i < columnCount; i++)
                {
                    List<Incidence> edge = this.GetColumn(i);
                    if(vertexIndexA == vertexIndexB)
                    {
                        if(edge[vertexIndexA] == Incidence.Loop)
                        {
                            this.RemoveColumn(i);
                            break;
                        }
                    } else
                    {
                        if (isDirected == true)
                        {
                            if (edge[vertexIndexA] == Incidence.Start && edge[vertexIndexB] == Incidence.End)
                            {
                                this.RemoveColumn(i);
                                break;
                            }
                        }
                        else
                        {
                            if (edge[vertexIndexA] == Incidence.Start && edge[vertexIndexB] == Incidence.Start)
                            {
                                this.RemoveColumn(i);
                                break;
                            }
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
