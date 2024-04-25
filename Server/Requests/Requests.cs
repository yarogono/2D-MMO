using Server.Network;

namespace Server;

internal interface IRequestMessage<T> where T : IRequestMessage<T>
{
    static abstract Opcodes Opcode { get; }

    static abstract T Read(PacketReader reader);
}