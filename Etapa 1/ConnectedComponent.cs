using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    class ConnectedComponent
    {
        // ATTRIBUTES
        public List<Vertex> VertexList { get; set; }

        // METHODS
        public ConnectedComponent(Vertex firstVertex)
        {
            VertexList = new List<Vertex>
            {
                firstVertex
            };
        }
    }
}
