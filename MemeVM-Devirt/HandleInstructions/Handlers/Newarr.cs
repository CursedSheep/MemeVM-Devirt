using System;
using System.IO;
using MemeVM_Devirt.InitPhase;

namespace MemeVM.Runtime.Handlers {
    class Newarr : IHandler {
        public OpCode Handles => OpCode.Newarr;
        public Instruction Deserialize(BinaryReader reader) =>
            new Instruction(OpCode.Newarr, new Tuple<short, int>(reader.ReadInt16(), reader.ReadInt32()));
    }
}
