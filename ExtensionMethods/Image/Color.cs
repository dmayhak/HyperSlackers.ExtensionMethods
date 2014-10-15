using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
        /// Gets a color that will be readable on top of a given background color.
        /// from http://stackoverflow.com/questions/271398/what-are-your-favorite-extension-methods-for-c-codeplex-com-extensionoverflow?page=3&tab=votes#tab-top
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static Color GetForegroundColor(this Color input)
        {
            // Math taken from one of the replies to
            // http://stackoverflow.com/questions/2241447/make-foregroundcolor-black-or-white-depending-on-background
            if (Math.Sqrt(input.R * input.R * .241 + input.G * input.G * .691 + input.B * input.B * .068) > 128)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        /// <summary>
        /// Converts the given color to gray.
        /// from http://stackoverflow.com/questions/271398/what-are-your-favorite-extension-methods-for-c-codeplex-com-extensionoverflow?page=3&tab=votes#tab-top
        /// </summary>
        /// <param name="value">The input.</param>
        /// <returns></returns>
        public static Color ToGray(this Color value)
        {
            int g = (int)(value.R * .299) + (int)(value.G * .587) + (int)(value.B * .114);

            return Color.FromArgb(value.A, g, g, g);
        }
    }
}
