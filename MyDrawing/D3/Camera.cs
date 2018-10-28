using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing.D3
{
    public class Camera
    {
        public Vector ViewVector { get; set; }
        public double ProjectionValue { get; set; } = 4000;
        public Camera(Vector viewVector)
        {
            ViewVector = viewVector;
        }
    }
}
