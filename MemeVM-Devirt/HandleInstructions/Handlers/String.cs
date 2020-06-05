using System.IO;
using System.Text;
using MemeVM_Devirt.InitPhase;

namespace MemeVM.Runtime.Handlers {
    class String : IHandler {
        public OpCode Handles => OpCode.String;

        public Instruction Deserialize(BinaryReader reader) {
            var len = reader.ReadInt32();

            return new Instruction(OpCode.String, Encoding.UTF8.GetString(reader.ReadBytes(len)));
        }
    }
}
