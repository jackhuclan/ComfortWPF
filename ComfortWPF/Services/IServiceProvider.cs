namespace ComfortWPF.Services
{
    public interface IServiceProvider
    {
        T GetService<T>();
    }
}
