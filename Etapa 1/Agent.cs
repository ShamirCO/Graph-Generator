using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Final_Project
{
    class Agent
    {
        // CONSTANTS
        const int LinePositionIncrement = 20;

        // ATTRIBUTES
        private int id;
        private Vertex originVertex;
        private List<Point> path;
        private List<Vertex> visitedVertexList;
        private List<Edge> visitedEdgeList;
        private int linePosition;

        public Agent(int newId, Vertex newOriginVertex)
        {
            id = newId;

            originVertex = newOriginVertex;

            path = new List<Point>();

            visitedVertexList = new List<Vertex>();

            visitedEdgeList = new List<Edge>();

            linePosition = 0;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public Vertex OriginVertex
        {
            get { return originVertex; }
            set { originVertex = value; }
        }

        public List<Point> Path
        {
            get { return path; }
            set { path = value; }
        }

        public List<Edge> VisitedEdgeList
        {
            get { return visitedEdgeList; }
            set { visitedEdgeList = value; }
        }

        public List<Vertex> VisitedVertexList
        {
            get { return visitedVertexList; }
            set { visitedVertexList = value; }
        }

        public int LinePosition
        {
            get { return linePosition; }
            set { linePosition = value; }
        }

        public void GenerateMSTPath()
        {
            List<Vertex> vertexesOnPath = new List<Vertex>() { originVertex };

            path.AddRange(GetMSTEdgesPath(originVertex, vertexesOnPath));
        }

        public List<Point> GetMSTEdgesPath(Vertex currentVertex, List<Vertex> vertexesOnPath)
        {
            List<Point> points = new List<Point>();
            Edge returnEdge = null;

            foreach (Edge currentEdge in currentVertex.EdgeList)
            {
                if (!vertexesOnPath.Contains(currentEdge.Destination))
                {
                    vertexesOnPath.Add(currentEdge.Destination);

                    visitedEdgeList.Add(currentEdge);

                    points.AddRange(currentEdge.LinePoints);

                    points.AddRange(GetMSTEdgesPath(currentEdge.Destination, vertexesOnPath));
                }
                else
                {
                    returnEdge = currentEdge;
                }
            }

            if (returnEdge != null)
            {
                visitedEdgeList.Add(returnEdge);

                points.AddRange(returnEdge.LinePoints);
            }

            return points;
        }

        public void GenerateRandomPath(Random randomNumberGenerator)
        {
            Vertex currentVertex = originVertex;
            Edge randomEdge;
            bool fullPath = false;

            visitedVertexList.Add(originVertex);

            while (!fullPath)
            {
                randomEdge = GetRandomEdge(randomNumberGenerator, currentVertex);

                if (randomEdge != null)
                {
                    path.AddRange(randomEdge.LinePoints);

                    currentVertex = randomEdge.Destination;

                    if (!visitedVertexList.Contains(currentVertex))
                    {
                        visitedVertexList.Add(currentVertex);
                    }
                }
                else
                {
                    fullPath = true;
                }
            }
        }

        private Edge GetRandomEdge(Random randomNumberGenerator, Vertex currentVertex)
        {
            List<Edge> availableEdges = new List<Edge>();
            Edge randomEdge;
            int randomEdgeIndex;

            foreach (Edge currentEdge in currentVertex.EdgeList)
            {
                if (!visitedEdgeList.Contains(currentEdge))
                {
                    availableEdges.Add(currentEdge);
                }
            }

            if (availableEdges.Count != 0)
            {
                randomEdgeIndex = randomNumberGenerator.Next(0, availableEdges.Count);
                randomEdge = availableEdges[randomEdgeIndex];

                visitedEdgeList.Add(randomEdge);

                return randomEdge;
            }

            return null;
        }

        public void UpdateLinePosition()
        {
            if (linePosition == path.Count - 1)
            {
                return;
            }

            linePosition += LinePositionIncrement;

            if (linePosition >= path.Count)
            {
                linePosition = path.Count - 1;
            }
        }

        public double GetDistanceTraveled()
        {
            double distanceTraveled = 0;

            foreach (Edge currentEdge in visitedEdgeList)
            {
                distanceTraveled += currentEdge.Weight;
            }

            return distanceTraveled;
        }
    }
}
