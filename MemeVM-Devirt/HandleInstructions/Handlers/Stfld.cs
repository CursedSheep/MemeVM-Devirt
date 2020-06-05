using System;
using System.IO;
using MemeVM_Devirt.InitPhase;

namespace MemeVM.Runtime.Handlers {
    class Stfld : IHandler {
        public OpCode Handles => OpCode.Stfld;

        public Instruction Deserialize(BinaryReader reader) =>
            new Instruction(OpCode.Stfld, new Tuple<short, int>(reader.ReadInt16(), reader.ReadInt32()));
    }
}
