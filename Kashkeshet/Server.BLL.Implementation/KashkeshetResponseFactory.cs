using Common.DTOs;
using Server.BLL.Core;

namespace Server.BLL.Implementation
{
    public class KashkeshetResponseFactory : IResponseFactory
    {
        public Response CreateResponse(string fromWho, object content, MessageContentType contentType)
        {
            return new Response(fromWho, content, contentType);
        }
    }
}
