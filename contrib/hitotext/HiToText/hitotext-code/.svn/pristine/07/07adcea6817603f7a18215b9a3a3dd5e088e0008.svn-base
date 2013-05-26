using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class olibochu : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] HiScore;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] HiScoreOnScreen;

            public byte NumberOfCoinsInserted;
        }

        public olibochu()
        {
            // MAX. SCORE = 999,990
            m_numEntries = 1;
            m_format = "SCORE";
            m_gamesSupported = "olibochu";
            m_extensionsRequired = ".hi";
        }
        
        public byte[] ScoreOnScreenToByteArrayHex(int score, int maxLength)
        {
            byte[] data = new byte[maxLength];
            score = score * 10;
            string valstr = score.ToString().PadLeft(maxLength, (char)0x60);

            for (int i = 0; i < maxLength; i++)
            {
                if (valstr[i] >= '0' && valstr[i] <= '9')
                    data[i] = (byte)(valstr[i] - 0x30);
                else data[i] = (byte)valstr[i];
            }

            return data;
        }

        public override void SetHiScore(string[] args)
        {
            int score = System.Convert.ToInt32(args[0].PadLeft(6,'0').Substring(0,6)) / 10;
                       
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = NumEntries;
            if (score > HiConvert.ByteArraySingleBCDToInt(hiscoreData.HiScore))
                rank = 0;          
            #endregion

            #region REPLACE_NEW
            switch (rank)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.HiScore, HiConvert.IntToByteArraySingleBCD(score, hiscoreData.HiScore.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.HiScoreOnScreen, ScoreOnScreenToByteArrayHex(score, hiscoreData.HiScoreOnScreen.Length));
                    // If a coin has never insterted (0x00), "insert" one (0x01) to save hiscore correctly.
                    if (hiscoreData.NumberOfCoinsInserted == 0x00) hiscoreData.NumberOfCoinsInserted++;
                    break;      
            }
            #endregion

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.HiScore, HiConvert.IntToByteArraySingleBCD(0, hiscoreData.HiScore.Length));
            HiConvert.ByteArrayCopy(hiscoreData.HiScoreOnScreen, ScoreOnScreenToByteArrayHex(0, hiscoreData.HiScoreOnScreen.Length));

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}", HiConvert.ByteArraySingleBCDToInt(hiscoreData.HiScore) * 10) + Environment.NewLine;

            return retString;
        }
    }
}