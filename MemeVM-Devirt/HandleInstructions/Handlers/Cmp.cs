using System.IO;
using MemeVM_Devirt.InitPhase;

namespace MemeVM.Runtime.Handlers {
    class Cmp : IHandler {
        public OpCode Handles => OpCode.Cmp;

        public Instruction Deserialize(BinaryReader reader) =>
            new Instruction(OpCode.Cmp);
    }
}
