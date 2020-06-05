using System.IO;
using MemeVM_Devirt.InitPhase;

namespace MemeVM.Runtime.Handlers {
    class Pop : IHandler {
        public OpCode Handles => OpCode.Pop;

        public Instruction Deserialize(BinaryReader reader) =>
            new Instruction(OpCode.Pop);
    }
}
