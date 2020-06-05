using System.IO;
using MemeVM_Devirt.InitPhase;

namespace MemeVM.Runtime.Handlers {
    class Jf : IHandler {
        public OpCode Handles => OpCode.Jf;

        public Instruction Deserialize(BinaryReader reader) =>
            new Instruction(OpCode.Jf, reader.ReadInt32());
    }
}
