using System.Buffers.Binary;

namespace Server.Network;

public sealed class PacketReader
{
    private Memory<byte> data;

    public PacketReader(Memory<byte> data)
    {
        this.data = data;
    }

    public uint UInt32()
    {
        var value = BinaryPrimitives.ReadUInt32LittleEndian(data.Span);
        data = data.Slice(sizeof(int));
        return value;
    }
}