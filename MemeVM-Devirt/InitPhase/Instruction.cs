using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeVM_Devirt.InitPhase
{
    internal struct Instruction
    {
        internal Instruction(OpCode code, object op = null)
        {
            this.Code = code;
            this.Operand = op;
        }

        internal OpCode Code;
        internal object Operand;
    }
}
