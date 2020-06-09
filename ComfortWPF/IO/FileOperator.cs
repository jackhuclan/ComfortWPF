using System.ComponentModel.Composition;
using System.IO;
using System.Text;

namespace ComfortWPF.IO
{
    [Export(typeof(IFileOperator))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class FileOperator : IFileOperator
    {
        #region IFileOperator Members

        public string ReadAllText(string fullFileName)
        {
            return File.ReadAllText(fullFileName, Encoding.UTF8);
        }

        public void WriteAllText(string fullFileName, string contents)
        {
            File.WriteAllText(fullFileName, contents, Encoding.UTF8);
        }

        public bool Exists(string fullFileName)
        {
            return File.Exists(fullFileName);
        }

        public FileStream OpenRead(string fullFileName)
        {
            return File.OpenRead(fullFileName);
        }

        #endregion
    }
}