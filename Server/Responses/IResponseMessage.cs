using Server.Network;

namespace Server.Responses;

public interface IResponseMessage
{
    Opcodes Opcode { get; }

    void Write(PacketWriter writer);
}