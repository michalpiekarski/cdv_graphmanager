using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPGraphs.GraphStructures
{
    class AdjacencyMatrix<T> : Matrix<T>, IGraphRepresentation
    {
        public void AddEdge(int vertexIndexA, int vertexIndexB)
        {
            throw new NotImplementedException();
        }

        public void AddVertex()
        {
            throw new NotImplementedException();
        }

        public bool FindEdge(int vertexIndexA, int vertexIndexB)
        {
            throw new NotImplementedException();
        }

        public bool RemoveEdge(int vertexIndexA, int vertexIndexB)
        {
            throw new NotImplementedException();
        }

        public bool RemoveVertex(int vertexIndex)
        {
            throw new NotImplementedException();
        }
    }
}
