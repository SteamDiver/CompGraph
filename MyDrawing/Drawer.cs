using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing
{
    public class Drawer
    {
        public Graphics G;

        public Drawer(Bitmap bitmap)
        {
            G = Graphics.FromImage(bitmap);
        }

        public void DrawLine(List<PointF> points, int width, Brush color)
        {
            G.DrawCurve(new Pen(color), points.ToArray(), 2 );
        }

        public void DrawPoint(PointF position, Brush color)
        {
            G.DrawRectangle(new Pen(color), position.X, position.Y, 1, 1 );
        }
    }
}
