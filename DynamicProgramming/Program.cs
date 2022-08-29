using System;

namespace DynamicProgramming
{
    class Program
    {
        public static int[,] UpdateMatrix(int[][] mat)
        {
            int[,] distances = new int[mat.Length, mat[0].Length];
            int maxDistance = mat.Length - 1 + mat[0].Length - 1;

            for (int i=0; i<mat.Length; i++)//from up to down and right to left 
            {
                for (int j=0; j<mat[0].Length; j++)
                {
                    if(mat[i][j] != 0)
                    {
                        int upCell = (i > 0) ? distances[i - 1,j] : maxDistance;
                        int leftCell = (j > 0) ? distances[i,j - 1] : maxDistance;
                        distances[i,j] = Math.Min(upCell, leftCell)+1;
                    }
                }
            }

            for (int i= mat.Length -1; i>=0; i--)
            {
                for (int j = mat[0].Length-1; j>=0;j--)
                {
                    if(mat[i][j] != 0)
                    {
                        int downCell = (i < mat.Length - 1) ? distances[i + 1,j] : maxDistance;
                        int rightCell = (i < mat.Length - 1) ? distances[i,j+1] : maxDistance;
                        distances[i,j] = Math.Min(Math.Min(downCell, rightCell)+1, distances[i,j]);
                    }
                }
            }
            return distances;

        }

        static void Main(string[] args)
        {
            int[][] mat = new int[][]
            {
                new int[]{0,1,0},
                new int[]{1,1,0},
                new int[]{1,1,1}
            };

            int[,] result = UpdateMatrix(mat);
        }
    }
}
