using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using MyDrawing.VisualObjects;

namespace MyDrawing.D3
{
    public class Model
    {
        public List<Vertex> Vertices { get; set; } = new List<Vertex>();
        public List<Triangle> Triangles { get; set; } = new List<Triangle>();
        public List<Quad> Quads { get; set; } = new List<Quad>();
        public List<Vector> Vectors { get; set; } = new List<Vector>();
        public List<Vertex2D> TextureCoordinates { get; set; } = new List<Vertex2D>();
        public Bitmap ModelBitmap { get; set; }
        public Bitmap TextureMap { get; set; }

        public Vector Translation { get; set; } = new Vector(0, 0, 0);
        public Vector Scale { get; set; } = new Vector(1, 1, 1);
        public Vector Rotation { get; set; } = new Vector(0, 0, 0);



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
                TextureMap = (Bitmap)Image.FromFile(pathTextureImage);
            else
            {
                var bmp = new Bitmap(1, 1);
                var g = Graphics.FromImage(bmp);
                g.Clear(Color.DarkGray);
                TextureMap = bmp;
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
                {
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
                                        for (int i = 0; i < 3; i++)
                                        {
                                            coord[i] = double.Parse(array[i], CultureInfo.InvariantCulture);
                                        }

                                        Vertex v = new Vertex(coord[0], coord[1], coord[2]);
                                        Vertices.Add(v);
                                    }
                                    else
                                    {
                                        if (line[1] == 't')
                                        {
                                            line = line.Trim('t', 'v', ' ');
                                            array = line.Split(' ');
                                            for (int i = 0; i < 2; i++)
                                            {
                                                coord[i] = double.Parse(array[i], CultureInfo.InvariantCulture);
                                            }

                                            Vertex2D v = new Vertex2D(coord[0], coord[1]);
                                            TextureCoordinates.Add(v);
                                        }
                                    }

                                    break;
                                }
                            case 'f':
                                {
                                    line = line.Trim('f', ' ');
                                    array = line.Split(new[] { ' ', '/' },
                                        StringSplitOptions.RemoveEmptyEntries);
                                    if (array.Length == 9)
                                    {
                                        for (int i = 0, j = 0; i < 3 && j < array.Length; i++, j += 3)
                                        {
                                            tri[i] = int.Parse(array[j]);
                                            tex[i] = int.Parse(array[j + 1]);
                                        }

                                        Triangle t = new Triangle(Vertices[tri[0] - 1], Vertices[tri[1] - 1],
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

                                        Quad q = new Quad(Vertices[quad[0] - 1], Vertices[quad[1] - 1], Vertices[quad[2] - 1],
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
        }

        #endregion

        #region Vectors

        //=============================РАБОТА С ВЕКТОРАМИ===================================

        /// <summary>
        /// Построение вектора по двум вершинам
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        private Vector GetVector(Vertex v1, Vertex v2)
        {
            var tempVector = new Vector
            {
                X = v1.X - v2.X,
                Y = v1.Y - v2.Y,
                Z = v1.Z - v2.Z
            };
            return tempVector;
        }

        /// <summary>
        /// Построение нормализованной нормали треугольника по двум векторам
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        private Vector GetNormal(Vector v1, Vector v2)
        {
            var normal = new Vector
            {
                X = v1.Y * v2.Z - v1.Z * v2.Y,
                Y = v1.Z * v2.X - v1.X * v2.Z,
                Z = v1.X * v2.Y - v1.Y * v2.X
            };
            normal.Normalize();
            return normal;
        }

        /// <summary>
        /// Нахождение нормалей для всех треугольников модели
        /// </summary>
        private void FindNormals()
        {
            var vectorsTemp = new List<Vector>();
            foreach (var t in Triangles)
            {
                var vector1 = GetVector(t.V1, t.V2);
                var vector2 = GetVector(t.V2, t.V3);
                var normal = GetNormal(vector1, vector2);
                GiveNormalToEachVertex(t.V1, t.V2, t.V3, normal);
                vectorsTemp.Add(normal);
            }
            Vectors = vectorsTemp;
        }

        private void GiveNormalToEachVertex(Vertex v1, Vertex v2, Vertex v3, Vector normal)
        {
            v1.VNormal += normal;
            v2.VNormal += normal;
            v3.VNormal += normal;
        } //Снабжаем каждую вершину информацией о нормали треугольника

        private void NormalizeAllVertexNormals()
        {
            foreach (var v in Vertices)
                v.VNormal.Normalize();
        } //Нормализуем векторы(нормали) для каждой вершины модели

        #endregion

        #region ModelBuild

        //=============================ПОСТРОЕНИЕ МОДЕЛИ===================================

        private void SplitQuads() //Разделение четырехугольного полигона на треугольники
        {
            var t = new Triangle();
            foreach (var q in Quads)
            {
                t.V1 = q.V1;
                t.C1 = q.C1;
                t.V2 = q.V2;
                t.C2 = q.C2;
                t.V3 = q.V3;
                t.C3 = q.C3;
                Triangles.Add(t);
                t.V1 = q.V3;
                t.C1 = q.C3;
                t.V2 = q.V4;
                t.C2 = q.C4;
                t.V3 = q.V1;
                t.C3 = q.C1;
                Triangles.Add(t);
            }
        } //Разобьем квадраты на треугольники



        #endregion

        #region Triangles

        //=======================РАБОТА С ТРЕУГОЛЬНИКАМИ=============================

        private static bool IsPointInsideTriangle(double x, double y, Triangle t, out double alpha , out double beta, out double gamma) //Проверка точки на принадлежность треугольнику
        {
            var denominator = (t.V2.Y - t.V3.Y) * (t.V1.X - t.V3.X) + (t.V3.X - t.V2.X) * (t.V1.Y - t.V3.Y);
            alpha = ((t.V2.Y - t.V3.Y) * (x - t.V3.X) + (t.V3.X - t.V2.X) * (y - t.V3.Y)) / denominator;
            beta = ((t.V3.Y - t.V1.Y) * (x - t.V3.X) + (t.V1.X - t.V3.X) * (y - t.V3.Y)) / denominator;
            gamma = 1 - alpha - beta;
            return alpha >= 0 && alpha <= 1 && beta >= 0 && beta <= 1 && gamma >= 0 && gamma <= 1;
        }

        #endregion

        /// <summary>
        /// Нахождение соответствующего пикселя на текстуре
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
            var texel = TextureMap.GetPixel((int)(u * w), (int)(v * h));
            return texel;
        }

        #region TriangleDraw

        private void CompleteTriangleDraw(Triangle t,
            Vector v, int modelWidth, int modelHeight, List<Light> lights,
            ref double[,] zBuffer)
        {
            double A = v.X, B = v.Y, C = v.Z;
            var D = -(A * t.V1.X + B * t.V1.Y + C * t.V1.Z);
            var maxX = Math.Max((int)t.V1.X,
                (int)Math.Max(t.V2.X, t.V3.X)); //
            var minX = Math.Min((int)t.V1.X,
                (int)Math.Min(t.V2.X,
                    t.V3.X)); //прямоугольник, который ограничивает треугольник
            var maxY = Math.Max((int)t.V1.Y,
                (int)Math.Max(t.V2.Y, t.V3.Y)); //
            var minY = Math.Min((int)t.V1.Y,
                (int)Math.Min(t.V2.Y, t.V3.Y)); //
            int horizontalShift = modelWidth / 2, verticalShift = modelHeight / 2;
            //движемся по пикселям внутри треугольника и проверяем, принадлежит ли конкретный пиксель треугольнику
            for (var x = minX; x <= maxX; x++)
                for (var y = minY; y <= maxY; y++)
                {
                    var z = -(A * x + B * y + D) / C;
                    var xResult = x + horizontalShift;
                    var yResult = -y + verticalShift;
                    if (IsPointInsideTriangle(x, y, t, out double a,
                            out double b, out double g) && yResult > 0 && xResult > 0)
                        if (z > zBuffer[xResult, yResult])
                        {
                            if (TextureCoordinates.Count > 0)
                            {
                                var texel = FindTexel(t.C1, t.C2, t.C3, a, b, g);
                                foreach (var light in lights)
                                {
                                    texel = light.GetPixelColor(t.V1.VNormal, t.V2.VNormal, t.V3.VNormal, texel, a, b, g);
                                }

                                if (ModelBitmap.Width > xResult && yResult < ModelBitmap.Height)
                                {
                                    ModelBitmap.SetPixel(xResult, yResult, texel);
                                    zBuffer[xResult, yResult] = z;
                                }
                            }
                        }
                }
        }

        private double[,] InitializeZBuffer(int width, int height)
        {
            var zBuffer = new double[2 * width, 2 * height];
            for (var i = 0; i < zBuffer.GetLength(0); i++)
                for (var j = 0; j < zBuffer.GetLength(1); j++)
                    zBuffer[i, j] = float.MinValue;
            return zBuffer;
        }

        #endregion

        #region ModelDraw

        //========================ОТРИСОВКА МОДЕЛИ======================================

        private void CompleteModelDraw(List<Light> lights)
        {
            FindAreaSize(out int width, out int height);
            var myMap = new Bitmap(width, height);
            ModelBitmap = myMap;
            Graphics.FromImage(ModelBitmap).SmoothingMode = SmoothingMode.AntiAlias;
            var zBuffer = InitializeZBuffer(width, height);
            FindNormals();
            NormalizeAllVertexNormals();
            var i = 0;
            foreach (var t in Triangles)
                CompleteTriangleDraw(t, Vectors[i++], width, height, lights, ref zBuffer);
        }

        #endregion

        #region ModelTransform

        //========================ТРАНСФОРМАЦИЯ МОДЕЛИ===================================

        /// <summary>
        ///         Находим координаты для вершины после трансформации
        /// </summary>
        /// <param name="vertexCoord"></param>
        /// <param name="translate"></param>
        /// <param name="scale"></param>
        /// <param name="rotation"></param>
        /// <param name="projectValues"></param>
        /// <returns></returns>
        private MatrixVector TransformCoordinates(MatrixVector vertexCoord, Vector translate, Vector scale,
                Vector rotation, double projectValues)
        {
            return ModelTransform.CoordAfterTransformation(vertexCoord, ModelTransform.GetScaleMatrix(scale),
                ModelTransform.GetTranslateMatrix(translate), ModelTransform.GetRotationMatrix(rotation),
                ModelTransform.GetProjectionMatrix(projectValues));
        }

        private void TransformModel(Vector translation,Vector scale, Vector rotation)
        {
            double pv = 1000;
            foreach (var v in Vertices)
            {
                var coordVector = TransformCoordinates(v.CoordVector, translation, scale, rotation, pv);
                v.X = coordVector.Vector[0];
                v.Y = coordVector.Vector[1];
                v.Z = coordVector.Vector[2];
            }
        } //Обращаем все координаты

        internal Bitmap Draw(List<Light> lights)
        {
            TransformModel(Translation, Scale, Rotation);
            CompleteModelDraw(lights);
            return ModelBitmap;
        }

        private void FindAreaSize(out int width, out int height)
        {
            var maxX = Vertices.Max(x => x.X);
            var minX = Vertices.Min(x => x.X);
            var maxY = Vertices.Max(x => x.Y);
            var minY = Vertices.Min(x => x.Y);
            
            int ampX = (int)Math.Ceiling(maxX - minX), ampY = (int)Math.Ceiling(maxY - minY);
            width = ampX;
            height = ampY;
        }

        #endregion
    }
}