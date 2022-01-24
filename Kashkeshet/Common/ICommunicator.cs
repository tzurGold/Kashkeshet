namespace Common
{
    public interface ICommunicator
    {
        void Send(object obj);
        object Receive();
    }
}
