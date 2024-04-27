using Server.Network;

namespace Server;

public interface IRequestMessage<T> where T : IRequestMessage<T>
{
    Opcodes Opcode { get; }

    T Read(PacketReader reader);
}