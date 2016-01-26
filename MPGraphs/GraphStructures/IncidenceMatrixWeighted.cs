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

        public IncidenceMatrixWeighted(IncidenceMatrix matrix) : base(matrix)
        {
            this.edgeWeights = new List<Tuple<int, int, int>>(EdgeCount);
            for (int i = 0; i < VertexCount; i++)
            {
                for (int j = 0; j < VertexCount; j++)
                {
                    if (FindEdge(i, j) == true)
                    {
                        this.edgeWeights.Add(new Tuple<int, int, int>(i, j, 0));
                    }
                }
            }
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
                if(IsDirected == false)
                {
                    this.edgeWeights.Add(new Tuple<int, int, int>(vertexIndexB, vertexIndexA, edgeWeight));
                }
            }
            return edgeAdded;
        }

        public override bool RemoveEdge(int vertexIndexA, int vertexIndexB)
        {
            bool edgeRemoved = base.RemoveEdge(vertexIndexA, vertexIndexB);
            if (edgeRemoved)
            {
                RemoveWeight(vertexIndexA, vertexIndexB);
                if(IsDirected == false)
                {
                    RemoveWeight(vertexIndexB, vertexIndexA);
                }
            }
            return edgeRemoved;
        }
        public override bool MergeVertices(int vertexIndexA, int vertexIndexB)
        {
            bool vertivesMerged = base.MergeVertices(vertexIndexA, vertexIndexB);
            if(vertivesMerged == true)
            {
                RemoveWeight(vertexIndexA, vertexIndexB);
                if(IsDirected == false)
                {
                    RemoveWeight(vertexIndexB, vertexIndexA);
                }
            }
            return vertivesMerged;
        }
        public override GraphRepresentation<Incidence> ConvertToUndirected()
        {
            IncidenceMatrixWeighted undirectedGraph = base.ConvertToUndirected() as IncidenceMatrixWeighted;
            if(undirectedGraph != null)
            {
                foreach (Tuple<int, int, int> edgeWeight in undirectedGraph.edgeWeights)
                {
                    Tuple<int, int, int> otherWeight = undirectedGraph.FindWeight(edgeWeight.Item2, edgeWeight.Item1);
                    if (otherWeight == null)
                    {
                        undirectedGraph.edgeWeights.Add(new Tuple<int, int, int>(edgeWeight.Item2, edgeWeight.Item1, edgeWeight.Item3));
                    }
                    else
                    {
                        if (otherWeight.Item3 < edgeWeight.Item3)
                        {
                            undirectedGraph.edgeWeights.Remove(edgeWeight);
                            undirectedGraph.edgeWeights.Add(new Tuple<int, int, int>(otherWeight.Item2, otherWeight.Item1, otherWeight.Item3));
                        }
                        else if (otherWeight.Item3 > edgeWeight.Item3)
                        {
                            undirectedGraph.edgeWeights.Remove(otherWeight);
                            undirectedGraph.edgeWeights.Add(new Tuple<int, int, int>(edgeWeight.Item2, edgeWeight.Item1, edgeWeight.Item3));
                        }
                    }
                }
            }
            return undirectedGraph;
        }
        public IncidenceMatrixWeighted FindMST()
        {
            List<List<int>> sets = new List<List<int>>(VertexCount);
            IncidenceMatrixWeighted Drzewo = new IncidenceMatrixWeighted();
            for (int i = 0; i < VertexCount; i++)
            {
                sets.Add(new List<int>() { i });
                Drzewo.AddVertex();
            }
            List<Tuple<int, int, int>> E = new List<Tuple<int, int, int>>(edgeWeights);
            E.Sort((a, b) =>
            {
                if (a.Item3 > b.Item3)
                {
                    return 1;
                }
                else if (a.Item3 == b.Item3)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            });
            int k = 0;
            do
            {
                Tuple<int, int, int> ek = E[k]; // kolejna krawędź z posortowanego zbioru E
                if (sets[ek.Item1] != sets[ek.Item2])
                {
                    Drzewo.AddEdge(ek.Item1, ek.Item2, ek.Item3);
                    List<int> subsetU = new List<int>(sets[ek.Item1].Union(sets[ek.Item2]));
                    sets[ek.Item2] = new List<int>(sets[ek.Item2].Union(sets[ek.Item1]));
                    sets[ek.Item1] = subsetU;
                }
                k++;
                if (IsDirected == false)
                {
                    k++;
                }
            } while ((Drzewo.EdgeCount < VertexCount - 1) && (k < E.Count));
            if (Drzewo.EdgeCount != VertexCount - 1) //Wynikowy graf nie jest spójny
            {
                return null;
            }
            return Drzewo;
        }
    }
}
