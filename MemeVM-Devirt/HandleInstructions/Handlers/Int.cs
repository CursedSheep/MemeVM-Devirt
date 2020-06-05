using System.IO;
using MemeVM_Devirt.InitPhase;

namespace MemeVM.Runtime.Handlers {
    class Int : IHandler {
        public OpCode Handles => OpCode.Int32;
        public Instruction Deserialize(BinaryReader reader) =>
            new Instruction(OpCode.Int32, reader.ReadInt32());
    }
}
