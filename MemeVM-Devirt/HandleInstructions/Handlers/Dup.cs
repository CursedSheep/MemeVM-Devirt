using System.IO;
using MemeVM_Devirt.InitPhase;

namespace MemeVM.Runtime.Handlers {
    class Dup : IHandler {
        public OpCode Handles => OpCode.Dup;

        public Instruction Deserialize(BinaryReader reader) =>
            new Instruction(OpCode.Dup);
    }
}
