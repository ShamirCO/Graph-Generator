using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    class Vertex
    {
        private Circle vertexCircle;
        private List<Edge> edgeList;

        public Vertex()
        {
            vertexCircle = new Circle();
            edgeList = new List<Edge>();
        }

        public Vertex(Circle newVertexCircle)
        {
            vertexCircle = newVertexCircle;
            edgeList = new List<Edge>();
        }

        public Circle VertexCircle
        {
            get { return vertexCircle; }
            set { vertexCircle = value; }
        }

        public List<Edge> EdgeList
        {
            get { return edgeList; }
            set { edgeList = value; }
        }

        public List<Edge> GetEdges()
        {
            List<Edge> allEdges = new List<Edge>();

            foreach (Edge currentEdge in edgeList)
            {
                allEdges.Add(currentEdge);
            }

            return allEdges;
        }

        public override string ToString()
        {
            return vertexCircle.ID.ToString() + ' ' + vertexCircle.Centre.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Vertex compareVertex = (Vertex)obj;

            if (vertexCircle.ID == compareVertex.VertexCircle.ID)
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return vertexCircle.GetHashCode();
        }
    }
}
