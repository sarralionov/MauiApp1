using System;
using System.Collections.Generic;

namespace MauiApp1
{
    public class RouteResult
    {
        public bool Found { get; private set; }
        public List<string> Points { get; private set; }
        public long TotalLength { get; private set; }

        public RouteResult(bool found, List<string> points, long totalLength)
        {
            Found = found;
            Points = points;
            TotalLength = totalLength;
        }
    }
}
