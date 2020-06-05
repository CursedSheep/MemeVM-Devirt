using MemeVM_Devirt.InitPhase;
using System;
using System.IO;
using Instructiong = dnlib.DotNet.Emit.Instruction;
using Opcodes = dnlib.DotNet.Emit.OpCodes;
namespace MemeVM.Runtime.Handlerzs {
    class Newarr {
        public Instructiong Deserialized(Instruction reader)
        {
            var tuple = (Tuple<short, int>)reader.Operand;

            var refid = tuple.Item1;
            var token = tuple.Item2;

            var asm = Initializebytes.GetBody(MemeVM_Devirt.InitPhase.Initializebytes.assembly).GetReference(refid).ManifestModule;
            var type = asm.ResolveType(token);
            return new Instructiong(Opcodes.Newarr, Initializebytes.Moduledefmd.Import(type));
        }
    }
}
