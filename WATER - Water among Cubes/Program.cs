using System;

public class Program
{
    public static void Main()
    {
        try
        {
            int t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                string[] dimensions = Console.ReadLine().Split();
                int n = int.Parse(dimensions[0]);
                int m = int.Parse(dimensions[1]);

                int[,] grid = new int[n, m];
                int[,] maxLeft = new int[n, m];
                int[,] maxRight = new int[n, m];
                int[,] maxUp = new int[n, m];
                int[,] maxDown = new int[n, m];

                for (int i = 0; i < n; ++i)
                {
                    string[] heights = Console.ReadLine().Split();
                    for (int j = 0; j < m; ++j)
                    {
                        grid[i, j] = int.Parse(heights[j]);
                    }
                }

                for (int i = 0; i < n; ++i)
                {
                    int maxHeight = 0;
                    for (int j = 0; j < m; ++j)
                    {
                        maxHeight = Math.Max(maxHeight, grid[i, j]);
                        maxLeft[i, j] = maxHeight;
                    }
                }

                for (int i = 0; i < n; ++i)
                {
                    int maxHeight = 0;
                    for (int j = m - 1; j >= 0; --j)
                    {
                        maxHeight = Math.Max(maxHeight, grid[i, j]);
                        maxRight[i, j] = maxHeight;
                    }
                }

                for (int j = 0; j < m; ++j)
                {
                    int maxHeight = 0;
                    for (int i = 0; i < n; ++i)
                    {
                        maxHeight = Math.Max(maxHeight, grid[i, j]);
                        maxUp[i, j] = maxHeight;
                    }
                }

                for (int j = 0; j < m; ++j)
                {
                    int maxHeight = 0;
                    for (int i = n - 1; i >= 0; --i)
                    {
                        maxHeight = Math.Max(maxHeight, grid[i, j]);
                        maxDown[i, j] = maxHeight;
                    }
                }

                int totalWater = 0;
                for (int i = 0; i < n; ++i)
                {
                    for (int j = 0; j < m; ++j)
                    {
                        int minHeight = Math.Min(maxLeft[i, j], Math.Min(maxRight[i, j], Math.Min(maxUp[i, j], maxDown[i, j])));
                        totalWater += minHeight - grid[i, j];
                    }
                }

                Console.WriteLine(totalWater);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}