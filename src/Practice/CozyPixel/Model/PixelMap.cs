﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozyPixel.Model
{
    public class PixelMap
    {
        public Bitmap data { get; set; }

        public bool ShowGrid { get; set; } = true;

        public int GridWidth { get; set; } = 2;

        public int PixelWidth { get; set; } = 8;

        public Color GridColor { get; set; } = Color.Black;

        public void Resize(int width, int height)
        {
            data = new Bitmap(width, height);
        }

        public void SetPixel(int x, int y, Color color)
        {
            data.SetPixel(x, y, color);
        }

        public Color GetPixel(int x, int y)
        {
            return data.GetPixel(x, y);
        }
    }
}
