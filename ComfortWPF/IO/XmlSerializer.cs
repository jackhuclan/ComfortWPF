using System;
using System.ComponentModel.Composition;
using System.IO;

namespace ComfortWPF.IO
{
    [Export(typeof(IXmlSerializer))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class XmlSerializer : IXmlSerializer
    {
        [ImportingConstructor]
        public XmlSerializer(IFileOperator fileOperator)
        {
            _fileOperator = fileOperator;
        }

        #region IXmlSerializer Members

        public T DeserializeFromFile<T>(string fullFileName) where T : class
        {
            if (!_fileOperator.Exists(fullFileName))
            {
                return default;
            }

            using (var stream = _fileOperator.OpenRead(fullFileName))
            {
                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                return serializer.Deserialize(stream) as T;
            }
        }

        public void Serialize<T>(T objectToSerialize, string fullFileName) where T : class
        {
            if (!Directory.Exists(Path.GetDirectoryName(fullFileName)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(fullFileName) ?? throw new InvalidOperationException());
            }

            using (var stream = File.Create(fullFileName))
            {
                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                serializer.Serialize(stream, objectToSerialize);
                stream.Flush();
            }
        }

        #endregion

        #region Fields

        private readonly IFileOperator _fileOperator;

        #endregion
    }
}