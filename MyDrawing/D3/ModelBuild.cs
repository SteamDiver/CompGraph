using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;

//using ImageMagick;

namespace MyDrawing.D3
{
    public class Model
    {
        public List<Vertex> Vertices = new List<Vertex>(); //Точки модели
        public List<Triangle> Triangles = new List<Triangle>(); //Треугольники модели.
        public List<Quad> Quads = new List<Quad>();
        public List<Vector> Vectors = new List<Vector>(); //Векторы треугольников(нормализованные).
        public List<Vertex2D> TextureCoordinates = new List<Vertex2D>();
        public Bitmap ModelBitmap;
        public Bitmap TextureMap;

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
                g.Clear(Color.Gray);
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

        private void TriangleRasterization(int v1, int v2, int v3, Color setColor)
        {
            var horizontalShift = ModelBitmap.Width / 2;
            var verticalShift = (int)(ModelBitmap.Height * 0.6);
            var maxX = Math.Max((int)Vertices[v1 - 1].X,
                (int)Math.Max(Vertices[v2 - 1].X, Vertices[v3 - 1].X)); //
            var minX = Math.Min((int)Vertices[v1 - 1].X,
                (int)Math.Min(Vertices[v2 - 1].X,
                    Vertices[v3 - 1].X)); //прямоугольник, который ограничивает треугольник
            var maxY = Math.Max((int)Vertices[v1 - 1].Y,
                (int)Math.Max(Vertices[v2 - 1].Y, Vertices[v3 - 1].Y)); //
            var minY = Math.Min((int)Vertices[v1 - 1].Y,
                (int)Math.Min(Vertices[v2 - 1].Y, Vertices[v3 - 1].Y)); //

            //движемся по пикселям внутри треугольника и проверяем, принадлежит ли конкретный пиксель треугольнику
            for (var x = minX; x <= maxX; x++)
                for (var y = minY; y <= maxY; y++)
                {
                    var Xresult = x + horizontalShift;
                    var Yresult = -y + verticalShift;
                    if (IsPointInsideTriangle(x, y, Vertices[v1 - 1], Vertices[v2 - 1], Vertices[v3 - 1]) &&
                        Yresult > 0)
                        ModelBitmap.SetPixel(Xresult, Yresult, setColor);
                }
        } //Растеризация треугольника

        private static bool IsPointInsideTriangle(double x, double y, Vertex a, Vertex b,
            Vertex c) //Проверка точки на принадлежность треугольнику
        {
            var denominator = (b.Y - c.Y) * (a.X - c.X) + (c.X - b.X) * (a.Y - c.Y);
            var alpha = ((b.Y - c.Y) * (x - c.X) + (c.X - b.X) * (y - c.Y)) / denominator;
            var beta = ((c.Y - a.Y) * (x - c.X) + (a.X - c.X) * (y - c.Y)) / denominator;
            var gamma = 1 - alpha - beta;
            return alpha >= 0 && alpha <= 1 && beta >= 0 && beta <= 1 && gamma >= 0 && gamma <= 1;
        }

        private static bool IsPointInsideTriangle(double x, double y, Vertex v1, Vertex v2, Vertex v3,
            ref double alpha, ref double beta, ref double gamma) //Проверка точки на принадлежность треугольнику
        {
            var denominator = (v2.Y - v3.Y) * (v1.X - v3.X) + (v3.X - v2.X) * (v1.Y - v3.Y);
            alpha = ((v2.Y - v3.Y) * (x - v3.X) + (v3.X - v2.X) * (y - v3.Y)) / denominator;
            beta = ((v3.Y - v1.Y) * (x - v3.X) + (v1.X - v3.X) * (y - v3.Y)) / denominator;
            gamma = 1 - alpha - beta;
            return alpha >= 0 && alpha <= 1 && beta >= 0 && beta <= 1 && gamma >= 0 && gamma <= 1;
        }

        #endregion

        #region Lightning

        //=======================РАБОТА С ПИКСЕЛЯМИ===================================
        private Color DiffuseLight(Vector v1, Vector v2, Vector v3, Color modelColor, double a, double b, double g)
        {
            var newColor = Color.Empty;
            var lightVector = new Vector(0, 0, 1);
            lightVector.Normalize();
            Vector pNorm; //нормаль для данного пикселя
            pNorm.X = v1.X * a + v2.X * b + v3.X * g;
            pNorm.Y = v1.Y * a + v2.Y * b + v3.Y * g;
            pNorm.Z = v1.Z * a + v2.Z * b + v3.Z * g;
            var cosVal = Vector.CosCalc(pNorm, lightVector);
            cosVal = Math.Abs(cosVal);
            newColor = Color.FromArgb((int)(modelColor.R * cosVal), (int)(modelColor.G * cosVal),
                (int)(modelColor.B * cosVal));
            return newColor;
        } //Нахождение цвета пискеля(или текселя)

