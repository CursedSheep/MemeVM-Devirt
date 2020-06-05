using System;
using System.IO;
using MemeVM_Devirt.InitPhase;
using Instructiong = dnlib.DotNet.Emit.Instruction;
using Opcodes = dnlib.DotNet.Emit.OpCodes;
namespace MemeVM.Runtime.Handlerzs {
    class Long  {

        public Instructiong Deserialized(Instruction reader) => new Instructiong(Opcodes.Ldc_I8, (Int64)reader.Operand);
    }
}
