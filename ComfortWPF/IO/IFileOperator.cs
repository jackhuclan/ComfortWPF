using System.IO;

namespace ComfortWPF.IO
{
    public interface IFileOperator
    {
        string ReadAllText(string fullFileName);

        void WriteAllText(string fullFileName, string text);

        bool Exists(string fullFileName);

        FileStream OpenRead(string fullFileName);
    }
}