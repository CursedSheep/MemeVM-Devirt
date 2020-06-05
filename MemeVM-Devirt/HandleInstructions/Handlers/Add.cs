using System.IO;
using MemeVM_Devirt.InitPhase;

namespace MemeVM.Runtime.Handlers {
    class Add : IHandler {
        public OpCode Handles => OpCode.Add;

        public Instruction Deserialize(BinaryReader reader) => 
            new Instruction(OpCode.Add);
    }
}
