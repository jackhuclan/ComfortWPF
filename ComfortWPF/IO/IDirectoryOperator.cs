namespace ComfortWPF.IO
{
    public interface IDirectoryOperator
    {
        void EnsureDirectoryExists(string directoryPath);
    }
}