        private Color SpecularLight(Vector v1, Vector v2, Vector v3, Color modelColor, double a, double b, double g,
            Vector pixelPosWorld)
        {
            var lightVector = new Vector(0, 1, 1); //Vector.NormalizeVector(ref lightVector);
            var eyeVector = new Vector(0, 0, 1);
            Vector pNorm; //нормаль для данного пикселя
            pNorm.X = v1.X * a + v2.X * b + v3.X * g;
            pNorm.Y = v1.Y * a + v2.Y * b + v3.Y * g;
            pNorm.Z = v1.Z * a + v2.Z * b + v3.Z * g;
            var cosVal = Vector.CosCalc(pNorm, lightVector);
            cosVal = Math.Abs(cosVal);
            var viewVector = eyeVector - pixelPosWorld;
            viewVector.Normalize();
            var reflectVector = 2 * lightVector * (-pNorm) * pNorm + lightVector;
            reflectVector.Normalize();
            var specLight = reflectVector * viewVector;
            specLight = Math.Abs(specLight);
            var materialCoef = 0.1;
            var finalIntensity = cosVal + materialCoef * specLight;
            finalIntensity = finalIntensity > 1 ? 1 : finalIntensity;
            var newColor = Color.FromArgb((int)(modelColor.R * finalIntensity), (int)(modelColor.G * finalIntensity),
                (int)(modelColor.B * finalIntensity));
            return newColor;
        }

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

        #endregion

        #region TriangleDraw

        //========================РАЗЛИЧНЫЕ ТИПЫ ОТРИСОВКИ ТРЕУГОЛЬНИКА=====================================

        private void CompleteTriangleDraw(Vertex v1, Vertex v2, Vertex v3, Vertex2D c1, Vertex2D c2, Vertex2D c3,
            Vector v, int modelWidth, int modelHeight,
            ref float[,] zBuffer)
        {
            double a = 0, b = 0, g = 0, A = v.X, B = v.Y, C = v.Z;
            var D = -(A * v1.X + B * v1.Y + C * v1.Z);
            var maxX = Math.Max((int)v1.X,
                (int)Math.Max(v2.X, v3.X)); //
            var minX = Math.Min((int)v1.X,
                (int)Math.Min(v2.X,
                    v3.X)); //прямоугольник, который ограничивает треугольник
            var maxY = Math.Max((int)v1.Y,
                (int)Math.Max(v2.Y, v3.Y)); //
            var minY = Math.Min((int)v1.Y,
                (int)Math.Min(v2.Y, v3.Y)); //
            int horizontalShift = modelWidth / 2, verticalShift = modelHeight / 2;
            //движемся по пикселям внутри треугольника и проверяем, принадлежит ли конкретный пиксель треугольнику
            for (var x = minX; x <= maxX; x++)
                for (var y = minY; y <= maxY; y++)
                {
                    var z = (float)(-(A * x + B * y + D) / C);
                    var xResult = x + horizontalShift;
                    var yResult = -y + verticalShift;
                    if (IsPointInsideTriangle(x, y, v1, v2, v3, ref a,
                            ref b, ref g) && yResult > 0 && xResult > 0)
                        if (z > zBuffer[xResult, yResult])
                        {
                            if (TextureCoordinates.Count > 0)
                            {
                                var texel = FindTexel(c1, c2, c3, a, b, g);
                                texel = DiffuseLight(v1.VNormal, v2.VNormal, v3.VNormal, texel, a, b, g);
                                //texel = SpecularLight(Vertices[v1 - 1 > 0 ? v1 - 1 : v1].VNormal,
                                //    Vertices[v2 - 1 > 0 ? v2 - 1 : v2].VNormal,
                                //    Vertices[v3 - 1 > 0 ? v3 - 1 : v3].VNormal, texel, a, b, g, x, y, z);
                                if (ModelBitmap.Width > xResult && yResult < ModelBitmap.Height)
                                {
                                    ModelBitmap.SetPixel(xResult, yResult, texel);
                                    zBuffer[xResult, yResult] = z;
                                }
                            }
                        }
                }
        }

        private float[,] InitializeZBuffer()
        {
            var zBuffer = new float[3000, 3000];
            var l = zBuffer.GetLength(0) - 1;
            for (var i = 0; i < l; i++)
                for (var j = 0; j < l; j++)
                    zBuffer[i, j] = -10000;
            return zBuffer;
        }

        #endregion

        #region ModelDraw

        //========================ОТРИСОВКА МОДЕЛИ======================================

        private void CompleteModelDraw()
        {
            FindAreaSize(out int width, out int height);
            var myMap = new Bitmap(width, height);
            ModelBitmap = myMap;
            Graphics.FromImage(ModelBitmap).SmoothingMode = SmoothingMode.AntiAlias;
            var zBuffer = InitializeZBuffer();
            FindNormals();
            NormalizeAllVertexNormals();
            var i = 0;
            foreach (var t in Triangles)
                CompleteTriangleDraw(t.V1, t.V2, t.V3, t.C1, t.C2, t.C3, Vectors[i++], width, height, ref zBuffer);
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
            double pv = 4000;
            foreach (var v in Vertices)
            {
                var coordVector = TransformCoordinates(v.CoordVector, translation, scale, rotation, pv);
                v.X = coordVector.Vector[0];
                v.Y = coordVector.Vector[1];
                v.Z = coordVector.Vector[2];
            }
        } //Обращаем все координаты

        public Bitmap Draw(Vector translation, Vector scale, Vector rotation)
        {
            TransformModel(translation, scale, rotation);
            CompleteModelDraw();
            var outBitmap = ModelBitmap;
            return outBitmap;
        }

        private void FindAreaSize(out int width, out int height)
        {
            double maxX = -10000, minX = 10000, maxY = -10000, minY = 10000;
            foreach (var v in Vertices)
            {
                if (v.X < minX) minX = v.X;
                if (v.X > maxX) maxX = v.X;
                if (v.Y < minY) minY = v.Y;
                if (v.Y > maxY) maxY = v.Y;
            }

            int ampX = (int)Math.Ceiling(maxX - minX), ampY = (int)Math.Ceiling(maxY - minY);
            width = ampX;
            height = ampY;
        }

        #endregion
    }
}