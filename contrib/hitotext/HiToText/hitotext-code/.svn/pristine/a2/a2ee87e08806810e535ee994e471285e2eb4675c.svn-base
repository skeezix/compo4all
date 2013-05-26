using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class mkla1 : mk
    {
        public mkla1()
        {
            m_numEntries = 15;
            m_format = "RANK|SCORE|NAME|WINS";
            m_gamesSupported = "mkla1,mkla2,mkla3,mkla4,mkprot8,mkprot9,mkyawdim";
            m_extensionsRequired = ".nv";
        }

        public override int Offset_Scores()
        {
            return 0x6000;
        }

        public override int Offset_Checksum()
        {
            return 0x610e;
        }
    }
}