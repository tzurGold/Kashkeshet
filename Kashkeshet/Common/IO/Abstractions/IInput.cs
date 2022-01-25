namespace Common.IO.Abstractions
{
    public interface IInput<T>
    {
        T Read();
    }
}
