using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class nmouse : woodpeck
    {
        public nmouse()
        {
            // MAX. SCORE = 999,999
            m_numEntries = 1;
            m_format = "SCORE";
            m_gamesSupported = "nmouse,nmouseb";
            m_extensionsRequired = ".hi";
        }

        public override byte[] StringToByteArray(string str, int maxLength)
        {
            byte[] data = new byte[maxLength];

            for (int i = 0; i < maxLength; i++)
            {
                if (i < str.Length)
                    data[i] = (byte)(str[str.Length - 1 - i] - 0x30); // 0x30 is '0'
                else
                    data[i] = 0x40;
            }
            return data;
        }
    }

}
