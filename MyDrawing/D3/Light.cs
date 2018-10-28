using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyDrawing.VisualObjects;

namespace MyDrawing.D3
{
    public abstract class Light
    {
        private Vector _lightVector;
        public Vector LightVector
        {
            get => _lightVector;
            set
            {
                _lightVector = value; 
                _lightVector.Normalize();
            }
        }

        public Light(Vector lihgtVector)
        {
            LightVector = lihgtVector;
        }

        public abstract Color GetPixelColor(Vector norm1, Vector norm2, Vector norm3, Color texel, double a, double b, double g);

        public static Color GetItogTexel(List<Color> texels)
        {
            return Color.FromArgb(texels.Sum(t => t.R) / texels.Count, texels.Sum(t => t.G) / texels.Count,
                texels.Sum(t => t.B) / texels.Count);
        }

        
    }
}
