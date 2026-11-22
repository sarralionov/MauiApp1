using System;
using System.Collections.Generic;

namespace MauiApp1
{
    public class Passage
    {
        public string From { get; private set; }
        public string To { get; private set; }
        public int Length { get; private set; }
        public bool IsOpen { get; set; }

        public Passage(string from, string to, int length)
        {
            if (length <= 0)
                throw new ArgumentException("Passage length must be positive.");

            From = from;
            To = to;
            Length = length;
            IsOpen = true;
        }
    }
}
