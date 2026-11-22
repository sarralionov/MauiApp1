using System;
using System.Collections.Generic;

namespace MauiApp1
{
    public static class RouteFinder
    {
        public static RouteResult FindRoute(StoreMap map, string start, string target)
        {
            int startIndex = map.Points.IndexOf(start);
            int targetIndex = map.Points.IndexOf(target);

            if (startIndex == -1 || targetIndex == -1)
                throw new ArgumentException("Start and target must exist in the map.");

            int count = map.Points.Count;
            long[] distance = new long[count];
            int[] previous = new int[count];
            bool[] visited = new bool[count];

            for (int i = 0; i < count; i++)
            {
                distance[i] = long.MaxValue;
                previous[i] = -1;
            }

            distance[startIndex] = 0;

            for (int step = 0; step < count; step++)
            {
                // Choose the closest point that has not been visited.
                int current = -1;
                long bestDistance = long.MaxValue;

                for (int i = 0; i < count; i++)
                {
                    if (!visited[i] && distance[i] < bestDistance)
                    {
                        current = i;
                        bestDistance = distance[i];
                    }
                }

                // There are no more reachable points.
                if (current == -1)
                    break;

                visited[current] = true;

                if (current == targetIndex)
                    break;

                string currentId = map.Points[current];

                foreach (Passage passage in map.Passages)
                {
                    // A closed passage is not considered by the route search.
                    if (!passage.IsOpen)
                        continue;

                    int next = -1;

                    if (passage.From == currentId)
                        next = map.Points.IndexOf(passage.To);
                    else if (passage.To == currentId)
                        next = map.Points.IndexOf(passage.From);

                    if (next == -1 || visited[next])
                        continue;

                    long candidateDistance = distance[current] + passage.Length;

                    if (candidateDistance < distance[next])
                    {
                        distance[next] = candidateDistance;
                        previous[next] = current;
                    }
                }
            }

            if (distance[targetIndex] == long.MaxValue)
                return new RouteResult(false, new List<string>(), 0);

            // Reconstruct the route from target back to start.
            List<string> route = new List<string>();
            int point = targetIndex;

            while (point != -1)
            {
                route.Insert(0, map.Points[point]);
                point = previous[point];
            }

            return new RouteResult(true, route, distance[targetIndex]);
        }
    }
}
