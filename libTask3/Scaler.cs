using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libTask3
{
    public class Scaler
    {
        public static void ScaleLine(ref List<PointF> points, float oldWidth, float oldHeight, float newWidth, float newHeight)
        {
            for (int i = 0; i<points.Count; i++)
            {
                var point = points[i];

                var scaleX = point.X / oldWidth;
                var scaleY = point.Y / oldHeight;

                point.X = scaleX * newWidth;
                point.Y = scaleY * newHeight;
            }
        } 
    }
}
