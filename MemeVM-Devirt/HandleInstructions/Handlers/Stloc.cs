using System.IO;
using MemeVM_Devirt.InitPhase;

namespace MemeVM.Runtime.Handlers {
    class Stloc : IHandler {
        public OpCode Handles => OpCode.Stloc;

        public Instruction Deserialize(BinaryReader reader) =>
            new Instruction(OpCode.Stloc, reader.ReadInt16());
    }
}
