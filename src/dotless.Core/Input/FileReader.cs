namespace dotless.Core.Input
{
    using System.IO;

    public class FileReader : IFileReader
    {
        public IPathResolver PathResolver { get; set; }

        public FileReader() : this(new RelativePathResolver())
        {
        }

        public FileReader(IPathResolver pathResolver)
        {
            PathResolver = pathResolver;
        }

        public byte[] GetBinaryFileContents(string fileName)
        {
            fileName = PathResolver.GetFullPath(fileName);

            return File.ReadAllBytes(fileName);
        }

        public string GetFileContents(string currentPath, string fileName)
        {
            fileName = PathResolver.GetFullPath(string.IsNullOrEmpty(currentPath) ? fileName : Path.Combine(currentPath, fileName));

            return File.ReadAllText(fileName);
        }

        public bool DoesFileExist(string currentPath, string fileName, out string existingFileName)
        {
            bool exists;

            if (File.Exists(PathResolver.GetFullPath(fileName)))
            {
                existingFileName = fileName;
                exists = true;
            }
            else
            {
                fileName = PathResolver.GetFullPath(string.IsNullOrEmpty(currentPath) ? fileName : Path.Combine(currentPath, fileName));
                if ((exists = File.Exists(fileName)))
                {
                    existingFileName = fileName;
                }
                else
                {
                    existingFileName = null;
                }
            }

            return exists;
        }

        public bool UseCacheDependencies { get { return true; } }
    }
}