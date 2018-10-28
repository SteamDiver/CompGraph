using System;

namespace MyDrawing.D3
{
    public struct Vertex2D
    {
        public double U;
        public double V;

        public Vertex2D(double u, double v)
        {
            U = u;
            V = v;
        }
    }

    public class Vertex
    {
        public double X;
        public double Y;
        public double Z;
        public MatrixVector CoordVector;
        public Vector VNormal;

        public Vertex(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
            CoordVector = new MatrixVector(x, y, z, 1);
            VNormal = new Vector(0, 0, 0);
        }
    }

    public struct MatrixVector
    {
        public double X;
        public double Y;
        public double Z;
        public double W;

        public MatrixVector(double x, double y, double z, double w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }
    }

    public struct Vector
    {
        public double X;
        public double Y;
        public double Z;
        public double Magnitude => Math.Sqrt(X * X + Y * Y + Z * Z);

        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }

        public static Vector operator *(double value, Vector v)
        {
            return new Vector(v.X * value, v.Y * value, v.Z * value);
        }

        public static double operator *(Vector v1, Vector v2)
        {
            return v1.Magnitude * v2.Magnitude * CosCalc(v1, v2);
        }

        public static Vector operator -(Vector v)
        {
            return new Vector(-v.X, -v.Y, -v.Z);
        }

        /// <summary>
        /// Нормализация вектора(каждую компоненту делим на длину вектора)
        /// </summary>
        /// <param name="v"></param>
        public void Normalize()
        {
            var magnitude = Magnitude;
            if (magnitude > 0)
            {
                X /= magnitude;
                Y /= magnitude;
                Z /= magnitude;
            }
        }

        public Vector(Vertex v1, Vertex v2)
        {

            X = v1.X - v2.X;
            Y = v1.Y - v2.Y;
            Z = v1.Z - v2.Z;

        }

        public static Vector GetNormal(Vector v1, Vector v2)
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
        /// Нахождение косинуса между двумя векторами
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static double CosCalc(Vector v1, Vector v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        } 
    }

    public struct Triangle
    {
        public Vertex V1;
        public Vertex V2;
        public Vertex V3;
        public Vertex2D C1;
        public Vertex2D C2;
        public Vertex2D C3;
        public Vector Norm => GetNorm();

        public Triangle(Vertex v1, Vertex v2, Vertex v3, Vertex2D c1, Vertex2D c2, Vertex2D c3)
        {
            V1 = v1;
            V2 = v2;
            V3 = v3;
            C1 = c1;
            C2 = c2;
            C3 = c3;

            V1.VNormal += GetNorm();
            V2.VNormal += GetNorm();
            V3.VNormal += GetNorm();
        }

        private Vector GetNorm()
        {
            var vector1 = new Vector(V1, V2);
            var vector2 = new Vector(V2, V3);
            return Vector.GetNormal(vector1, vector2);
        }

    }

    public struct Quad
    {
        public Vertex V1;
        public Vertex V2;
        public Vertex V3;
        public Vertex V4;
        public Vertex2D C1;
        public Vertex2D C2;
        public Vertex2D C3;
        public Vertex2D C4;

        public Quad(Vertex v1, Vertex v2, Vertex v3, Vertex v4, Vertex2D c1, Vertex2D c2, Vertex2D c3, Vertex2D c4)
        {
            V1 = v1;
            V2 = v2;
            V3 = v3;
            V4 = v4;
            C1 = c1;
            C2 = c2;
            C3 = c3;
            C4 = c4;
        }
    }
}
