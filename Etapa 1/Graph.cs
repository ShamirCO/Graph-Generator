using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Final_Project
{
    class Graph
    {
        // ATTRIBUTES
        public List<Vertex> VertexList { get; set; }

        // METHODS
        public Graph()
        {
            VertexList = new List<Vertex>();
        }

        public Graph(List<Circle> circleList, List<CirclePair> circlePairList)
        {
            VertexList = new List<Vertex>();

            Vertex newVertex, originVertex, destinationVertex;

            foreach (Circle currentCircle in circleList)
            {
                newVertex = new Vertex(currentCircle);

                VertexList.Add(newVertex);
            }

            foreach (CirclePair currentCirclePair in circlePairList)
            {
                originVertex = VertexList.Find(Vertex => Vertex.VertexCircle.Equals(currentCirclePair.OriginCircle));
                destinationVertex = VertexList.Find(Vertex => Vertex.VertexCircle.Equals(currentCirclePair.DestinationCircle));

                AddEdge(originVertex, destinationVertex, currentCirclePair.LinePoints);
            }
        }

        public Graph(List<Vertex> newVertexList, List<Edge> newEdgeList)
        {
            Vertex originVertex, destinationVertex;

            VertexList = newVertexList;

            foreach (Edge newEdge in newEdgeList)
            {
                originVertex = VertexList.Find(Vertex => Vertex.Equals(newEdge.Origin));

                if (originVertex != null)
                {
                    destinationVertex = VertexList.Find(Vertex => Vertex.Equals(newEdge.Destination));

                    AddEdge(originVertex, destinationVertex, newEdge.LinePoints);
                }
            }
        }

        public void Clear()
        {
            VertexList.Clear();
        }

        private void AddEdge(Vertex originVertex, Vertex destinationVertex, List<Point> linePoints)
        {
            List<Point> reversedLinePoints;
            Edge newEdge;
                
            newEdge = new Edge(originVertex, destinationVertex, linePoints);
            originVertex.EdgeList.Add(newEdge);

            reversedLinePoints = new List<Point>(linePoints);
            reversedLinePoints.Reverse();

            newEdge = new Edge(destinationVertex, originVertex, reversedLinePoints);
            destinationVertex.EdgeList.Add(newEdge);
        }

        public bool HasEdges()
        {
            foreach (Vertex currentVertex in VertexList)
            {
                if (currentVertex.EdgeList.Count != 0)
                {
                    return true;
                }
            }

            return false;
        }

        public List<Edge> GetEdges()
        {
            List<Edge> allEdges = new List<Edge>();

            foreach (Vertex currentVertex in VertexList)
            {
                foreach (Edge currentEdge in currentVertex.EdgeList)
                {
                    if (!allEdges.Contains(currentEdge))
                    {
                        allEdges.Add(currentEdge);
                    }
                }
            }

            return allEdges;
        }

        public double GetTotalWeight()
        {
            List<Edge> allEdges = GetEdges();
            double totalWeight = 0;

            foreach (Edge currentEdge in allEdges)
            {
                totalWeight += currentEdge.Weight;
            }

            return totalWeight;
        }
    }
}
