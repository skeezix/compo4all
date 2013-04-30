using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class barrier : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScorePart1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScorePart2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name;    
        }

        public barrier()
        {
            // Max. score: 99,999
            m_numEntries = 1;
            m_format = "SCORE|NAME";
            m_gamesSupported = "barrier";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 1; i < data.Length; i+=2)
            {
                if (data[i] >= 0x00 && data[i] <= 0x19)
                    sb.Append((char)(((int)data[i]) + 65));                
            }

            return sb.ToString();
        }

        public byte[] StringToByteArray(string str, int maxLength)
        {
            byte[] data = new byte[maxLength];

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 'A' && str[i] <= 'Z')
                {
                    data[(2 * i)] = 0x00;
                    data[(2 * i) + 1] = (byte)(((int)str[i] - 65));
                }
            }

            return data;
        }

        public override void SetHiScore(string[] args)
        {
            int score1 = System.Convert.ToInt32(args[0].PadLeft(5, '0').Substring(0, 2));
            int score2 = System.Convert.ToInt32(args[0].PadLeft(5, '0').Substring(2, 3));
            string name = args[1].PadRight(3, 'A').ToUpper();

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = NumEntries;
            if (score1 *1000 + score2 > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScorePart1) * 1000 + HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScorePart2))
                rank = 0;
            #endregion

            #region REPLACE_NEW
            switch (rank)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Name, StringToByteArray(name, hiscoreData.Name.Length));
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

            retString += String.Format("{0}|{1}", HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScorePart1) * 1000 + HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScorePart2), ByteArrayToString(hiscoreData.Name)) + Environment.NewLine;

            return retString;
        }
    }
}