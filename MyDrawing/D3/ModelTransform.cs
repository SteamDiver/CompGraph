using System;
using MyDrawing.D3;

namespace MyDrawing.D3
{
    class ModelTransform
    {
       
        public static Matrix3D GetScaleMatrix(Vector scaleVector)
        {
            Matrix3D result =
                new Matrix3D(new double[,] {{1, 0, 0, 0}, {0, 1, 0, 0}, {0, 0, 1, 0}, {0, 0, 0, 1}})
                {
                    Matrix =
                    {
                        [0, 0] = scaleVector.X,
                        [1, 1] = scaleVector.Y,
                        [2, 2] = scaleVector.Z
                    }
                };
            return result;
        }
        public static Matrix3D GetTranslateMatrix(Vector translateVector)
        {
            Matrix3D result =
                new Matrix3D(new double[,] {{1, 0, 0, 0}, {0, 1, 0, 0}, {0, 0, 1, 0}, {0, 0, 0, 1}})
                {
                    Matrix =
                    {
                        [0, 3] = translateVector.X,
                        [1, 3] = translateVector.Y,
                        [2, 3] = translateVector.Z
                    }
                };
            return result;
        }

        public static Matrix3D GetRotationMatrix(Vector rotationVector)
        {
            Matrix3D resultX = new Matrix3D(new double[,]{ { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } });
            Matrix3D resultY = new Matrix3D(new double[,]{ { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } });
            Matrix3D resultZ = new Matrix3D(new double[,]{ { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } });
            double angle1 = rotationVector.X, angle2 = rotationVector.Y, angle3 = rotationVector.Z;

            resultX[1, 1] = Math.Cos(angle1);
            resultX[1, 2] = Math.Sin(angle1);
            resultX[2, 1] = -Math.Sin(angle1);
            resultX[2, 2] = Math.Cos(angle1);

            resultY[0, 0] = Math.Cos(angle2);
            resultY[0, 2] = -Math.Sin(angle2);
            resultY[2, 0] = Math.Sin(angle2);
            resultY[2, 2] = Math.Cos(angle2);


            resultZ[0, 0] = Math.Cos(angle3);
            resultZ[0, 1] = Math.Sin(angle3);
            resultZ[1, 0] = -Math.Sin(angle3);
            resultZ[1, 1] = Math.Cos(angle3);

            return resultZ * (resultY * resultX);
        }

        public static Matrix3D GetProjectionMatrix(double value)
        {
            Matrix3D result = new Matrix3D(new double[,] {{1, 0, 0, 0}, {0, 1, 0, 0}, {0, 0, 1, 0}, {0, 0, 0, 1}});
            result[3, 2] = 1 / value;

            return result;
        }

        public static Matrix3D GetViewPortMatrix(int x, int y, int w, int h)
        {
            Matrix3D m = new Matrix3D(new double[4,4]);
            m[0,3] = x + w / 2f;
            m[1,3] = y + h / 2f;
            m[2,3] = 512 / 2f;

            m[0,0] = w / 2f;
            m[1,1] = h / 2f;
            m[2,2] = 512 / 2f;
            return m;
        }

        public static MatrixVector TransformModel(MatrixVector xyz, Matrix3D mScale, Matrix3D mTranslate, Matrix3D mRotate, Matrix3D mProj)
        {
            MatrixVector result =  mProj* (mTranslate * (mRotate * (mScale * xyz)));
            
            result.X /= result.W;
            result.Y /= result.W;
            result.Z /= result.W;

            return result;

        }
    }

}

class Matrix3D
{
    public double[,] Matrix;
    public int Width => Matrix.GetLength(0);
    public int Height => Matrix.GetLength(1);

    public Matrix3D(double[,] matrix)
    {
        Matrix = matrix;
    }

    public static Matrix3D operator *(Matrix3D a, Matrix3D b)//Умножение двух матриц
    {
        double[,] c = new double[4, 4];
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                double sum = 0;
                for (int k = 0; k < 4; k++)
                {
                    sum += a[i, k] * b[k, j];
                }
                c[i, j] = sum;
            }
        }
        return new Matrix3D(c);
    }

    public static MatrixVector operator *(Matrix3D matrix, MatrixVector vector)
    {
        double[] result = new double[4];
        double[] v = {vector.X, vector.Y, vector.Z, vector.W};
        for (int i = 0; i < 4; i++)
        {
            double sum = 0;
            for (int j = 0; j < 4; j++)
            {
                sum += matrix[i, j] * v[j];
            }
            result[i] = sum;
        }
        return new MatrixVector(result[0], result[1], result[2], result[3]);
    }

    public double this[int i, int j]
    {
        get => Matrix[i, j];
        set => Matrix[i, j] = value;
    }

}

