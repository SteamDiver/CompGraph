using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDrawing.D3
{
    public class Model
    {
        public List<Vertex> Vertices { get; set; } = new List<Vertex>();
        public List<Triangle> Triangles { get; set; } = new List<Triangle>();
        public List<Quad> Quads { get; set; } = new List<Quad>();
        public List<Vertex2D> TextureCoordinates { get; set; } = new List<Vertex2D>();
        public DirectBitmap TextureMap { get; set; }
        public DirectBitmap RenderedColors { get; set; }
        public Vector Translation { get; set; } = new Vector(0, 0, 0);
        public Vector Scale { get; set; } = new Vector(1, 1, 1);
        public Vector Rotation { get; set; } = new Vector(0, 0, 0);
        public float[,] ZBuffer { get; set; } 

        public Model(string objPath, string texturePath = "")
        {
            ReadObjFile(objPath);
            SetTextureImage(texturePath);
            if (Quads.Count != 0) SplitQuads();
        }

        #region Files

        //=============================РАБОТА С ФАЙЛАМИ===================================

        private void SetTextureImage(string pathTextureImage)
        {
            if (pathTextureImage != "")
            {
                var bmp = new Bitmap(Image.FromFile(pathTextureImage));
                TextureMap = new DirectBitmap(bmp);
            }
        }

        private void ReadObjFile(string pathObjFile)
        {
            using (var myStream = new FileStream(pathObjFile, FileMode.Open))
            {
                var myReader = new StreamReader(myStream);
                var coord = new double[3];
                var tri = new int[3];
                var tex = new int[4];
                var quad = new int[4];

                string line;
                while ((line = myReader.ReadLine()) != null)
                    if (line != "")
                    {
                        line = line.Trim(' ');

                        string[] array;
                        switch (line[0])
                        {
                            case 'v':
                            {
                                if (line[1] != 't' && line[1] != 'n')
                                {
                                    line = line.Trim('v', ' ');
                                    array = line.Split(' ');
                                    for (var i = 0; i < 3; i++)
                                        coord[i] = double.Parse(array[i], CultureInfo.InvariantCulture);

                                    var v = new Vertex(coord[0], coord[1], coord[2]);
                                    Vertices.Add(v);
                                }
                                else
                                {
                                    if (line[1] == 't')
                                    {
                                        line = line.Trim('t', 'v', ' ');
                                        array = line.Split(' ');
                                        for (var i = 0; i < 2; i++)
                                            coord[i] = double.Parse(array[i], CultureInfo.InvariantCulture);

                                        var v = new Vertex2D(coord[0], coord[1]);
                                        TextureCoordinates.Add(v);
                                    }
                                }

                                break;
                            }
                            case 'f':
                            {
                                line = line.Trim('f', ' ');
                                array = line.Split(new[] {' ', '/'},
                                    StringSplitOptions.RemoveEmptyEntries);
                                if (array.Length == 9)
                                {
                                    for (int i = 0, j = 0; i < 3 && j < array.Length; i++, j += 3)
                                    {
                                        tri[i] = int.Parse(array[j]);
                                        tex[i] = int.Parse(array[j + 1]);
                                    }

                                    var t = new Triangle(Vertices[tri[0] - 1], Vertices[tri[1] - 1],
                                        Vertices[tri[2] - 1], TextureCoordinates[tex[0] - 1],
                                        TextureCoordinates[tex[1] - 1], TextureCoordinates[tex[2] - 1]);
                                    Triangles.Add(t);
                                }

                                if (array.Length == 12)
                                {
                                    for (int i = 0, j = 0; i < 4 && j < array.Length; i++, j += 3)
                                    {
                                        quad[i] = int.Parse(array[j]);
                                        tex[i] = int.Parse(array[j + 1]);
                                    }

                                    var q = new Quad(Vertices[quad[0] - 1], Vertices[quad[1] - 1],
                                        Vertices[quad[2] - 1],
                                        Vertices[quad[3] - 1], TextureCoordinates[tex[0] - 1],
                                        TextureCoordinates[tex[1] - 1], TextureCoordinates[tex[2] - 1],
                                        TextureCoordinates[tex[3] - 1]);
                                    Quads.Add(q);
                                }
                            }
                                break;
                        }
                    }
            }
        }

        #endregion

        #region Vectors

        //=============================РАБОТА С ВЕКТОРАМИ===================================

        /// <summary>
        ///     Нормализуем векторы(нормали) для каждой вершины модели
        /// </summary>
        private void NormalizeAllVertexNormals()
        {
            foreach (var v in Vertices)
                v.VNormal.Normalize();
        }

        #endregion

        #region ModelBuild

        //=============================ПОСТРОЕНИЕ МОДЕЛИ===================================

        /// <summary>
        ///     Разделение четырехугольного полигона на треугольники
        /// </summary>
        private void SplitQuads()
        {
            foreach (var q in Quads)
            {
                Triangles.Add(new Triangle(q.V1, q.V2, q.V3, q.C1, q.C2, q.C3));
                Triangles.Add(new Triangle(q.V3, q.V4, q.V1, q.C3, q.C4, q.C1));
            }
        }

        #endregion

        #region Triangles

        //=======================РАБОТА С ТРЕУГОЛЬНИКАМИ=============================

        /// <summary>
        ///     Проверка точки на принадлежность треугольнику
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        /// <param name="t">Треугольник</param>
        /// <param name="alpha"></param>
        /// <param name="beta"></param>
        /// <param name="gamma"></param>
        /// <returns></returns>
        private static bool IsPointInsideTriangle(double x, double y, Triangle t, out double alpha, out double beta,
            out double gamma)
        {
            alpha = beta = gamma = 0;
            var denominator = (t.V2.Y - t.V3.Y) * (t.V1.X - t.V3.X) + (t.V3.X - t.V2.X) * (t.V1.Y - t.V3.Y);
            alpha = ((t.V2.Y - t.V3.Y) * (x - t.V3.X) + (t.V3.X - t.V2.X) * (y - t.V3.Y)) / denominator;
            beta = ((t.V3.Y - t.V1.Y) * (x - t.V3.X) + (t.V1.X - t.V3.X) * (y - t.V3.Y)) / denominator;
            gamma = 1 - alpha - beta;
            return alpha >= 0 && alpha <= 1 && beta >= 0 && beta <= 1 && gamma >= 0 && gamma <= 1;
        }

        #endregion

        /// <summary>
        ///     Нахождение соответствующего пикселя на текстуре
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <param name="c3"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="g"></param>
        /// <returns></returns>
        private Color FindTexel(Vertex2D c1, Vertex2D c2, Vertex2D c3, double a, double b, double g)
        {
            var w = TextureMap.Width;
            var h = TextureMap.Height;
            var u = a * c1.U + b * c2.U + g * c3.U;
            var v = a * (1 - c1.V) + b * (1 - c2.V) + g * (1 - c3.V);
            var texel = TextureMap.GetPixel((int) (u * w), (int) (v * h));
            return texel;
        }

        #region TriangleDraw

        private void CompleteTriangleDraw(Triangle t, List<Light> lights)
        {
            Vector v = t.Norm;
            double A = v.X, B = v.Y, C = v.Z;
            var D = -(A * t.V1.X + B * t.V1.Y + C * t.V1.Z);
            int maxX = (int)Math.Max(t.V1.X, Math.Max(t.V2.X, t.V3.X)); //
            int minX = (int)Math.Min(t.V1.X, Math.Min(t.V2.X, t.V3.X)); //прямоугольник, который ограничивает треугольник
            var maxY = (int)Math.Max(t.V1.Y, Math.Max(t.V2.Y, t.V3.Y)); //
            var minY = (int)Math.Min(t.V1.Y, Math.Min(t.V2.Y, t.V3.Y)); //

            //движемся по пикселям внутри треугольника и проверяем, принадлежит ли конкретный пиксель треугольнику
            for (var x = minX; x <= maxX; x++)
            {
                for (var y = minY; y <= maxY; y++)
                {
                    var z = -(A * x + B * y + D) / C;
                    var xResult = x;
                    var yResult = -y;
                    if (IsPointInsideTriangle(x, y, t, out var a,
                            out var b, out var g) && yResult > 0 && xResult > 0)
                        if (xResult <= ZBuffer.GetUpperBound(0) && yResult <= ZBuffer.GetUpperBound(1) && z > ZBuffer[xResult, yResult])
                        {
                            var texel = TextureMap!= null? FindTexel(t.C1, t.C2, t.C3, a, b, g) : Color.CornflowerBlue ;

                            List<Color> texels = new List<Color>();
                            foreach (var light in lights)
                                texels.Add(light.GetPixelColor(t.V1.VNormal, t.V2.VNormal, t.V3.VNormal, texel,
                                    a, b, g));
                            texel = Light.GetItogTexel(texels);

                            if (RenderedColors.Bits.Length > xResult * yResult)
                            {
                                RenderedColors.SetPixel(xResult, yResult, texel);
                                ZBuffer[xResult, yResult] = (float)z;
                            }
                        }
                        else
                        {

                        }
                }
            }
        }

        private void InitializeZBuffer(int width, int height)
        {
            ZBuffer = new float[width, height];
            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < height; j++)
                    ZBuffer[i, j] = float.MinValue;
            }
            Debug.WriteLine(ZBuffer.Length);
        }

        #endregion

        #region ModelDraw

        //========================ОТРИСОВКА МОДЕЛИ======================================

        private void CompleteModelDraw(List<Light> lights)
        {
            NormalizeAllVertexNormals();
            FindAreaSize(out var width, out var height);
            InitializeZBuffer(width, height);
            RenderedColors = new DirectBitmap(width,height);

            Parallel.ForEach(Triangles, (t) =>
                CompleteTriangleDraw(t, lights)
            );
        }

        #endregion

        #region ModelTransform

        //========================ТРАНСФОРМАЦИЯ МОДЕЛИ===================================

        /// <summary>
        /// Находим координаты для вершины после трансформации
        /// </summary>
        /// <param name="vertexCoord"></param>
        /// <param name="translate"></param>
        /// <param name="scale"></param>
        /// <param name="rotation"></param>
        /// <param name="projectionValue"></param>
        /// <returns></returns>
        private MatrixVector TransformCoordinates(MatrixVector vertexCoord, Vector translate, Vector scale,
            Vector rotation, double projectionValue)
        {
            return ModelTransform.TransformModel(vertexCoord, ModelTransform.GetScaleMatrix(scale),
                ModelTransform.GetTranslateMatrix(translate), ModelTransform.GetRotationMatrix(rotation), ModelTransform.GetProjectionMatrix(projectionValue));
        }

        private void TransformModel(Vector translation, Vector scale, Vector rotation, double prijectionValue)
        {
            foreach (var v in Vertices)
            {
                var coordVector = TransformCoordinates(v.CoordVector, translation, scale, rotation, prijectionValue);
                v.X = coordVector.X;
                v.Y = coordVector.Y;
                v.Z = coordVector.Z;
            }
        }

        internal Bitmap Draw(Bitmap bmp, List<Light> lights, Point worldCenter, Camera camera)
        {
            TransformModel(Translation + new Vector(worldCenter.X, worldCenter.Y, 0), Scale, Rotation, camera.ProjectionValue);
            CompleteModelDraw(lights);
            var ret = new Bitmap(RenderedColors.Bitmap);
            RenderedColors.Dispose();
            return ret;
        }

        private void FindAreaSize(out int width, out int height)
        {
            var maxX = Vertices.Max(x => x.X);
            var minX = Vertices.Min(x => x.X);
            var maxY = Vertices.Max(x => x.Y);
            var minY = Vertices.Min(x => x.Y);

            int ampX = (int)(Math.Abs(maxX) + Math.Abs(minX)), ampY = (int) (Math.Abs(maxY) + Math.Abs(minY));
            width = ampX;
            height = ampY;
        }

        #endregion
    }
}