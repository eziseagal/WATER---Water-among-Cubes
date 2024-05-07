using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int t = int.Parse(Console.ReadLine());
        for (int _ = 0; _ < t; _++)
        {
            if (_ > 0)
                Console.ReadLine();

            string[] dimensions = Console.ReadLine().Split();
            int n = int.Parse(dimensions[0]);
            int m = int.Parse(dimensions[1]);

            int[,] heights = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                string[] row = Console.ReadLine().Split();
                for (int j = 0; j < m; j++)
                {
                    heights[i, j] = int.Parse(row[j]);
                }
            }

            Console.WriteLine(CalculateWaterVolume(heights, n, m));
        }
    }

    static int CalculateWaterVolume(int[,] heights, int n, int m)
    {
        var visited = new bool[n, m];
        var pq = new PriorityQueue<(int, int, int), int>();

        for (int i = 0; i < n; i++)
        {
            pq.Enqueue((i, 0, heights[i, 0]), heights[i, 0]);
            pq.Enqueue((i, m - 1, heights[i, m - 1]), heights[i, m - 1]);
            visited[i, 0] = visited[i, m - 1] = true;
        }
        for (int j = 1; j < m - 1; j++)
        {
            pq.Enqueue((0, j, heights[0, j]), heights[0, j]);
            pq.Enqueue((n - 1, j, heights[n - 1, j]), heights[n - 1, j]);
            visited[0, j] = visited[n - 1, j] = true;
        }

        int[] dx = { 0, 1, 0, -1 };
        int[] dy = { 1, 0, -1, 0 };
        int totalWater = 0;

        while (pq.Count > 0)
        {
            var (x, y, h) = pq.Dequeue();

            for (int d = 0; d < 4; d++)
            {
                int nx = x + dx[d];
                int ny = y + dy[d];
                if (nx >= 0 && nx < n && ny >= 0 && ny < m && !visited[nx, ny])
                {
                    visited[nx, ny] = true;
                    int waterHeight = Math.Max(h, heights[nx, ny]);
                    totalWater += Math.Max(0, h - heights[nx, ny]);
                    pq.Enqueue((nx, ny, waterHeight), waterHeight);
                }
            }
        }

        return totalWater;
    }
}