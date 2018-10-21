﻿using System;

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
        public double[] CoordVector;
        public Vector VNormal;

        public Vertex(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
            CoordVector = new[] {x, y, z, 1};
            VNormal = new Vector(0, 0, 0);
        }
    }

    public struct Vector
    {
        public double X;
        public double Y;
        public double Z;

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

        public static Vector operator -(Vector v)
        {
            return new Vector(-v.X, -v.Y, -v.Z);
        }

        /// <summary>
        /// Нормализация вектора(каждую компоненту делим на длину вектора)
        /// </summary>
        /// <param name="v"></param>
        public static void Normalize(ref Vector v)
        {
            var magnitude = Math.Sqrt(v.X * v.X + v.Y * v.Y + v.Z * v.Z);
            if (Math.Abs(magnitude) > 0)
            {
                v.X /= magnitude;
                v.Y /= magnitude;
                v.Z /= magnitude;
            }
        }

        /// <summary>
        ///  Нахождение величины вектора
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static double Magnitude(Vector v)
        {
            return Math.Sqrt(v.X * v.X + v.Y * v.Y + v.Z * v.Z);
        }

        public static double DotProduct(Vector v1, Vector v2)
        {
            return Magnitude(v1) * Magnitude(v2) * CosCalc(v1, v2);
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
        public int V1;
        public int V2;
        public int V3;
        public int C1;
        public int C2;
        public int C3;

        public Triangle(int v1, int v2, int v3, int c1, int c2, int c3)
        {
            V1 = v1;
            V2 = v2;
            V3 = v3;
            C1 = c1;
            C2 = c2;
            C3 = c3;
        }
    }

    public struct Quad
    {
        public int V1;
        public int V2;
        public int V3;
        public int V4;
        public int C1;
        public int C2;
        public int C3;
        public int C4;

        public Quad(int v1, int v2, int v3, int v4, int c1, int c2, int c3, int c4)
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
