using MemeVM_Devirt.InitPhase;
using System.IO;
using System.Text;
using Instructiong = dnlib.DotNet.Emit.Instruction;
using Opcodes = dnlib.DotNet.Emit.OpCodes;
namespace MemeVM.Runtime.Handlerzs {
    class String {
        public Instructiong Deserialized(Instruction reader)
        {
            return new Instructiong(Opcodes.Ldstr, (string)reader.Operand);
        }
    }
}
