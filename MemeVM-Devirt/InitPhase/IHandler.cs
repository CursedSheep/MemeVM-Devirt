using System.IO;
using MemeVM_Devirt.InitPhase;

namespace MemeVM_Devirt.InitPhase
{
    interface IHandler {
        OpCode Handles { get; }
        Instruction Deserialize(BinaryReader reader);
    }
}
