using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class tapper : journey
    {
        public tapper()
        {
            m_numEntries = 10;
            m_format = "RANK|SCORE|NAME";
            m_gamesSupported = "tapper,tappera,rbtapper,sutapper";
            m_extensionsRequired = ".nv";
        }
         
    }
}