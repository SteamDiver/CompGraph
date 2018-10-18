using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing
{
    public abstract class UiElement
    {
        public Color Color { get; set; }
        public List<PointF> Points { get; set; }
        internal abstract void Draw(DrawType drawType, Bitmap b);
    }
}
