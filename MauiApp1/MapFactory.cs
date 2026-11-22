using System;
using System.Collections.Generic;

namespace MauiApp1
{
    public static class MapFactory
    {
        public static StoreMap CreateMap1()
        {
            StoreMap map = new StoreMap("Map 1", "A", "B", "C", "D", "E");

            // Each line defines ONE two-way passage and its length.
            map.AddPassage("A", "B", 4);
            map.AddPassage("A", "C", 2);
            map.AddPassage("B", "C", 2);
            map.AddPassage("B", "D", 3);
            map.AddPassage("C", "D", 6);
            map.AddPassage("C", "E", 9);
            map.AddPassage("D", "E", 2);

            return map;
        }

        public static StoreMap CreateMap2()
        {
            StoreMap map = new StoreMap("Map 2", "A", "B", "C", "D", "E", "F");

            map.AddPassage("A", "B", 2);
            map.AddPassage("A", "C", 5);
            map.AddPassage("B", "D", 2);
            map.AddPassage("C", "D", 1);
            map.AddPassage("D", "E", 2);
            map.AddPassage("E", "F", 2);
            map.AddPassage("C", "F", 10);

            return map;
        }
    }
}
