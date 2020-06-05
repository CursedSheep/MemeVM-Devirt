using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MemeVM_Devirt.InitPhase
{
    internal class TargetDisplOperand : IVmOperand
    {
        public TargetDisplOperand(int displacement)
        {
            this.Displacement = displacement;
        }

        public readonly int Displacement;
    }
    internal interface IVmOperand
    {
    }
    internal class Body
    {
        internal Body(Stream resourceStream)
        {
            this._references = new Dictionary<string, Assembly>();
            this._methods = new List<List<Instruction>>();
            using (DeflateStream deflateStream = new DeflateStream(resourceStream, CompressionMode.Decompress))
            {
                using (BinaryReader binaryReader = new BinaryReader(deflateStream))
                {
                    int num = binaryReader.ReadInt32();
                    for (int i = 0; i < num; i++)
                    {
                        int count = binaryReader.ReadInt32();
                        this._references.Add(Encoding.UTF8.GetString(binaryReader.ReadBytes(count)), null);
                    }
                    int num2 = binaryReader.ReadInt32();
                    for (int j = 0; j < num2; j++)
                    {
                        int num3 = binaryReader.ReadInt32();
                        List<Instruction> list = new List<Instruction>();
                        for (int k = 0; k < num3; k++)
                        {
                            OpCode code = (OpCode)binaryReader.ReadByte();
                            list.Add(Map.Lookup(code).Deserialize(binaryReader));
                        }
                        this._methods.Add(list);
                    }
                }
            }
        }

        internal Assembly CurrentAssembly { get; set; }
        internal Assembly GetReference(short index)
        {
            KeyValuePair<string, Assembly> keyValuePair = this._references.ElementAt((int)index);
            if (keyValuePair.Value == null)
            {
                var chk = doanyexist(keyValuePair.Key);
                if (chk.Item1 == true)
                {
                    this._references[keyValuePair.Key] = chk.Item2;
                }
                else
                {
                    try
                    {
                        this._references[keyValuePair.Key] = AppDomain.CurrentDomain.Load(new AssemblyName(keyValuePair.Key));
                    }
                    catch
                    {
                        this._references[keyValuePair.Key] = Initializebytes.assembly;
                    }
                }
            }
            return this._references[keyValuePair.Key];
        }
        public Tuple<bool, Assembly> doanyexist(string str)
        {
            var gh = this._references;
            foreach (var g in gh)
            {
                if (g.Key.Equals(str)) Tuple.Create(true, g.Value);
            }
            return Tuple.Create(false, CurrentAssembly);
        }
        internal List<Instruction> GetMethod(int index)
        {
            return this._methods[index];
        }
        private readonly Dictionary<string, Assembly> _references;

        private readonly List<List<Instruction>> _methods;
    }
    class Initializebytes
    {
        public static ModuleDefMD Moduledefmd;
        public static System.Reflection.Assembly assembly;
        public static Assembly GetReference(short index)
        {
            KeyValuePair<string, Assembly> keyValuePair = _references.ElementAt((int)index);
            if (keyValuePair.Value == null)
            {
                _references[keyValuePair.Key] = AppDomain.CurrentDomain.Load(new AssemblyName(keyValuePair.Key));
            }
            return _references[keyValuePair.Key];
        }
        public static Dictionary<string, Assembly> _references;
        public static void ConvertToDnBody(CilBody g,Body b, int i)
        {
            foreach(Instruction k in b.GetMethod(i))
            {
                switch (k.Code)
                {
                    case OpCode.Add:
                        g.Instructions.Add(new MemeVM.Runtime.Handlerzs.Add().Deserialized(k));
                        break;
                    case OpCode.Call:
                        g.Instructions.Add(new MemeVM.Runtime.Handlerzs.Call().Deserialized(k));
                        break;
                    case OpCode.Cgt:
                        g.Instructions.Add(new MemeVM.Runtime.Handlerzs.Cgt().Deserialized(k));
                        break;
                    case OpCode.Clt:
                        g.Instructions.Add(new MemeVM.Runtime.Handlerzs.Clt().Deserialized(k));
                        break;
                    case OpCode.Cmp:
                        g.Instructions.Add(new MemeVM.Runtime.Handlerzs.Cmp().Deserialized(k));
                        break;
                    case OpCode.Dup:
                        g.Instructions.Add(new MemeVM.Runtime.Handlerzs.Dup().Deserialized(k));
                        break;
                    case OpCode.Int32:
                        g.Instructions.Add(new MemeVM.Runtime.Handlerzs.Int().Deserialized(k));
                        break;
                    case OpCode.Jf:
                        g.Instructions.Add(new MemeVM.Runtime.Handlerzs.Jf().Deserialized(k));
                        break;
                    case OpCode.Jmp:
                        g.Instructions.Add(new MemeVM.Runtime.Handlerzs.Jmp().Deserialized(k));
                        break;
                    case OpCode.Jt:
                        g.Instructions.Add(new MemeVM.Runtime.Handlerzs.Jt().Deserialized(k));
                        break;
                    case OpCode.Ldarg:
                        g.Instructions.Add(new MemeVM.Runtime.Handlerzs.Ldarg().Deserialized(k));
                        break;
                    case OpCode.Ldfld:
                        g.Instructions.Add(new MemeVM.Runtime.Handlerzs.Ldfld().Deserialized(k));
                        break;
                    case OpCode.Ldloc:
                        g.Instructions.Add(new MemeVM.Runtime.Handlerzs.Ldloc().Deserialized(k));
                        break;
                    case OpCode.Int64:
                        g.Instructions.Add(new MemeVM.Runtime.Handlerzs.Long().Deserialized(k));
                        break;
                    case OpCode.Newarr:
                        g.Instructions.Add(new MemeVM.Runtime.Handlerzs.Newarr().Deserialized(k));
                        break;
                    case OpCode.Null:
                        g.Instructions.Add(new MemeVM.Runtime.Handlerzs.Null().Deserialized(k));
                        break;
                    case OpCode.Pop:
                        g.Instructions.Add(new MemeVM.Runtime.Handlerzs.Pop().Deserialized(k));
                        break;
                    case OpCode.Ret:
                        g.Instructions.Add(new MemeVM.Runtime.Handlerzs.Ret().Deserialized(k));
                        break;
                    case OpCode.Stfld:
                        g.Instructions.Add(new MemeVM.Runtime.Handlerzs.Stfld().Deserialized(k));
                        break;
                    case OpCode.Stloc:
                        var stl = new MemeVM.Runtime.Handlerzs.Stloc().Deserialized(k);
                        g.Instructions.Add(stl);
                        Local lcl = new Local(Moduledefmd.Import(stl.OpCode.GetType()).ToTypeSig());
                        g.Variables.Locals.Add(lcl);
                        break;
                    case OpCode.String:
                        g.Instructions.Add(new MemeVM.Runtime.Handlerzs.String().Deserialized(k));
                        break;

                }
            }
        }
        private static CilBody ToCil(MethodDef method, Body body, int index)
        {
            CilBody nm = new dnlib.DotNet.Emit.CilBody();
            IList<Local> localVariables = method.Body.Variables.Locals;
            foreach (var localVariableInfo in localVariables)
            {
                nm.Variables.Locals.Add(localVariableInfo);
            }
            ConvertToDnBody(nm, body, index);
            foreach (dnlib.DotNet.Emit.Instruction lmao in nm.Instructions)
            {
                if (lmao.GetOperand() is TargetDisplOperand)
                {
                    var t = (TargetDisplOperand)lmao.Operand;
                    if(t.Displacement > 0) lmao.Operand = nm.Instructions[t.Displacement];
                }
            }
            return nm;
        }
        public static readonly Dictionary<Assembly, Body> Bodies = new Dictionary<Assembly, Body>();
        public static CilBody DecryptMethod(MethodDef method, Assembly asm, int index)
        {
            Body body = GetBody(asm);
            body.CurrentAssembly = asm;
            return ToCil(method, body, index);
        }
        internal static Body GetBody(Assembly asm)
        {
            var lel = (EmbeddedResource)Initializebytes.Moduledefmd.Resources.Find(" ");
            Stream s = lel.CreateReader().AsStream();
            if (!Bodies.ContainsKey(asm))
            {
                Bodies.Add(asm, new Body(s));
            }
            return Bodies[asm];
        }
    }
}
