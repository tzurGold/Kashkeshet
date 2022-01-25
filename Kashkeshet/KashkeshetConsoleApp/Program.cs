using Client.BLL.Core;

namespace KashkeshetConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Bootstrapper bootstrapper = new Bootstrapper();

            IClientOrchestrator clientOrchestrator = bootstrapper.Initialize();

            clientOrchestrator?.Run();
        }
    }
}
