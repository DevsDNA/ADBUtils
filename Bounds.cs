using System;

namespace AdbUtils
{
    public struct Bounds
    {        
        public Bounds(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public Bounds(string bounds)
        {            
            var values = bounds.Replace("[", string.Empty).Replace("]", ",").Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            X = int.Parse(values[0]);
            Y = int.Parse(values[1]);
            Width = int.Parse(values[2]);
            Height = int.Parse(values[3]);
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public override string ToString() => $"{X} {Y} {Width} {Height}";
        

    }
}
