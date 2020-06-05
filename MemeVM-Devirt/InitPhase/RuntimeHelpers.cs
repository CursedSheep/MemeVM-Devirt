using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeVM_Devirt.InitPhase
{
    internal static class Map
    {
        static Map()
        {
            foreach (Type type in typeof(Map).Module.GetTypes())
            {
                if (!type.IsInterface && typeof(IHandler).IsAssignableFrom(type))
                {
                    IHandler handler = (IHandler)Activator.CreateInstance(type);
                    Map.OpCodeToHandler.Add(handler.Handles, handler);
                }
            }
        }

        internal static IHandler Lookup(OpCode code)
        {
            return Map.OpCodeToHandler[code];
        }

        private static readonly Dictionary<OpCode, IHandler> OpCodeToHandler = new Dictionary<OpCode, IHandler>();
    }
}
