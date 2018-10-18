using System;
using System.Collections.Generic;
using System.Drawing;

namespace MyDrawing.VisualObjects
{
    public class Line : UiElement
    {
        /// <summary>
        /// Line width
        /// </summary>
        public float Width { get; set; }

        public Line(List<PointF> points, Color color, float width)
        {
            Points = points;
            Color = color;
            Width = width;
        }

        public Line(PointF p1, PointF p2, Color color, float width)
        {
            Points = new List<PointF>()
            {
                p1, p2
            };

            Color = color;
            Width = width;
        }

        /// <summary>
        /// Draw line with spec algorythm
        /// </summary>
        /// <param name="type">DrawType</param>
        /// <param name="g"></param>
        internal override void Draw(DrawType type, Bitmap b)
        {
            switch (type)
            {
                case DrawType.Standart:
                    var g = Graphics.FromImage(b);
                    g.DrawLines(new Pen(Color, Width), Points.ToArray());
                    break;
                case DrawType.Custom:
                    DrawCustomLine(Points, b);
                    break;
            }
        }

        /// <summary>
        /// Normalize number of points. Needed for transfrom to new line
        /// </summary>
        /// <param name="line">new line</param>
        public void NormalizeWithNewLine(Line line)
        {
            while (Points.Count != line.Points.Count)
            {
                var diff = Math.Abs(Points.Count - line.Points.Count);
                var k = Points.Count / diff == 0 ? diff / Points.Count : Points.Count / diff;

                for (int i = 0; i < Points.Count - 1; i++)
                {
                    if (Points.Count > line.Points.Count)
                    {
                        if (i % k == 0)
                            Points.RemoveAt(i);
                    }
                    else
                    {
                        if (i % k == 0)
                        {
                            var p = Points[i];
                            var np = Points[i + 1];
                            Points.Insert(i++, new PointF((np.X + p.X) / 2, (np.Y + p.Y) / 2));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Custom draw algorythm
        /// </summary>
        /// <param name="points"></param>
        /// <param name="g"></param>
        private void DrawCustomLine(List<PointF> points, Bitmap b)
        {
            if (points.Count > 1)
            {
                for (int i = 1; i < points.Count; i++)
                {
                    DrawBresenhamLine(points[i-1], points[i], b);
                }
            }
        }

        private void DrawBresenhamLine(PointF start, PointF stop, Bitmap bmp)
        {
            int dx, dy, incx, incy, pdx, pdy, es, el, err;
            float x, y;

            dx = (int)(stop.X - start.X);//проекция на ось икс
            dy = (int)(stop.Y - start.Y);//проекция на ось игрек

            incx = Math.Sign(dx);
            /*
             * Определяем, в какую сторону нужно будет сдвигаться. Если dx < 0, т.е. отрезок идёт
             * справа налево по иксу, то incx будет равен -1.
             * Это будет использоваться в цикле постороения.
             */
            incy = Math.Sign(dy);
            /*
             * Аналогично. Если рисуем отрезок снизу вверх -
             * это будет отрицательный сдвиг для y (иначе - положительный).
             */

            if (dx < 0) dx = -dx;//далее мы будем сравнивать: "if (dx < dy)"
            if (dy < 0) dy = -dy;//поэтому необходимо сделать dx = |dx|; dy = |dy|
                                 //эти две строчки можно записать и так: dx = Math.abs(dx); dy = Math.abs(dy);

            if (dx > dy)
            //определяем наклон отрезка:
            {
                /*
                 * Если dx > dy, то значит отрезок "вытянут" вдоль оси икс, т.е. он скорее длинный, чем высокий.
                 * Значит в цикле нужно будет идти по икс (строчка el = dx;), значит "протягивать" прямую по иксу
                 * надо в соответствии с тем, слева направо и справа налево она идёт (pdx = incx;), при этом
                 * по y сдвиг такой отсутствует.
                 */
                pdx = incx; pdy = 0;
                es = dy; el = dx;
            }
            else//случай, когда прямая скорее "высокая", чем длинная, т.е. вытянута по оси y
            {
                pdx = 0; pdy = incy;
                es = dx; el = dy;//тогда в цикле будем двигаться по y
            }

            x = start.X;
            y = start.Y;
            err = el / 2;
            bmp.SetPixel((int)x, (int)y, Color);//ставим первую точку
                                   //все последующие точки возможно надо сдвигать, поэтому первую ставим вне цикла

            for (int t = 0; t < el; t++)//идём по всем точкам, начиная со второй и до последней
            {
                err -= es;
                if (err < 0)
                {
                    err += el;
                    x += incx;//сдвинуть прямую (сместить вверх или вниз, если цикл проходит по иксам)
                    y += incy;//или сместить влево-вправо, если цикл проходит по y
                }
                else
                {
                    x += pdx;//продолжить тянуть прямую дальше, т.е. сдвинуть влево или вправо, если
                    y += pdy;//цикл идёт по иксу; сдвинуть вверх или вниз, если по y
                }

                bmp.SetPixel((int) x, (int) y, Color);
            }
        }
    }
}
