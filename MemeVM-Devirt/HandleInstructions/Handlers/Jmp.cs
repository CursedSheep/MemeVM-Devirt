using System.IO;
using MemeVM_Devirt.InitPhase;

namespace MemeVM.Runtime.Handlers {
    class Jmp : IHandler {
        public OpCode Handles => OpCode.Jmp;

        public Instruction Deserialize(BinaryReader reader) =>
            new Instruction(OpCode.Jmp, reader.ReadInt32());
    }
}
