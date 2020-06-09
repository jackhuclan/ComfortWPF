using System.ComponentModel.Composition;
using System.IO;

namespace ComfortWPF.IO
{
    [Export(typeof(IDirectoryOperator))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class DirectoryOperator : IDirectoryOperator
    {
        public void EnsureDirectoryExists(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }
    }
}