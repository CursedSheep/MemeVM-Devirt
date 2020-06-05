using System.IO;
using MemeVM_Devirt.InitPhase;

namespace MemeVM.Runtime.Handlers {
    class Long : IHandler {
        public OpCode Handles => OpCode.Int64;

        public Instruction Deserialize(BinaryReader reader) =>
            new Instruction(OpCode.Int64, reader.ReadInt64());
    }
}
