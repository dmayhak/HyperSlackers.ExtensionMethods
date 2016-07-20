using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Diagnostics;

using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperSlackers.Extensions.IO
{
    public static partial class ExtensionMethods
    {
        /// <summary>
        /// Open with default 'open' program
        /// </summary>
        /// <param name="value"></param>
        public static Process Open(this FileInfo value)
        {
            if (!value.Exists)
            {
                throw new FileNotFoundException("File doesn't exist");
            }

            Process p = new Process();

            p.StartInfo.FileName = value.FullName;
            p.StartInfo.Verb = "Open";
            p.Start();

            return p;
        }

        /// <summary>
        /// Print the file
        /// </summary>
        /// <param name="value"></param>
        public static void Print(this FileInfo value)
        {
            if (!value.Exists)
            {
                throw new FileNotFoundException("File doesn't exist");
            }

            Process p = new Process();

            p.StartInfo.FileName = value.FullName;
            p.StartInfo.Verb = "Print";
            p.Start();
        }

        /// <summary>
        /// Send this file to the Recycle Bin
        /// </summary>
        /// <exception cref="File doesn't exist" />
        /// <param name="value"></param>
        public static void Recycle(this FileInfo value)
        {
            value.Recycle(false);
        }

        /// <summary>
        /// Send this file to the Recycle Bin
        /// On show, if person refuses to send file to the recycle bin,
        /// exception is thrown or otherwise delete fails
        /// </summary>
        /// <exception cref="File doesn't exist" />
        /// <exception cref="On show, if user refuses, throws exception 'The operation was canceled.'" />
        /// <param name="value">File being recycled</param>
        /// <param name="showDialog">true to show pop-up</param>
        public static void Recycle(this FileInfo value, bool showDialog)
        {
            if (!value.Exists)
            {
                throw new FileNotFoundException("File doesn't exist");
            }

            if (showDialog)
            {
                FileSystem.DeleteFile(value.FullName, UIOption.AllDialogs, RecycleOption.SendToRecycleBin);
            }
            else
            {
                FileSystem.DeleteFile(value.FullName, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
            }
        }
    }
}
