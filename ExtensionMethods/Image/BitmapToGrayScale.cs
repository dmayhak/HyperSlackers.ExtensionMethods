using System;
using System.Collections.Generic;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperSlackers.Extensions.Drawing
{
    public static partial class ExtensionMethods
    {
        /// <summary>
        /// Convert image to grayscale.
        /// from http://stackoverflow.com/questions/271398/what-are-your-favorite-extension-methods-for-c-codeplex-com-extensionoverflow?page=2&tab=votes#tab-top
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <returns></returns>
        public static Bitmap ToGrayScale(this Bitmap bitmap)
        {
            Bitmap newBitmap = new Bitmap(bitmap.Width, bitmap.Height);
            Graphics g = Graphics.FromImage(newBitmap);

            //the grayscale ColorMatrix
            ColorMatrix colorMatrix = new ColorMatrix(new float[][] {
                new float[] {.3f, .3f, .3f, 0, 0},
                new float[] {.59f, .59f, .59f, 0, 0},
                new float[] {.11f, .11f, .11f, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {0, 0, 0, 0, 1}
            });

            ImageAttributes attributes = new ImageAttributes();

            attributes.SetColorMatrix(colorMatrix);
            g.DrawImage(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height), 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel, attributes);
            g.Dispose();

            return newBitmap;
        }
    }
}
