using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class woodpeck : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] HiScore;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] HiScoreText;
            public byte Checkbyte; // Use to tell hiscore.c when overwrite the data      
        }

        public woodpeck()
        {
            // MAX. SCORE = 999,999
            m_numEntries = 1;
            m_format = "SCORE";
            m_gamesSupported = "woodpeck,woodpeca";
            m_extensionsRequired = ".hi";
        }

        public virtual byte[] StringToByteArray(string str, int maxLength)
        {
            byte[] data = new byte[maxLength];

            for (int i = 0; i < maxLength; i++) 
            {
                if (i < str.Length)
                    data[i] = (byte)str[str.Length-1-i];
                else
                    data[i] = 0x40;
            }

            return data;
        }

        public override void SetHiScore(string[] args)
        {
            int score = System.Convert.ToInt32(args[0].PadLeft(6,'0').Substring(0,6));
           
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = NumEntries;
            if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.HiScore)))
                rank = 0;          
            #endregion

            #region REPLACE_NEW
            switch (rank)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.HiScore, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.HiScore.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.HiScoreText, StringToByteArray(score.ToString(), hiscoreData.HiScoreText.Length));
                    break;      
            }
            #endregion

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.HiScore, HiConvert.IntToByteArrayHex(0, hiscoreData.HiScore.Length));
          
            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}", HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.HiScore))) + Environment.NewLine;

            return retString;
        }
    }
}