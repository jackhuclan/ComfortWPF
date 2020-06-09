namespace ComfortWPF.IO
{
    public interface IBinarySerializer
    {
        T DeserializeFromFile<T>(string fullFileName) where T : class;

        void Serialize<T>(T objectToSerialize, string fullFileName) where T : class;
    }
}