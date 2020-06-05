using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using dnlib;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnlib.DotNet.Writer;
using MemeVM_Devirt.InitPhase;

namespace MemeVM_Devirt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "MemeVM Devirtualizer by CursedSheep ;D";
            Console.ForegroundColor = ConsoleColor.Green;
            string filename;
            try
            {
                filename = args[0];
            }
            catch
            {
                Console.Write("Enter file path: ");
                filename = Console.ReadLine().Replace(@"""", "");
            }
            ModuleDefMD module = ModuleDefMD.Load(filename);
            MemeVM_Devirt.InitPhase.Initializebytes.Moduledefmd = module;
            System.Reflection.Assembly asm = System.Reflection.Assembly.LoadFrom(filename);
            MemeVM_Devirt.InitPhase.Initializebytes.assembly = asm;
            DeobFuscateMethods(MemeVM_Devirt.InitPhase.Initializebytes.Moduledefmd);
            ModuleWriterOptions opt = new ModuleWriterOptions(MemeVM_Devirt.InitPhase.Initializebytes.Moduledefmd);
            opt.MetadataOptions.Flags = MetadataFlags.PreserveAll | MetadataFlags.KeepOldMaxStack | MetadataFlags.PreserveExtraSignatureData | MetadataFlags.PreserveAllMethodRids | MetadataFlags.PreserveMemberRefRids | MetadataFlags.PreserveMethodSpecRids;
            opt.MetadataLogger = DummyLogger.NoThrowInstance;
            string patho = Path.GetDirectoryName(filename) + "\\" + Path.GetFileNameWithoutExtension(filename) + "-test" + Path.GetExtension(filename);
            MemeVM_Devirt.InitPhase.Initializebytes.Moduledefmd.Write(patho, opt);
            Console.WriteLine("saved to " + patho);
            Console.ReadKey();
        }
        public static void DeobFuscateMethods(ModuleDefMD module)
        {
            int counter = 0;
            Type[] asm2 = InitPhase.Initializebytes.assembly.ManifestModule.GetTypes();
            foreach (TypeDef type in module.GetTypes())
            {
                foreach (MethodDef method in type.Methods)
                {
                    if (!method.HasBody) continue;
                    if (!method.Body.HasInstructions) continue;
                    var instructions = method.Body.Instructions;
                    for (int i = 0; i < instructions.Count; i++)
                    {
                        if (instructions[i].OpCode == OpCodes.Ldtoken && instructions[i + 1].IsLdcI4() && (instructions[instructions.Count -3].OpCode == OpCodes.Call || instructions[instructions.Count - 2].OpCode == OpCodes.Call))
                        {
                            TypeDef param1 = (TypeDef)instructions[i].Operand;
                            RuntimeTypeHandle t = asm2.First(x => x.Name == param1.ReflectionName).TypeHandle;
                            int param2 = instructions[i + 1].GetLdcI4Value();
                            CilBody dm = MemeVM_Devirt.InitPhase.Initializebytes.DecryptMethod(method, Type.GetTypeFromHandle(t).Assembly, param2);
                            method.Body = dm;
                            counter++;
                        }
                    }
                }
            }
            Console.WriteLine("Bodies Replaced: " + counter);
        }
    }
}
