using System.IO;
using MemeVM_Devirt.InitPhase;

namespace MemeVM.Runtime.Handlers {
    class Ret : IHandler {
        public OpCode Handles => OpCode.Ret;

        public Instruction Deserialize(BinaryReader reader) =>
            new Instruction(OpCode.Ret);
    }
}
