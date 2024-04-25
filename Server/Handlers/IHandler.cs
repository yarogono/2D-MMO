using Server.Network;

namespace Server.Handlers;

public interface IHandler<TRequest> where TRequest : IRequestMessage<TRequest>
{
    Task<HandlerResult> ExectueAsync(TRequest request);
}