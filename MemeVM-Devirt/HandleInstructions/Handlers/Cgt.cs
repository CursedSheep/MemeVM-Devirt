using System.IO;
using MemeVM_Devirt.InitPhase;

namespace MemeVM.Runtime.Handlers {
    class Cgt : IHandler {
        public OpCode Handles => OpCode.Cgt;

        public Instruction Deserialize(BinaryReader reader) =>
            new Instruction(OpCode.Cgt);
    }
}
