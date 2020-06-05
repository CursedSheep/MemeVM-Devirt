using System;
using System.IO;
using MemeVM_Devirt.InitPhase;
using Instructiong = dnlib.DotNet.Emit.Instruction;
using Opcodes = dnlib.DotNet.Emit.OpCodes;
namespace MemeVM.Runtime.Handlerzs {
    class Ldloc{

        public Instructiong Deserialized(Instruction reader) => new Instructiong(Opcodes.Ldloc, (Int16)reader.Operand);
    }
}
