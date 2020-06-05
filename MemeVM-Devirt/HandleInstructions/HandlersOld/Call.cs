using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using MemeVM_Devirt.InitPhase;
using Instructiong = dnlib.DotNet.Emit.Instruction;
using Opcodes = dnlib.DotNet.Emit.OpCodes;

namespace MemeVM.Runtime.Handlerzs {
    //TODO: Generic methods
    class Call {
        public Instructiong Deserialized(Instruction reader)
        {
            try
            {
                var op = (Tuple<short, int, bool>)reader.Operand;
                if (!op.Item3)
                {
                    var asm = Initializebytes.GetBody(MemeVM_Devirt.InitPhase.Initializebytes.assembly).GetReference(op.Item1);
                    MemberInfo info;
                    try
                    {
                        info = asm.ManifestModule.ResolveMember(op.Item2);
                    }
                    catch
                    {
                        info = null;
                    }
                    var target = asm.ManifestModule.ResolveMethod(op.Item2);
                    if (info != null && (info.MemberType & MemberTypes.Constructor) == MemberTypes.Constructor)
                    {
                        var ctorinfo = (ConstructorInfo)info;
                        return new Instructiong(Opcodes.Callvirt, Initializebytes.Moduledefmd.Import(ctorinfo));
                    }
                    else return new Instructiong(Opcodes.Call, Initializebytes.Moduledefmd.Import(target));
                }
                else
                {
                    return new Instructiong(Opcodes.Newobj, Initializebytes.Moduledefmd.Import(typeof(object)));
                }
            }
            catch
            {
                return Opcodes.Nop.ToInstruction();
            }
        }
    }
}
