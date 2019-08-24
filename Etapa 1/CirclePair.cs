using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Final_Project
{
    class CirclePair
    {
        private Circle originCirle;
        private Circle destinationCircle;
        private List<Point> linePoints;

        public CirclePair()
        {
            originCirle = new Circle();
            destinationCircle = new Circle();
            linePoints = new List<Point>();
        }

        public CirclePair(Circle newOriginCircle, Circle newDestinationCircle, List<Point> newLinePoints)
        {
            originCirle = newOriginCircle;
            destinationCircle = newDestinationCircle;
            linePoints = newLinePoints;
        }

        public Circle OriginCircle
        {
            get { return originCirle; }
            set { originCirle = value; }
        }

        public Circle DestinationCircle
        {
            get { return destinationCircle; }
            set { destinationCircle = value; }
        }

        public List<Point> LinePoints
        {
            get { return linePoints; }
            set { linePoints = value; }
        }
    }
}
