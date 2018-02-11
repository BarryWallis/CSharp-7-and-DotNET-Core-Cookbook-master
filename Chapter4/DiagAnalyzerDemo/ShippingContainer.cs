using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagAnalyzerDemo
{
    public class ShippingContainer
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }
        public int[] DimensionsWHL { get; set; }

        public ShippingContainer(int width, int height, int length)
        {
            Width = width;
            Height = height;
            Length = length;

            DimensionsWHL = new int[] { width, height, length };
        }
    }
}
