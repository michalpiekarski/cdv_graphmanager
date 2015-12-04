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
        Incident
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
            List<Incidence> row = new List<Incidence>(columnCount);
            for (int i = 0; i < columnCount; i++)
            {
                row.Add(Incidence.None);
            }
            this.AddRow(row);
            int rowCount = this.RowCount;
            List<Incidence> column = new List<Incidence>(rowCount);
            for (int i = 0; i < rowCount; i++)
            {
                column.Add(Incidence.None);
            }
            this.AddColumn(column);
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
                this.RemoveColumn(vertexIndex);
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
                this[vertexIndexA, vertexIndexB] = Incidence.Incident;
                if (this.isDirected == false)
                {
                    this[vertexIndexB, vertexIndexA] = Incidence.Incident;
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
                return this[vertexIndexA, vertexIndexB] != Incidence.None;
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
                this[vertexIndexA, vertexIndexB] = Incidence.None;
                if (this.isDirected == false && vertexIndexA != vertexIndexB)
                {
                    this[vertexIndexB, vertexIndexA] = Incidence.None;
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
