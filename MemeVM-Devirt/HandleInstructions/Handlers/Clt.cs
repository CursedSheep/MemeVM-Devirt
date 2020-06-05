using System.IO;
using MemeVM_Devirt.InitPhase;
namespace MemeVM.Runtime.Handlers {
    class Clt : IHandler {
        public OpCode Handles => OpCode.Clt;

        public Instruction Deserialize(BinaryReader reader) =>
            new Instruction(OpCode.Clt);
    }
}
