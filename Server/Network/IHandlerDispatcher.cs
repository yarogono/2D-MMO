namespace Server.Network;

public interface IHandlerDispatcher
{
    Opcodes Opcode { get; }

    Task<HandlerResult> ExectueAsync(PacketReader reader);
}
