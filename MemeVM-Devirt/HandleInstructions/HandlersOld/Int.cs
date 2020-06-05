using MemeVM_Devirt.InitPhase;
using System.IO;
using Instructiong = dnlib.DotNet.Emit.Instruction;
using Opcodes = dnlib.DotNet.Emit.OpCodes;
namespace MemeVM.Runtime.Handlerzs {
    class Int {

        public Instructiong Deserialized(Instruction reader) => Instructiong.CreateLdcI4((int)reader.Operand);
    }
}
