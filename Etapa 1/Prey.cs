using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    class Prey
    {
        // INTERNAL CLASS
        public class DijkstraElement
        {
            // ATTRIBUTES
            public Vertex IDVertex { get; set; }
            public double AccumulatedDistance { get; set; }
            public DijkstraElement PreviousDijkstraElement { get; set; }

            // METHODS
            public DijkstraElement(Vertex newIDVertex)
            {
                IDVertex = newIDVertex;

                AccumulatedDistance = double.PositiveInfinity;
            }
        }

        class CompareDijkstraElementsByAccumulatedDistance : IComparer<DijkstraElement>
        {
            public int Compare(DijkstraElement dijkstraElementOne, DijkstraElement dijkstraElementTwo)
            {
                if (dijkstraElementOne.AccumulatedDistance > dijkstraElementTwo.AccumulatedDistance)
                {
                    return 1;
                }
                else if (dijkstraElementOne.AccumulatedDistance < dijkstraElementTwo.AccumulatedDistance)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }

        // CONSTANTS
        private const int EdgePositionIncrement = 20;

        // ATTRIBUTES
        public int ID { get; set; }
        public bool IsActive { get; set; }
        public Vertex OriginVertex { get; set; }
        public Queue<Edge> Path { get; set; }
        public Edge CurrentEdge { get; set; }
        public int EdgePosition { get; set; }
        public List<DijkstraElement> DijkstraElements { get; set; }

        public bool OnSafeZone { get; set; }
        public bool SurvivalMode { get; set; }

        // METHODS
        public Prey()
        {
            IsActive = false;
            Path = new Queue<Edge>();
            EdgePosition = 0;
            DijkstraElements = new List<DijkstraElement>();

            OnSafeZone = true;
            SurvivalMode = false;
        }

        public Prey(int newID, Vertex newOriginVertex)
        {
            ID = newID;
            OriginVertex = newOriginVertex;

            IsActive = false;
            Path = new Queue<Edge>();
            EdgePosition = 0;
            DijkstraElements = new List<DijkstraElement>();

            OnSafeZone = true;
            SurvivalMode = false;
        }

        public void GeneratePath(List<Vertex> graphVertexes, Vertex destinationVertex)
        {
            DijkstraElement pathDijkstraElement;
            Edge pathEdge;

            GetShortestPathsWithDijkstra(graphVertexes, destinationVertex);

            pathDijkstraElement = DijkstraElements.Find(DijkstraElement => DijkstraElement.IDVertex.Equals(destinationVertex));

            do
            {
                pathEdge = pathDijkstraElement.PreviousDijkstraElement.IDVertex.EdgeList.Find(Edge => Edge.Destination.Equals(pathDijkstraElement.IDVertex));

                if (pathEdge != null)
                {
                    Path.Enqueue(pathEdge);

                    pathDijkstraElement = pathDijkstraElement.PreviousDijkstraElement;
                }
            }
            while (!pathDijkstraElement.IDVertex.Equals(OriginVertex));

            Path = new Queue<Edge>(Path.Reverse());

            CurrentEdge = Path.Dequeue();
        }

        // N + log(N) + N(N^2) = N + log(N) + N^3 = O(N^3)
        private void GetShortestPathsWithDijkstra(List<Vertex> graphVertexes, Vertex destinationVertex)
        {
            int definitiveDijkstraElements = 0, originVertexIndex = OriginVertex.VertexCircle.ID - 1;

            foreach (Vertex currentVertex in graphVertexes)
            {
                DijkstraElements.Add(new DijkstraElement(currentVertex));
            }

            DijkstraElements[originVertexIndex].AccumulatedDistance = 0;
            DijkstraElements[originVertexIndex].PreviousDijkstraElement = DijkstraElements[originVertexIndex];

            RelocateDijkstraElement(originVertexIndex);

            while (definitiveDijkstraElements != DijkstraElements.Count)
            {
                if (DijkstraElements[definitiveDijkstraElements].AccumulatedDistance == double.PositiveInfinity || DijkstraElements[definitiveDijkstraElements].IDVertex == destinationVertex)
                {
                    break;
                }

                UpdateDijkstraElements(DijkstraElements[definitiveDijkstraElements++]);
            }
        }

        // (N - 1)(N + log(N)) = (N^2 + Nlog(N) - N - log(N)) = O(N^2)
        private void UpdateDijkstraElements(DijkstraElement definitiveDijkstraElement)
        {
            int destinationIndex;

            foreach (Edge currentVertexEdge in definitiveDijkstraElement.IDVertex.EdgeList)
            {
                destinationIndex = DijkstraElements.FindIndex(DijkstraElement => DijkstraElement.IDVertex == currentVertexEdge.Destination);

                if (currentVertexEdge.Weight + definitiveDijkstraElement.AccumulatedDistance < DijkstraElements[destinationIndex].AccumulatedDistance)
                {
                    DijkstraElements[destinationIndex].AccumulatedDistance = currentVertexEdge.Weight + definitiveDijkstraElement.AccumulatedDistance;
                    DijkstraElements[destinationIndex].PreviousDijkstraElement = definitiveDijkstraElement;

                    RelocateDijkstraElement(destinationIndex);
                }
            }
        }

        // log(N)
        private void RelocateDijkstraElement(int index)
        {
            DijkstraElement temporalDijkstraElement = DijkstraElements[index];
            int newIndex;

            DijkstraElements.RemoveAt(index);

            newIndex = DijkstraElements.BinarySearch(temporalDijkstraElement, new CompareDijkstraElementsByAccumulatedDistance());

            if (newIndex < 0)
            {
                DijkstraElements.Insert(~newIndex, temporalDijkstraElement);
            }
            else
            {
                DijkstraElements.Insert(newIndex, temporalDijkstraElement);
            }
        }

        public void UpdateEdgePosition()
        {
            // Check if there's a predator on the current Edge
            if (OnSafeZone)
            {
                if (CurrentEdge.NumberOfPredators != 0)
                {
                    return;
                }
                else
                {
                    if (CurrentEdge.Reverse().NumberOfPredators != 0)
                    {
                        return;
                    }
                }

                OnSafeZone = false;
                CurrentEdge.Preys.Add(this);
            }

            // Check if a Predator appeared, backtrack on the same Edge if it did
            if (CurrentEdge.Reverse().NumberOfPredators != 0)
            {
                SurvivalMode = true;
            }

            if (SurvivalMode)
            {
                EdgePosition -= EdgePositionIncrement;

                if (EdgePosition <= 0)
                {
                    CurrentEdge.Preys.Remove(this);

                    OnSafeZone = true;
                    SurvivalMode = false;
                }
            }
            else
            {
                EdgePosition += EdgePositionIncrement;

                if (EdgePosition >= CurrentEdge.LinePoints.Count)
                {
                    CurrentEdge.Preys.Remove(this);

                    if (Path.Count != 0)
                    {
                        CurrentEdge = Path.Dequeue();

                        OnSafeZone = true;

                        EdgePosition = 0;
                    }
                    else
                    {
                        EdgePosition = CurrentEdge.LinePoints.Count - 1;

                        IsActive = false;
                    }
                }
            }
        }
    }
}
