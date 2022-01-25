namespace Common.IO
{
    public interface IOutput<T>
    {
        void Write(T output);
    }
}
