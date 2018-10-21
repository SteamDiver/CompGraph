using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing.D3
{
    class ModelTransform
    {
       
        public static double[,] GetScaleMatrix(double[] matrixValues)
        {
            double[,] result = new double[,] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };
            result[0, 0] = matrixValues[0];
            result[1, 1] = matrixValues[1];
            result[2, 2] = matrixValues[2];
            return result;
        }
        public static double[,] GetTranslateMatrix(double[] matrixValues)
        {
            double[,] result = new double[,] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };
            result[0, 3] = matrixValues[0];
            result[1, 3] = matrixValues[1];
            result[2, 3] = matrixValues[2];
            return result;
        }
        public static double[,] GetRotationMatrix(double[] values)
        {
            double[,] resultX = new double[,] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };
            double[,] resultY = new double[,] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };
            double[,] resultZ = new double[,] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };
            double angle1 = values[0], angle2 = values[1], angle3 = values[2];

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

            return MyMatrix3D.MatrixMultiplication(resultZ, MyMatrix3D.MatrixMultiplication(resultY, resultX));
        }

        public static double[,] GetProjectionatrix(double value)
        {
            double[,] result = new double[,] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0}, { 0, 0, 0, 1 } };
            result[3, 2] = 1 / value; 
            return result;
        }

        public static double[] CoordAfterTransformation(double[] xyz, double[,] mScale, double[,] mTranslate, double[,] mRotate, double[,] mProject)
        {
            double[] result = new double[4];
            result = xyz;
            result = MyMatrix3D.MatrixVectorMultiplication(mProject,MyMatrix3D.MatrixVectorMultiplication(mTranslate, 
                MyMatrix3D.MatrixVectorMultiplication(mRotate, MyMatrix3D.MatrixVectorMultiplication(mScale, xyz))));
            for (int i = 0; i < 3; i++)
            {
                result[i] /= result[3];
            }
            return result;

        }
    }

}


class MyMatrix3D
{

    public static double[,] MatrixMultiplication(double[,] A, double[,] B)//Умножение двух матриц
    {
        double[,] C = new double[4, 4];
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                double sum = 0;
                for (int k = 0; k < 4; k++)
                {
                    sum += A[i, k] * B[k, j];
                }
                C[i, j] = sum;
            }
        }
        return C;
    }

    public static double[] MatrixVectorMultiplication(double[,] matrix, double[] vector)
    {
        double[] result = new double[4];
        for (int i = 0; i < 4; i++)
        {
            double sum = 0;
            for (int j = 0; j < 4; j++)
            {
                sum += matrix[i, j] * vector[j];
            }
            result[i] = sum;
        }
        return result;
    }
}

