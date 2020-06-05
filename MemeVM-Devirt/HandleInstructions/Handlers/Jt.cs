using System.IO;
using MemeVM_Devirt.InitPhase;

namespace MemeVM.Runtime.Handlers {
    class Jt : IHandler {
        public OpCode Handles => OpCode.Jt;

        public Instruction Deserialize(BinaryReader reader) =>
            new Instruction(OpCode.Jt, reader.ReadInt32());
    }
}
