using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPGraphs.GraphStructures
{
    public class AdjacencyMatrixWeighted : AdjacencyMatrix
    {
        private List<Tuple<int,int,int>> edgeWeights;
        public List<Tuple<int,int,int>> EdgeWeights
        {
            get
            {
                return edgeWeights;
            }
            set
            {
                if(value.Count == this.EdgeCount)
                {
                    this.edgeWeights = value;
                }
            }
        }
        public AdjacencyMatrixWeighted()
        {
            this.edgeWeights = new List<Tuple<int,int,int>>();
        }
        public AdjacencyMatrixWeighted(AdjacencyMatrixWeighted matrix) : base(matrix)
        {
            this.edgeWeights = matrix.EdgeWeights;
        }
        public AdjacencyMatrixWeighted(bool isDirected) : base(isDirected)
        {
            this.edgeWeights = new List<Tuple<int,int,int>>();
        }
        private Tuple<int,int,int> FindWeight(int vertexIndexA, int vertexIndexB)
        {
            foreach (Tuple<int, int, int> edgeWeight in this.edgeWeights)
            {
                if (edgeWeight.Item1 == vertexIndexA && edgeWeight.Item2 == vertexIndexB)
                {
                    return edgeWeight;
                }
            }
            return null;
        }
        public int? GetWeight(int vertexIndexA, int vertexIndexB)
        {
            if(FindEdge(vertexIndexA, vertexIndexB) == true)
            {
                Tuple<int, int, int> edgeWeight = FindWeight(vertexIndexA, vertexIndexB);
                if(edgeWeight != null)
                {
                    return edgeWeight.Item3;
                }
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
            this.edgeWeights.Add(new Tuple<int,int,int>(vertexIndexA,vertexIndexB,0));
            return base.AddEdge(vertexIndexA, vertexIndexB);
        }
        public bool AddEdge(int vertexIndexA, int vertexIndexB, int edgeWeight)
        {
            this.edgeWeights.Add(new Tuple<int,int,int>(vertexIndexA,vertexIndexB,edgeWeight));
            return base.AddEdge(vertexIndexA, vertexIndexB);
        }
        public override bool RemoveEdge(int vertexIndexA, int vertexIndexB)
        {
            bool edgeRemoved = base.RemoveEdge(vertexIndexA, vertexIndexB);
            if(edgeRemoved == true)
            {
                this.RemoveWeight(vertexIndexA, vertexIndexB);
            }
            return edgeRemoved;
        }

        public override bool MergeVertices(int vertexIndexA, int vertexIndexB)
        {
            bool verticesMerged = base.MergeVertices(vertexIndexA, vertexIndexB);
            if(verticesMerged == true)
            {
                this.RemoveWeight(vertexIndexA, vertexIndexB);
            }
            return verticesMerged;
        }
    }
}
