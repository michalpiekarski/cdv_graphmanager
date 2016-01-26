using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPGraphs.GraphStructures
{
    public class IncidenceMatrixWeighted : IncidenceMatrix
    {
        private List<Tuple<int,int,int>> edgeWeights;
        public List<Tuple<int,int,int>> EdgeWeights
        {
            get
            {
                return this.edgeWeights;
            }
            set
            {
                if(value.Count == this.EdgeCount)
                {
                    this.edgeWeights = value;
                }
            }
        }
        public IncidenceMatrixWeighted() : base()
        {
            this.edgeWeights = new List<Tuple<int,int,int>>();
        }

        public IncidenceMatrixWeighted(IncidenceMatrixWeighted matrix) : base(matrix)
        {
            this.edgeWeights = matrix.EdgeWeights;
        }

        public IncidenceMatrixWeighted(bool isDirected) : base(isDirected)
        {
            this.edgeWeights = new List<Tuple<int,int,int>>();
        }
        private Tuple<int,int,int> FindWeight(int vertexIndexA, int vertexIndexB)
        {
            foreach(Tuple<int,int,int> edgeWeight in this.edgeWeights)
            {
                if(edgeWeight.Item1 == vertexIndexA && edgeWeight.Item2 == vertexIndexB)
                {
                    return edgeWeight;
                }
            }
            return null;
        }
        public int? GetWeight(int vertexIndexA, int vertexIndexB)
        {
            Tuple<int, int, int> edgeWeight = FindWeight(vertexIndexA, vertexIndexB);
            if(edgeWeight != null)
            {
                return edgeWeight.Item3;
            }
            return null;
        }
        private bool RemoveWeight(int vertexIndexA, int vertexIndexB)
        {
            Tuple<int, int, int> edgeWeight = FindWeight(vertexIndexA, vertexIndexB);
            if(edgeWeight != null)
            {
                this.edgeWeights.Remove(edgeWeight);
                return true;
            }
            return false;
        }
        public override bool AddEdge(int vertexIndexA, int vertexIndexB)
        {
            return AddEdge(vertexIndexA, vertexIndexB, 0);
        }
        public bool AddEdge(int vertexIndexA, int vertexIndexB, int edgeWeight)
        {
            bool edgeAdded = base.AddEdge(vertexIndexA, vertexIndexB);
            if (edgeAdded == true)
            {
                this.edgeWeights.Add(new Tuple<int,int,int>(vertexIndexA,vertexIndexB,edgeWeight));
            }
            return edgeAdded;
        }

        public override bool RemoveEdge(int vertexIndexA, int vertexIndexB)
        {
            bool edgeRemoved = base.RemoveEdge(vertexIndexA, vertexIndexB);
            if (edgeRemoved)
            {
                RemoveWeight(vertexIndexA, vertexIndexB);
            }
            return edgeRemoved;
        }
        public override bool MergeVertices(int vertexIndexA, int vertexIndexB)
        {
            bool vertivesMerged = base.MergeVertices(vertexIndexA, vertexIndexB);
            if(vertivesMerged == true)
            {
                RemoveWeight(vertexIndexA, vertexIndexB);
            }
            return vertivesMerged;
        }
    }
}
