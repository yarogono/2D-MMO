namespace Server.Network;

// 메시지 코드를 정의하는 enum
// int(4byte) 보다 작은 ushort(2byte)를 사용해서 enum 값 정의
// 0x0 같은 16진수를 사용해서 메시지(Opcode)에 작성하는 자릿수의 범위를 줄임
public enum Opcodes : ushort
{
    MSG_NULL_ACTION = 0x0,
}