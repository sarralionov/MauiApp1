using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    class StorePoint
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public float X { get; set; }
        public float Y { get; set; }

        public StorePoint(
            string id, string name,
            float x, float y)
        {
            Id = id;
            Name = name;
            X = x;
            Y = y;
        }
    }
}
