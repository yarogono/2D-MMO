using Server.Handlers;

namespace Server.Network;

public sealed class HandlerDispatcher<TRequest, THandler> : IHandlerDispatcher
    where TRequest : IRequestMessage<TRequest>
    where THandler : IHandler<TRequest>
{
    private readonly THandler handler;
    private readonly IRequestMessage<TRequest> requestMessage;

    public HandlerDispatcher(THandler handler, IRequestMessage<TRequest> requestMessage)
    {
        this.handler = handler;
        this.requestMessage = requestMessage;
    }

    public Opcodes Opcode => requestMessage.Opcode;

    public Task<HandlerResult> ExectueAsync(PacketReader reader)
    {
        return handler.ExectueAsync(requestMessage.Read(reader));
    }
}
