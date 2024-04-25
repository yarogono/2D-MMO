using Server.Network;

namespace Server.Handlers;

internal interface IHandler<TRequest> where TRequest : IRequestMessage<TRequest>
{
    Task<HandlerResult> ExectueAsync(TRequest request);
}