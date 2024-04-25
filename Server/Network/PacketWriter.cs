using System.Buffers.Binary;

namespace Server.Network;

public sealed class PacketWriter
{
    private readonly Memory<byte> buffer;
    private int offset = 4;

    public PacketWriter(Memory<byte> buffer, Opcodes opcode)
    {
        this.buffer = buffer;
        var span = buffer.Slice(2).Span;
        BinaryPrimitives.WriteUInt16LittleEndian(span, (ushort)opcode);
    }

    public Memory<byte> ToPacket()
    {
        var span = buffer.Span;
        BinaryPrimitives.WriteUInt16BigEndian(span, (ushort)(offset - 2));
        return buffer.Slice(0, offset);
    }

    public void UInt32(uint value)
    {
        BinaryPrimitives.WriteUInt32LittleEndian(buffer.Slice(offset).Span, value);
        offset += sizeof(int);
    }
}