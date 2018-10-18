using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace MyDrawing
{
    public class Drawer
    {
        public DrawType DrawType { get; set; }
        private readonly PictureBox _field;
        private readonly Bitmap _bmp;
        private readonly Graphics _g;

        public Drawer(PictureBox field, Bitmap b, DrawType drawType)
        {
            DrawType = drawType;
            _field = field;
            _g = Graphics.FromImage(b);
            _bmp = b;
            _g.SmoothingMode = SmoothingMode.AntiAlias;
        }

        public void Draw(UiElement element)
        {
            element.Draw(DrawType, _bmp);
            _field.Image = _bmp;
        }

        public void MoveObject(UiElement l1, UiElement l2)
        {
            if (l1.Points.Count == l2.Points.Count)
            {
                Timer T = new Timer(1);
                var delta = 0.1f;

                T.Elapsed += (sender, args) =>
                {
                    T.Enabled = false;
                    for (int i = 0; i < l1.Points.Count; i++)
                    {
                        var point = l1.Points[i];
                        point.X += (l2.Points[i].X - l1.Points[i].X) * delta;
                        point.Y += (l2.Points[i].Y - l1.Points[i].Y) * delta;

                        if (point.X > delta && point.Y > delta)
                            l1.Points[i] = point;
                    }

                    _g.Clear(Color.White);
                    Draw(l1);
                    T.Enabled = true;

                    if (Math.Abs(l2.Points[0].X - l1.Points[0].X) < delta)
                    {
                        T.Stop();
                    }

                };
                T.Start();
            }
            else
            {
                throw new Exception("Объекты должны содержать одинаковое количество точек");
            }
        }

        public void Dispose()
        {
            _g.Dispose();
        }

        public void Clear()
        {
            _g.Clear(Color.White);
            _field.Image = _bmp;
        }
    }
}
