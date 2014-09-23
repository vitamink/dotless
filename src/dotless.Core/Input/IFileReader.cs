namespace dotless.Core.Input
{
    public interface IFileReader
    {
        byte[] GetBinaryFileContents(string fileName);//TODO change this too...

        string GetFileContents(string currentPath, string fileName);

        bool DoesFileExist(string currentPath, string fileName, out string existingFile);

        bool UseCacheDependencies { get; }
    }
}