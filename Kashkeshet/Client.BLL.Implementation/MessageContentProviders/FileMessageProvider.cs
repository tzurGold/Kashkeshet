using Client.BLL.Core;
using Client.UI.Core;
using System.IO;
using Common.DTOs;

namespace Client.BLL.Implementation.MessageContentProviders
{
    public class FileMessageProvider : MessageContentProviderBase
    {
        public FileMessageProvider(IInputReceiver inputReceiver) :
            base(inputReceiver)
        {

        }

        public override object ProvideContent()
        {
            bool validPath = false;
            string filePath = string.Empty;
            while (!validPath)
            {
                filePath = InputReceiver.GetInput("Please enter file's path: ");
                validPath = File.Exists(filePath);
            }
            FileInfo fileInfo = new FileInfo(filePath);
            string fileContent = File.ReadAllText(filePath);
            return new KashkeshetFile(fileInfo.Name, fileInfo.Length, fileContent);
        }
    }
}
