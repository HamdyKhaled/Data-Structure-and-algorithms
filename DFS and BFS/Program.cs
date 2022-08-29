using System;
using System.Collections.Generic;

namespace DFS_and_BFS
{
    class Program
    {
        //public static int OrangesRotting(int[][] grid)
        //{
        //    Queue<int[]> rotten = new Queue<int[]>();

        //    int r = grid.Length, c = grid[0].Length, fresh = 0, t = 0;
        //    for (int i = 0; i < r; ++i)
        //    {
        //        for (int j = 0; j < c; ++j)
        //        {
        //            if (grid[i][j] == 2) rotten.Enqueue(new int[] { i, j });
        //            else if (grid[i][j] == 1) fresh++;
        //        }
        //    }

        //    while (rotten.Count!=0)
        //    {
        //        int num = rotten.Count;
        //        for (int i = 0; i < num; ++i)
        //        {
        //            int x = rotten.Peek, y = rotten.peek[1];
        //            rotten.Dequeue();
        //            if (x > 0 && grid[x - 1][y] == 1) { grid[x - 1][y] = 2; fresh--; rotten.Enqueue(new int[] { x - 1, y }); };
        //            if (y > 0 && grid[x][y - 1] == 1) { grid[x][y - 1] = 2; fresh--; rotten.Enqueue(new int[] { x, y - 1 }); };
        //            if (x < r - 1 && grid[x + 1][y] == 1) { grid[x + 1][y] = 2; fresh--; rotten.Enqueue(new int[] { x + 1, y }); };
        //            if (y < c - 1 && grid[x][y + 1] == 1) { grid[x][y + 1] = 2; fresh--; rotten.Enqueue(new int[] { x, y + 1 }); };
        //        }
        //        if (rotten.Count != 0) t++;
        //    }
        //    return (fresh == 0) ? t : -1;

        //}

        public static int OrangesRotting(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            // Queue for rotten oranges
            Queue<int[]> rotten = new Queue<int[]>();
            var freshOranges = 0;
            // 1. Collect rotten oranges,
            // 2. and in same time count fresh oranges
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 2)
                    {
                        rotten.Enqueue(new int[] { i, j });
                    }
                    else if (grid[i][j] == 1)
                        freshOranges++;
                }
            }
            // 3. If there is no rotten orange in the bucket, we can wait theoritically infinite time fresh oranges to rot, so return -1
            if (freshOranges > 0 && rotten.Count == 0) return -1;
            // 4. Initialize four directions
            //  dirs[0] -> UP
            //  dirs[1] -> DOWN
            //  dirs[2] -> LEFT
            //  dirs[3] -> RIGHT
            int[][] dirs = { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } };
            int minutes = 0;
            while (rotten.Count > 0 && freshOranges > 0)
            {
                // 5. Iterate through the "tree" by a simple breath-first approach(level-by-level), so called expand every node of the current level
                // "rotten" variable can also be called "level"-of the tree
                // Note: every level (the for cycle) is a minute
                int rottenOrangesNumber = rotten.Count;
                for (int i = 0; i < rottenOrangesNumber; ++i)
                {
                    int[] cell = rotten.Dequeue();
                    foreach (int[] d in dirs)
                    {
                        // 6. Approach here is to check every 4 directions if there is fresh orange to rot
                        // and if there is, rot it(=2), then decrement the fresh orange counter
                        int r = cell[0] + d[0];
                        int c = cell[1] + d[1];
                        if (r < 0 || r >= m || c < 0 || c >= n ||
                            grid[r][c] != 1) continue;
                        rotten.Enqueue(new int[] { r, c });
                        grid[r][c] = 2;
                        freshOranges--;
                    }
                }
                minutes++;

            }
            // 7. If algorithm expanded all node(so rotten every possible oranges), but there is still fresh orange(s)
            // It only means the remaining fresh oranges are unreachable,
            // else return the minutes
            return freshOranges > 0 ? -1 : minutes;
        }
        public static int[][] FloodFill(int[][] image, int sr, int sc, int color)
        {
            if (image[sr][sc] == color)
                return image;
            fill(image, sr, sc, color, image[sr][sc]);
            return image;

        }
        public static bool[,] seen;
        public static int MaxAreaOfIsland(int[][] grid)
        {
            int max =0;
            int rows = grid.Length;
            int cols = grid[0].Length;

            seen = new bool[rows, cols];
            
            for(int i =0; i< rows; i++)
            {
                for(int j=0; j< cols; j++)
                {
                    max = Math.Max(max, GetArea(i ,j , grid));
                }
            }
            return max;
        }

        public static int GetArea(int row, int column, int[][] grid)
        {
            if(row < 0 || column < 0 || row >= grid.Length || column >= grid[0].Length || grid[row][column] == 0 || seen[row,column])
            {
                return 0;
            }
            seen[row, column] = true;
            return (1 + GetArea(row - 1, column, grid) + GetArea(row + 1, column, grid) + GetArea(row, column - 1, grid) + GetArea(row, column + 1, grid));

        }

        public static void fill(int[][] image, int sr, int sc, int Newcolor, int preColor)
        {
            if (sr < 0 || sc < 0 || sr >= image.Length || sc >= image[0].Length || image[sr][sc] != preColor)
                return;

            image[sr][sc] = Newcolor;
            fill(image, sr - 1, sc, Newcolor, preColor);
            fill(image, sr + 1, sc, Newcolor, preColor);
            fill(image, sr , sc - 1, Newcolor, preColor);
            fill(image, sr , sc + 1, Newcolor, preColor);

        }
        static void Main(string[] args)
        {
            int[][] arr= new int [][] { new int[]{ 1, 2, 1, 1 },
                new int[]{ 2, 1, 1, 2 },
                new int[] { 1, 0, 1, 0 } };
            //int[][] result = FloodFill(arr, 1, 2, 3);

            int[][] grid = new int[][] { 
                new int[] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
                new int[]{ 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 },
                new int[]{ 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[]{ 0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 1, 0 },
                new int[]{ 0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 0 },
                new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                new int[]{ 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 },
                new int[]{ 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 } };

            int[][] orangeBox = new int[][]
            {
                new int[]{ 2, 1, 1 },new int[]{1, 1, 0 },new int[]{0, 1, 1 } 
            };

            //int maxIsland = MaxAreaOfIsland(grid);

            int minutes = OrangesRotting(orangeBox);
        }
    }
}
