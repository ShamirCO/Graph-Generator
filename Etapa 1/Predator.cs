using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    class Predator
    {
        // CONSTANTS
        private const int EdgePositionIncrement = 20;

        // ATTRIBUTES
        public Vertex OriginVertex { get; set; }
        public Queue<Edge> Path { get; set; }
        public Edge CurrentEdge { get; set; }
        public int EdgePosition { get; set; }

        public bool HuntingMode { get; set; }
        public List<Prey> HuntedPreys { get; set; }

        // METHODS
        public Predator(int newID, Vertex newOriginVertex)
        {
            OriginVertex = newOriginVertex;
            Path = new Queue<Edge>();
            HuntingMode = false;
            HuntedPreys = new List<Prey>();
        }

        public void GeneratePath()
        {
            Stack<Vertex> vertexStack = new Stack<Vertex>();
            Stack<Edge> edgeStack = new Stack<Edge>();
            List<Vertex> visitedVertexes = new List<Vertex>();
            Queue<Edge> returnEdges = new Queue<Edge>();

            vertexStack.Push(OriginVertex);
            visitedVertexes.Add(OriginVertex);

            DepthFirstSearch(vertexStack, visitedVertexes, edgeStack, returnEdges);

            CurrentEdge = Path.Dequeue();
            CurrentEdge.NumberOfPredators++;
        }

        // (N - 1)(N - 2) = N^2 - 2N - N + 2 = N^2 - 3N + 2 = O(N^2)
        private void DepthFirstSearch(Stack<Vertex> vertexStack, List<Vertex> visitedVertexes, Stack<Edge> edgeStack, Queue<Edge> returnEdges)
        {
            Vertex currentVertex = vertexStack.Peek();

            foreach (Edge currentVertexEdge in currentVertex.EdgeList)
            {
                if (!visitedVertexes.Contains(currentVertexEdge.Destination))
                {
                    if (returnEdges.Count != 0)
                    {
                        while (returnEdges.Count != 0)
                        {
                            Path.Enqueue(returnEdges.Dequeue());
                        }
                    }

                    Path.Enqueue(currentVertexEdge);

                    visitedVertexes.Add(currentVertexEdge.Destination);
                    vertexStack.Push(currentVertexEdge.Destination);

                    DepthFirstSearch(vertexStack, visitedVertexes, edgeStack, returnEdges);
                }
                else
                {
                    if (vertexStack.Count != 1)
                    {
                        if (vertexStack.ElementAt(1) == currentVertexEdge.Destination)
                        {
                            edgeStack.Push(currentVertexEdge);
                        }
                    }
                }
            }

            if (edgeStack.Count != 0)
            {
                returnEdges.Enqueue(edgeStack.Pop());
            }

            vertexStack.Pop();
        }

        public void UpdateEdgePosition()
        {
            if (Path.Count == 0 && EdgePosition == CurrentEdge.LinePoints.Count - 1)
            {
                return;
            }
            
            EdgePosition += EdgePositionIncrement;

            if (EdgePosition >= CurrentEdge.LinePoints.Count)
            {
                CurrentEdge.NumberOfPredators--;

                if (Path.Count != 0)
                {
                    CurrentEdge = Path.Dequeue();
                    CurrentEdge.NumberOfPredators++;

                    if (CurrentEdge.Preys.Count != 0)
                    {
                        HuntingMode = true;
                    }
                    else if (CurrentEdge.Reverse().Preys.Count != 0)
                    {
                        HuntingMode = true;
                    }
                    else
                    {
                        if (HuntingMode)
                        {
                            HuntingMode = false;
                        }
                    }

                    /*if (CurrentEdge.Preys.Count != 0)
                    {
                        HuntingMode = true;

                        HuntingModeCase = (int)HuntingModeType.SameEdge;
                    }
                    else if (CurrentEdge.Reverse().Preys.Count != 0)
                    {
                        HuntingMode = true;

                        HuntingModeCase = (int)HuntingModeType.ReverseEdge;
                    }
                    else
                    {
                        if (HuntingMode)
                        {
                            HuntingMode = false;
                        }
                    }*/

                    EdgePosition = 0;
                }
                else
                {
                    EdgePosition = CurrentEdge.LinePoints.Count - 1;
                }
            }
        }

        // The name is pure rubbish, I should change it later
        // Can't get my G if he's in a safe zone
        public bool TryHunting()
        {
            if (CurrentEdge.Preys.Count == 0 && CurrentEdge.Reverse().Preys.Count == 0)
            {
                HuntingMode = false;

                return false;
            }

            foreach (Prey currentPrey in CurrentEdge.Preys)
            {
                if (EdgePosition >= currentPrey.EdgePosition)
                {
                    HuntedPreys.Add(currentPrey);
                }
            }

            foreach (Prey currentPrey in CurrentEdge.Reverse().Preys)
            {
                if (CurrentEdge.LinePoints.Count - 1 - EdgePosition <= currentPrey.EdgePosition)
                {
                    HuntedPreys.Add(currentPrey);
                }
            }

            if (HuntedPreys.Count != 0)
            {
                return true;
            }

            return false;
        }
    }
}
