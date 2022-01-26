using Common.DTOs;
using log4net;
using Server.BLL.Core;
using System.Reflection;

namespace Server.BLL.Implementation
{
    public class KashkeshetResponseFactory : IResponseFactory
    {
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Response CreateResponse(string chatName, string fromWho, object content, MessageContentType contentType)
        {
            _log.DebugFormat("Create new response: {0}/{1}: {2}", chatName, fromWho, content);
            return new Response(chatName, fromWho, content, contentType);
        }
    }
}
