using Client.BLL.Core;
using Client.UI.Core;
using System.IO;
using Common.DTOs;

namespace Client.BLL.Implementation.MessageContentProviders
{
    public class FileMessageProvider : MessageContentProviderBase
    {
        public FileMessageProvider(IInputReceiver inputReceiver, IOutputDisplayer outputDisplayer) :
            base(inputReceiver, outputDisplayer)
        {

        }

        public override object ProvideContent()
        {
            bool validPath = false;
            string filePath = string.Empty;
            while (!validPath)
            {
                OutputDisplayer.DisplayOutput("Please enter file's path: ");
                filePath = InputReceiver.GetInput();
                validPath = File.Exists(filePath);
            }
            FileInfo fileInfo = new FileInfo(filePath);
            string fileContent = File.ReadAllText(filePath);
            return new KashkeshetFile(fileInfo.Name, fileInfo.Length, fileContent);
        }
    }
}
