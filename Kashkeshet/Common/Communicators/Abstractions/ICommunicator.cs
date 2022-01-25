namespace Common.Communicators.Abstractions
{
    public interface ICommunicator
    {
        void Send(object obj);
        object Receive();
    }
}
