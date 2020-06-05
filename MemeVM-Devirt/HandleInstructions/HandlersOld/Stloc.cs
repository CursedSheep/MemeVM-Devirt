using MemeVM_Devirt.InitPhase;
using System;
using System.IO;
using Instructiong = dnlib.DotNet.Emit.Instruction;
using Opcodes = dnlib.DotNet.Emit.OpCodes;
namespace MemeVM.Runtime.Handlerzs {
    class Stloc {

        public Instructiong Deserialized(Instruction reader) => new Instructiong(Opcodes.Stloc, (Int16)reader.Operand);
    }
}
