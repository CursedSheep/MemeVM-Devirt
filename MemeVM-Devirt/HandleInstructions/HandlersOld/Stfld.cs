using MemeVM_Devirt.InitPhase;
using System;
using System.IO;
using Instructiong = dnlib.DotNet.Emit.Instruction;
using Opcodes = dnlib.DotNet.Emit.OpCodes;
namespace MemeVM.Runtime.Handlerzs {
    class Stfld {
        public Instructiong Deserialized(Instruction reader)
        {
            var id = ((Tuple<short, int>)reader.Operand).Item1;
            var token = ((Tuple<short, int>)reader.Operand).Item2;

            var asm = Initializebytes.GetBody(MemeVM_Devirt.InitPhase.Initializebytes.assembly).GetReference(id);
            var field = asm.ManifestModule.ResolveField(token);
            return new Instructiong(Opcodes.Stfld, Initializebytes.Moduledefmd.Import(field));
        }
    }
}
