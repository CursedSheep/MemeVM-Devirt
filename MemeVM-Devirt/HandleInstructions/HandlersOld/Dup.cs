﻿using MemeVM_Devirt.InitPhase;
using System.IO;
using Instructiong = dnlib.DotNet.Emit.Instruction;
using Opcodes = dnlib.DotNet.Emit.OpCodes;
namespace MemeVM.Runtime.Handlerzs {
    class Dup {
        public Instructiong Deserialized(Instruction reader) => new Instructiong(Opcodes.Dup);
    }
}
