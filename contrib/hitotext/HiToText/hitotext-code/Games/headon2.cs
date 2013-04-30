using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{    
    class headon2 : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Score1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Score2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Score3;
        }

        public headon2()
        {
            m_numEntries = 3;
            m_format = "RANK|SCORE";
            m_gamesSupported = "headon2,car2";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                    sb.Append((char)(int)data[i]);
            }

            return sb.ToString();
        }

        public byte[] StringToByteArray(string str, int maxLength)
        {
            byte[] data = new byte[maxLength];
            if (str.Length > maxLength)
                str = str.Substring(0, maxLength);
            else str = str.PadLeft(maxLength, '0'); // if str.lenght<max complete to max with 0x24, like the game

            
            for (int i = 0; i < str.Length; i++)
            {
                    data[i] = (byte)((int)str[i]);
            }

            return data;
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            string score = args[1];

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = NumEntries;
            if (Convert.ToInt32(score) > Convert.ToInt32(ByteArrayToString(hiscoreData.Score1)))
                rank = 0;
            else if (Convert.ToInt32(score) > Convert.ToInt32(ByteArrayToString(hiscoreData.Score2)))
                rank = 1;
            else if (Convert.ToInt32(score) > Convert.ToInt32(ByteArrayToString(hiscoreData.Score3)))
                rank = 2;
            #endregion

            #region ADJUST
            int adjust = NumEntries - 1;
            if (rank < NumEntries - 1)
                adjust = NumEntries - 2;
            switch (adjust)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, hiscoreData.Score1);
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
                    if (rank < 1)
                        goto case 0;
                    break;
             }
            #endregion

            #region REPLACE_NEW
            switch (rank)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, StringToByteArray(score, hiscoreData.Score1.Length));
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, StringToByteArray(score, hiscoreData.Score2.Length));
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, StringToByteArray(score, hiscoreData.Score3.Length));
                    break;
            }
            #endregion

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.Score1, StringToByteArray("00000", hiscoreData.Score1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score2, StringToByteArray("00000", hiscoreData.Score2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score3, StringToByteArray("00000", hiscoreData.Score3.Length));
 
            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}|{1}", 1, ByteArrayToString(hiscoreData.Score1)) + Environment.NewLine;
            retString += String.Format("{0}|{1}", 2, ByteArrayToString(hiscoreData.Score2)) + Environment.NewLine;
            retString += String.Format("{0}|{1}", 3, ByteArrayToString(hiscoreData.Score3)) + Environment.NewLine;

            return retString;
        }
    }
}