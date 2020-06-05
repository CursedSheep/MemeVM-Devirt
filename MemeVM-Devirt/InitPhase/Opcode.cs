using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeVM_Devirt.InitPhase
{
    internal enum OpCode : byte
    {
        // Token: 0x04000008 RID: 8
        Int32,
        // Token: 0x04000009 RID: 9
        Int64,
        // Token: 0x0400000A RID: 10
        Float,
        // Token: 0x0400000B RID: 11
        Double,
        // Token: 0x0400000C RID: 12
        String,
        // Token: 0x0400000D RID: 13
        Null,
        // Token: 0x0400000E RID: 14
        Add,
        // Token: 0x0400000F RID: 15
        Sub,
        // Token: 0x04000010 RID: 16
        Mul,
        // Token: 0x04000011 RID: 17
        Div,
        // Token: 0x04000012 RID: 18
        Rem,
        // Token: 0x04000013 RID: 19
        Dup,
        // Token: 0x04000014 RID: 20
        Pop,
        // Token: 0x04000015 RID: 21
        Jmp,
        // Token: 0x04000016 RID: 22
        Jt,
        // Token: 0x04000017 RID: 23
        Jf,
        // Token: 0x04000018 RID: 24
        Je,
        // Token: 0x04000019 RID: 25
        Jne,
        // Token: 0x0400001A RID: 26
        Jge,
        // Token: 0x0400001B RID: 27
        Jgt,
        // Token: 0x0400001C RID: 28
        Jle,
        // Token: 0x0400001D RID: 29
        Jlt,
        // Token: 0x0400001E RID: 30
        Cmp,
        // Token: 0x0400001F RID: 31
        Cgt,
        // Token: 0x04000020 RID: 32
        Clt,
        // Token: 0x04000021 RID: 33
        Newarr,
        // Token: 0x04000022 RID: 34
        Ldarg,
        // Token: 0x04000023 RID: 35
        Ldloc,
        // Token: 0x04000024 RID: 36
        Ldfld,
        // Token: 0x04000025 RID: 37
        Ldelem,
        // Token: 0x04000026 RID: 38
        Starg,
        // Token: 0x04000027 RID: 39
        Stloc,
        // Token: 0x04000028 RID: 40
        Stfld,
        // Token: 0x04000029 RID: 41
        Stelem,
        // Token: 0x0400002A RID: 42
        Call,
        // Token: 0x0400002B RID: 43
        Ret
    }
}
