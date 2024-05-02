using Server.Network;

namespace Server;

public interface IRequestMessage<T> where T : IRequestMessage<T>
{
    static Opcodes Opcode { get; }

    static T Read(PacketReader reader);
}