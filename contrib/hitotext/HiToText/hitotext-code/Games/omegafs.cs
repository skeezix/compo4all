using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
     class omegafs : omegaf
    {
        public omegafs()
        {
            // There is a bug in those games. The Hiscore shown on the top of the screen is
            // always rounded to nn000 (15000, 5000,...). I don't known if there is a bug in 
            // adress. In omegaf, 0x24fa we have a correct implementation, but in 0x2392 is wrong.
            // In omegafs, 0x2548 is ok, but 0x23ca is wrong.
            m_numEntries = 8;
            m_format = "RANK|SCORE|NAME";
            m_gamesSupported = "omegafs";
            m_extensionsRequired = ".hi";
        }

        public override byte[] GetEndBytes()
        {           
            return new byte[] {0x20,0x20};
        }   
    }
}