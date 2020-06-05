using System.IO;
using MemeVM_Devirt.InitPhase;
using Instructiong = dnlib.DotNet.Emit.Instruction;
using Opcodes = dnlib.DotNet.Emit.OpCodes;
namespace MemeVM.Runtime.Handlerzs {
    class Jt{

        public Instructiong Deserialized(Instruction reader)
        {
            TargetDisplOperand t = new TargetDisplOperand((int)reader.Operand);
            return new Instructiong(Opcodes.Brtrue, t);
        }
    }
}
