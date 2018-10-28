using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyDrawing.D3;

namespace MyDrawing.VisualObjects
{
    public class DirectionalLight : Light
    {
        public LightType LightT { get; set; }
        public DirectionalLight(LightType type, Vector lightVector) : base(lightVector)
        {
            LightT = type;
        }

        public override Color GetPixelColor(Vector norm1, Vector norm2, Vector norm3, Color texel, double a, double b, double g)
        {
            switch (LightT)
            {
                case LightType.Diffuse:
                    return GetDiffuseColor(norm1, norm2, norm3, texel, a, b, g);
                default:
                    return texel;
            }
        }

        private Color GetDiffuseColor(Vector norm1, Vector norm2, Vector norm3, Color texel, double a, double b, double g)
        {
            Vector pNorm; //нормаль для данного пикселя
            pNorm.X = norm1.X * a + norm2.X * b + norm3.X * g;
            pNorm.Y = norm1.Y * a + norm2.Y * b + norm3.Y * g;
            pNorm.Z = norm1.Z * a + norm2.Z * b + norm3.Z * g;
            var cosVal = Vector.CosCalc(pNorm, LightVector);
            if (cosVal <= 0)
            {
                return Color.FromArgb(0, 0, 0);
            }
            var newColor = Color.FromArgb((int)(texel.R * cosVal), (int)(texel.G * cosVal),
                (int)(texel.B * cosVal));
            return newColor;
        }
    }
}
