namespace Common.IO.Abstraction
{
    public interface IOutput<T>
    {
        void Write(T output);
    }
}
