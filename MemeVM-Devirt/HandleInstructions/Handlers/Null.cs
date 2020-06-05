using System.IO;
using MemeVM_Devirt.InitPhase;

namespace MemeVM.Runtime.Handlers {
    class Null : IHandler {
        public OpCode Handles => OpCode.Null;

        public Instruction Deserialize(BinaryReader reader) =>
            new Instruction(OpCode.Null);
    }
}
