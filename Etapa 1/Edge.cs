using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Final_Project
{
    class Edge
    {
        public Vertex Origin { get; set; }
        public Vertex Destination { get; set; }
        public double Weight { get; set; }
        public List<Point> LinePoints { get; set; }

        public List<Prey> Preys { get; set; }
        public int NumberOfPredators { get; set; }

        public Edge()
        {
            Origin = new Vertex();
            Destination = new Vertex();
            LinePoints = new List<Point>();

            Preys = new List<Prey>();
            NumberOfPredators = 0;
        }

        public Edge(Vertex newOrigin, Vertex newDestination, List<Point> newLinePoints)
        {
            Origin = newOrigin;
            Destination = newDestination;
            Weight = Math.Sqrt(Math.Pow(newDestination.VertexCircle.Centre.X - newOrigin.VertexCircle.Centre.X, 2)
                + Math.Pow(newDestination.VertexCircle.Centre.Y - newOrigin.VertexCircle.Centre.Y, 2));
            LinePoints = newLinePoints;

            Preys = new List<Prey>();
            NumberOfPredators = 0;
        }

        public Edge Reverse()
        {
            return Destination.EdgeList.Find(Edge => Edge.Destination == Origin);
        }

        public override string ToString()
        {
            return Origin.VertexCircle.ID.ToString() + " → " + Destination.VertexCircle.ID.ToString() + " : " + Weight.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Edge compareEdge = (Edge)obj;

            if (Origin == compareEdge.Origin)
            {
                if (Destination == compareEdge.Destination)
                {
                    return true;
                }

                return false;
            }

            if (Origin == compareEdge.Destination)
            {
                if (Destination == compareEdge.Origin)
                {
                    return true;
                }

                return false;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Origin.GetHashCode() ^ Destination.GetHashCode();
        }
    }

    class CompareEdgesByWeight : IComparer<Edge>
    {
        public int Compare(Edge edgeOne, Edge edgeTwo)
        {
            if (edgeOne.Weight > edgeTwo.Weight)
            {
                return 1;
            }
            else if (edgeOne.Weight < edgeTwo.Weight)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
