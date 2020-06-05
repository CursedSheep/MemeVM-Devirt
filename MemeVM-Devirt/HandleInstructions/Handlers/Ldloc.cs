using System.IO;
using MemeVM_Devirt.InitPhase;

namespace MemeVM.Runtime.Handlers {
    class Ldloc : IHandler {
        public OpCode Handles => OpCode.Ldloc;

        public Instruction Deserialize(BinaryReader reader) =>
            new Instruction(OpCode.Ldloc, reader.ReadInt16());
    }
}
