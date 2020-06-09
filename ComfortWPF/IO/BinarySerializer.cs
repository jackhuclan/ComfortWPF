using System;
using System.ComponentModel.Composition;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ComfortWPF.IO
{
    [Export(typeof(IBinarySerializer))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class BinarySerializer : IBinarySerializer
    {
        [ImportingConstructor]
        public BinarySerializer(IFileOperator fileOperator)
        {
            _fileOperator = fileOperator;
        }

        #region IBinarySerializer Members

        public T DeserializeFromFile<T>(string fullFileName) where T : class
        {
            if (!_fileOperator.Exists(fullFileName)) return default;

            using (var stream = new FileStream(fullFileName, FileMode.Open))
            {
                var formatter = new BinaryFormatter();
                return formatter.Deserialize(stream) as T;
            }
        }

        public void Serialize<T>(T objectToSerialize, string fullFileName) where T : class
        {
            if (!Directory.Exists(Path.GetDirectoryName(fullFileName)))
                Directory.CreateDirectory(Path.GetDirectoryName(fullFileName) ?? throw new InvalidOperationException());

            using (var stream = new FileStream(fullFileName, FileMode.OpenOrCreate))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, objectToSerialize);
                stream.Flush();
            }
        }

        #endregion

        #region Fields

        private readonly IFileOperator _fileOperator;

        #endregion
    }
}