using Common.DTOs;

namespace Server.BLL.Core
{
    public interface IResponseFactory
    {
        Response CreateResponse(string fromWho, object content, MessageContentType contentType);
    }
}
