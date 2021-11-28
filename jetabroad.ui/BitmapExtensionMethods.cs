using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jetabroad.ui
{
    //taken from https://lotsacode.wordpress.com/2010/02/23/using-lambda-to-manipulate-images/
    public static class BitmapExtensionMethods
    {
        public static void ExecuteForEachPixel(this Bitmap bitmap, Action<Point, Bitmap> action)
        {
            Point point = new Point(0, 0);
            for (int x = 0; x < bitmap.Width; x++)
            {
                point.X = x;
                for (int y = 0; y < bitmap.Height; y++)
                {
                    point.Y = y;
                    action(point, bitmap);
                }
            }
        }

        public static void ExecuteForEachPixel(this Bitmap bitmap, Action<Point> action)
        {
            Point point = new Point(0, 0);
            for (int x = 0; x < bitmap.Width; x++)
            {
                point.X = x;
                for (int y = 0; y < bitmap.Height; y++)
                {
                    point.Y = y;
                    action(point);
                }
            }
        }

        public static void SetEachPixelColour(this Bitmap bitmap, Func<Point, Color> colourFunc)
        {
            Point point = new Point(0, 0);
            for (int x = 0; x < bitmap.Width; x++)
            {
                point.X = x;
                for (int y = 0; y < bitmap.Height; y++)
                {
                    point.Y = y;
                    bitmap.SetPixel(x, y, colourFunc(point));
                }
            }
        }

        public static void SetEachPixelColour(this Bitmap bitmap, Func<Point, Color, Color> colourFunc)
        {
            Point point = new Point(0, 0);
            for (int x = 0; x < bitmap.Width; x++)
            {
                point.X = x;
                for (int y = 0; y < bitmap.Height; y++)
                {
                    point.Y = y;
                    bitmap.SetPixel(x, y, colourFunc(point, bitmap.GetPixel(x, y)));
                }
            }
        }
    }
}
