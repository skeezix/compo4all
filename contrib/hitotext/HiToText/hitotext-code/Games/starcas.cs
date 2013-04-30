using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class starcas : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScorePart1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScorePart2;
        }

        public starcas()
        {
            // Max. score: 9,999,990
            m_numEntries = 1;
            m_format = "SCORE";
            m_gamesSupported = "starcas,starcas1,starcasp,starcase,stellcas,spaceftr";
            m_extensionsRequired = ".hi";
        }
         
        public override void SetHiScore(string[] args)
        {
            int score1 = System.Convert.ToInt32(args[0].PadLeft(7, '0').Substring(0, 3));
            int score2 = System.Convert.ToInt32(args[0].PadLeft(7, '0').Substring(3, 3));

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = NumEntries;
            if (score1 *10000 + score2 * 10 > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScorePart1) * 10000 + HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScorePart2) * 10)
                rank = 0;            
            #endregion

            #region REPLACE_NEW
            switch (rank)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.ScorePart1, HiConvert.IntToByteArrayHexAsHex(score1, hiscoreData.ScorePart1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.ScorePart2, HiConvert.IntToByteArrayHexAsHex(score2, hiscoreData.ScorePart2.Length));
                    break;
            }
            #endregion

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.ScorePart1, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.ScorePart1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScorePart2, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.ScorePart2.Length));
           
            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}", HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScorePart1) * 10000 + HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScorePart2) * 10) + Environment.NewLine;

            return retString;
        }
    }
}