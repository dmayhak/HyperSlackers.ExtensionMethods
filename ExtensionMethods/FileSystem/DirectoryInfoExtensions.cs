using System;
using System.Collections.Generic;

using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperSlackers.Extensions.IO
{
    public static partial class ExtensionMethods
    {
        /// <summary>
        /// Gets the files in a directory with the specified file extensions.
        /// </summary>
        /// <param name="directoryInfo">The directory information.</param>
        /// <param name="extensions">The extensions to filter by.</param>
        /// <returns></returns>
        public static IEnumerable<FileInfo> GetFilesByExtensions(this DirectoryInfo directoryInfo, params string[] extensions)
        {
            Helpers.ThrowIfNull(directoryInfo != null, "directoryInfo");
            Helpers.ThrowIfNull(extensions != null, "extensions");

            var allowedExtensions = new HashSet<string>(extensions, StringComparer.OrdinalIgnoreCase);

            return directoryInfo.EnumerateFiles().Where(f => allowedExtensions.Contains(f.Extension));
        }

        /// <summary>
        /// Recursively create directory
        /// </summary>
        /// <param name="value">The value.</param>
        public static void CreateDirectory(this DirectoryInfo value)
        {
            Helpers.ThrowIfNull(value != null, "value");

            if (value.Parent != null)
            {
                CreateDirectory(value.Parent);
            }

            if (!value.Exists)
            {
                value.Create();
            }
        }

        /// <summary>
        /// Delete files in a folder that are like the searchPattern, don't include sub-folders.
        /// </summary>
        /// <param name="value">The DirectoryInfo object</param>
        /// <param name="searchPattern">DOS like pattern (example: *.xml, ??a.txt)</param>
        /// <returns>Number of files that have been deleted.</returns>
        public static int DeleteFiles(this DirectoryInfo value, string searchPattern)
        {
            Helpers.ThrowIfNull(value != null, "value");
            Helpers.ThrowIfNull(!String.IsNullOrWhiteSpace(searchPattern), "searchPattern");

            return DeleteFiles(value, searchPattern, false);
        }

        /// <summary>
        /// Delete files in a folder that are like the searchPattern
        /// </summary>
        /// <param name="value">The DirectoryInfo object</param>
        /// <param name="searchPattern">DOS like pattern (example: *.xml, ??a.txt)</param>
        /// <param name="includeSubdirectories">if true, sub-directories are recursed into</param>
        /// <returns>Number of files that have been deleted.</returns>
        /// <remarks>
        /// This function relies on DirectoryInfo.GetFiles() which will first get all the FileInfo objects in memory. This is good for folders with not too many files, otherwise
        /// an implementation using Windows APIs can be more appropriate.
        /// </remarks>
        public static int DeleteFiles(this DirectoryInfo value, string searchPattern, bool includeSubdirectories)
        {
            Helpers.ThrowIfNull(value != null, "value");
            Helpers.ThrowIfNull(!String.IsNullOrWhiteSpace(searchPattern), "searchPattern");

            int filesDeleted = 0;
            foreach (FileInfo fi in value.GetFiles(searchPattern, includeSubdirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly))
            {
                fi.Delete();
                filesDeleted++;
            }

            return filesDeleted;
        }

        /// <summary>
        /// Gets the size of the directory on disk (including sub-directories).
        /// </summary>
        /// <param name="value">The DirectoryInfo object.</param>
        /// <returns>The size in bytes of all files</returns>
        public static long GetSize(this DirectoryInfo value)
        {
            Helpers.ThrowIfNull(value != null, "value");

            return GetSize(value, true);
        }

        /// <summary>
        /// Gets the size of the directory on disk (optionally, including sub-directories).
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="includeSubdirectories">if set to <c>true</c> subdirectory sizes will be included.</param>
        /// <returns>The size in bytes of all files</returns>
        public static long GetSize(this DirectoryInfo value, bool includeSubdirectories)
        {
            Helpers.ThrowIfNull(value != null, "value");

            long size = 0;

            // Loop through files and keep adding their size
            foreach (FileInfo fi in value.GetFiles())
            {
                size += fi.Exists ? fi.Length : 0;
            }

            if (includeSubdirectories)
            {
                // Loop through subdirectories and keep adding their size
                foreach (DirectoryInfo di in value.GetDirectories())
                {
                    size += di.Exists ? di.GetSize() : 0;
                }
            }

            return size;
        }

    }
}
