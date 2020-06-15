using System;
using System.IO;
using System.Reflection;

namespace Quark
{
    public static class PathHelper
    {
        private static string _appFilePath;
        private static string _commonDocPath;

        /// <summary>
        /// Gets the application directory path. Path from where application is launched.
        /// </summary>
        public static string AppFilePath
        {
            get
            {
                if (string.IsNullOrEmpty(_appFilePath))
                {
                    _appFilePath =
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                }
                return _appFilePath;
            }
        }

        /// <summary>
        /// Gets the Common Documents path.
        /// </summary>
        public static string CommonDocumentsPath
        {
            get
            {
                if (string.IsNullOrEmpty(_commonDocPath))
                {
                    _commonDocPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
                }
                return _commonDocPath;
            }
        }

        /// <summary>
        ///     Copies the Directories.
        /// </summary>
        /// <param name="sourceDirName">Name of the source directory.</param>
        /// <param name="destDirName">Name of the destination directory.</param>
        /// <param name="copySubDirs">if set to <c>true</c> copies sub directories.</param>
        /// <exception cref="System.IO.DirectoryNotFoundException">
        ///     Source directory does not exist or could not be found: " +
        ///     sourceDirName
        /// </exception>
        public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            var dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
                throw new DirectoryNotFoundException(string.Format("Could not find Source Directory: {0}", sourceDirName));

            var dirs = dir.GetDirectories();

            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
                Directory.CreateDirectory(destDirName);

            // Get the files in the directory and copy them to the new location.
            var files = dir.GetFiles();
            foreach (var file in files)
            {
                var temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, true);
            }

            // If subdirectories, copy them and their contents to new location.
            if (!copySubDirs) return;

            foreach (var subdir in dirs)
            {
                var temppath = Path.Combine(destDirName, subdir.Name);
                DirectoryCopy(subdir.FullName, temppath, true);
            }
        }

        /// <summary>Gets a random folder name or file name</summary>
        /// <param name="extension">File extension</param>
        /// <returns>Random folder name or file name</returns>
        public static string RandomFileName(string extension)
        {
            return string.Format(extension.Contains(".") ? "{0}{1}" : "{0}.{1}", Path.GetRandomFileName(), extension);
        }
    }
}