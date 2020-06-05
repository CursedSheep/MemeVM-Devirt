using System.IO;
using MemeVM_Devirt.InitPhase;

namespace MemeVM.Runtime.Handlers {
    class Ldarg : IHandler {
        public OpCode Handles => OpCode.Ldarg;

        public Instruction Deserialize(BinaryReader reader) =>
            new Instruction(OpCode.Ldarg, reader.ReadInt16());
    }
}
