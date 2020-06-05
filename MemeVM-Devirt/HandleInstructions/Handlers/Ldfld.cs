using System;
using System.IO;
using MemeVM_Devirt.InitPhase;

namespace MemeVM.Runtime.Handlers {
    class Ldfld : IHandler {
        public OpCode Handles => OpCode.Ldfld;

        public Instruction Deserialize(BinaryReader reader) =>
            new Instruction(OpCode.Ldfld, new Tuple<short, int>(reader.ReadInt16(), reader.ReadInt32()));
    }
}
