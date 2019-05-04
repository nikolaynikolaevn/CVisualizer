using System;

namespace CVisualizer
{
    public static class PolynomialCalculator
    {
        private static double[] CalculateMatrixRoots(double[,] matrix)
        {
            int nPoints = matrix.GetUpperBound(0) + 1;
            int nColumns = nPoints + 1;
            double temp;
            for (int col = 0; col < nPoints; col++)
            {
                for (int row = 0; row < nPoints; row++)
                {
                    if (row != col)
                    {
                        temp = matrix[row, col] / matrix[col, col];
                        for (int res = 0; res < nColumns; res++)
                        {
                            matrix[row, res] = matrix[row, res] - temp * matrix[col, res];
                        }
                    }
                }
            }
            double[] roots = new double[nPoints];
            for (int i = 0; i < nPoints; i++)
            {
                roots[i] = matrix[i, nPoints] /= matrix[i, i];
            }
            return roots;
        }
        public static double[] GenerateMatrix(float[,] points)
        {
            int nPoints = points.GetUpperBound(0) + 1;
            int nVariableColumns = nPoints + 1;
            int highestCoefficient = nPoints - 1;
            double[,] matrix = new double[nPoints, nVariableColumns];
            for (int i = 0; i < nPoints; i++)
            {
                for (int j = 0; j < nVariableColumns; j++)
                {
                    matrix[i, j] = Math.Pow(points[i, 0], highestCoefficient - j);
                }
                matrix[i, nPoints] = points[i, 1];
            }
            return CalculateMatrixRoots(matrix);
        }
    }
}
