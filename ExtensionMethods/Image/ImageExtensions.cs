using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperSlackers.Extensions.Drawing
{
    public static partial class ExtensionMethods
    {

        /// <summary>
        /// Resizes the specified image.
        /// </summary>
        /// <param name="value">The original image.</param>
        /// <param name="percentage">The percentage change in size.</param>
        /// <returns>The resized image</returns>
        public static Image Resize(this Image value, int percentage)
        {
            Contract.Requires<ArgumentNullException>(value != null, "value");

            int width = (int)(value.Width * percentage);
            int height = (int)(value.Height * percentage);

            using (Bitmap bmp = new Bitmap(width, height))
            {
                Graphics graphic = Graphics.FromImage((Image)bmp);
                graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphic.DrawImage(value, 0, 0, width, height);
                graphic.Dispose();

                return (Image)bmp;
            }
        }

        /// <summary>
        /// Resizes the specified image.
        /// </summary>
        /// <param name="value">The original image.</param>
        /// <param name="width">The new width.</param>
        /// <param name="height">The new height.</param>
        /// <returns>The resized image</returns>
        public static Image Resize(this Image value, int width, int height)
        {
            using (Bitmap bmp = new Bitmap(width, height))
            {
                Graphics graphic = Graphics.FromImage((Image)bmp);
                graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphic.DrawImage(value, 0, 0, width, height);
                graphic.Dispose();

                return (Image)bmp;
            }
        }
    }
}
