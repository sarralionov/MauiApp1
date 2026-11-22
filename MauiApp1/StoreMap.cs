using System;
using System.Collections.Generic;

namespace MauiApp1
{
    public class StoreMap
    {
        public string Name { get; private set; }
        public List<string> Points { get; private set; }
        public List<Passage> Passages { get; private set; }

        public StoreMap(string name, params string[] points)
        {
            Name = name;
            Points = new List<string>(points);
            Passages = new List<Passage>();
        }

        public void AddPassage(string from, string to, int length)
        {
            if (!Points.Contains(from) || !Points.Contains(to))
                throw new ArgumentException("Both points must exist in the map.");

            Passages.Add(new Passage(from, to, length));
        }

        public void SetPassageOpen(string from, string to, bool isOpen)
        {
            foreach (Passage passage in Passages)
            {
                bool sameDirection = passage.From == from && passage.To == to;
                bool reverseDirection = passage.From == to && passage.To == from;

                if (sameDirection || reverseDirection)
                {
                    passage.IsOpen = isOpen;
                    return;
                }
            }

            throw new ArgumentException("This passage does not exist in the map.");
        }
    }
}
