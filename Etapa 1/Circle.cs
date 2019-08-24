using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Final_Project
{
    class Circle
    {
        // Attributes
        private int id;
        private Point centre;
        private int radius;

        //Methods
        public Circle()
        {
            id = -1;
            centre.X = -1;
            centre.Y = -1;
            radius = -1;
        }

        public Circle(int newId, Point newCentre, int newRadius)
        {
            id = newId;
            centre.X = newCentre.X;
            centre.Y = newCentre.Y;
            radius = newRadius;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public Point Centre
        {
            get { return centre; }
            set { centre = value; }
        }

        public int Radius
        {
            get { return radius; }
            set { radius = value; }
        }
    }
}
