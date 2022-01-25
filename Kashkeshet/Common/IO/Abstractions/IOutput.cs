namespace Common.IO.Abstractions
{
    public interface IOutput<T>
    {
        void Write(T output);
    }
}
