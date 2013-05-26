using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class sundance : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Dummy;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] HiScore;
        }

        public sundance()
        {
            // Max. score: 1,999
            m_numEntries = 1;
            m_format = "SCORE";
            m_gamesSupported = "sundance";
            m_extensionsRequired = ".hi";
        }
         
        public override void SetHiScore(string[] args)
        {
            int score = System.Convert.ToInt32(args[0].PadLeft(4, '0').Substring(0, 4));

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = NumEntries;
            if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.HiScore))
                rank = 0;            
            #endregion

            #region REPLACE_NEW
            switch (rank)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.HiScore, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.HiScore.Length));
                    break;
            }
            #endregion

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.HiScore, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.HiScore.Length));
           
            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}", HiConvert.ByteArrayHexAsHexToInt(hiscoreData.HiScore)) + Environment.NewLine;

            return retString;
        }
    }
}