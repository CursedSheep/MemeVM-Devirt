using System;
using System.IO;
using System.Linq;
using System.Reflection;
using MemeVM_Devirt.InitPhase;

namespace MemeVM.Runtime.Handlers {
    //TODO: Generic methods
    class Call : IHandler {
        public OpCode Handles => OpCode.Call;

        public Instruction Deserialize(BinaryReader reader) =>
            new Instruction(OpCode.Call, new Tuple<short, int, bool>(reader.ReadInt16(), reader.ReadInt32(), reader.ReadBoolean()));
    }
}
