﻿using System;
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
    class IncidenceMatrix : GraphRepresentation<Incidence>
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
        /// Adds an edge to the graph representation, between two vertices at indexes: <paramref name="vertexIndexA"/> and <paramref name="vertexIndexB"/> if both those vertices exist.
        /// </summary>
        /// <param name="vertexIndexA">First vertex of the edge.</param>
        /// <param name="vertexIndexB">Second vertex of the edge.</param>
        /// <returns>
        /// If any of two specified vertices doesn't exist, returns <c>false</c> (otherwise returns <c>true</c>).
        /// </returns>
        public override bool AddEdge(int vertexIndexA, int vertexIndexB)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds new vertex to graph representation.
        /// </summary>
        public override void AddVertex()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}