using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assets.Scripts
{
    public static partial class Global
    {
        public static byte[] malloc(uint size)
        {
            if (size <= 0)
            {
                return null;
            }

            byte[] allocatedMemory = new byte[size];
            return allocatedMemory;
        }
    }
}