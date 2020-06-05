using System.IO;
using MemeVM_Devirt.InitPhase;
using Instructiong = dnlib.DotNet.Emit.Instruction;
using Opcodes = dnlib.DotNet.Emit.OpCodes;

namespace MemeVM.Runtime.Handlerzs {
    class Add {

        public Instructiong Deserialized(Instruction ins) => new dnlib.DotNet.Emit.Instruction(Opcodes.Add);
    }
}
