using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class rpatrol : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Name1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Score1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Name2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Score2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Name3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Score3;
        }

        public rpatrol()
        {
            m_numEntries = 3;
            m_format = "RANK|SCORE|NAME";
            m_gamesSupported = "rpatrol,rpatrolb,silvland,rpatrolo";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] >= 0x0a && data[i] <= 0x23)
                    sb.Append(((char)((((int)data[i])) + 65 - 0x0a)));
                else if (data[i] == 0x26)
                    sb.Append('.');
                else if (data[i] == 0x24)
                    sb.Append(' '); // don't kow which is better: space or nothing
            }

            return sb.ToString();
        }

        public byte[] StringToByteArray(string str, int maxLength)
        {
            byte[] data = new byte[maxLength];
            if (str.Length > maxLength)
                str = str.Substring(0, maxLength);
            else str = str.PadRight(maxLength, (char)0x24); // if str.lenght<max complete to max with 0x24, like the game

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 'A' && str[i] <= 'Z')
                    data[i] = (byte)(((int)str[i] - 65 + 0x0a));
                else if (str[i] == '.')
                    data[i] = 0x26;
                else if (str[i] == (char)0x24)
                    data[i] = 0x24;                              
            }
            return data;
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2].ToUpper();

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = NumEntries;
            if (score > HiConvert.ByteArraySingleBCDToInt(hiscoreData.Score1))
                rank = 0;
            else if (score > HiConvert.ByteArraySingleBCDToInt(hiscoreData.Score2))
                rank = 1;
            else if (score > HiConvert.ByteArraySingleBCDToInt(hiscoreData.Score3))
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
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, hiscoreData.Name1);
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
                    if (rank < 1)
                        goto case 0;
                    break;
             }
            #endregion

            #region REPLACE_NEW
            switch (rank)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Name1, StringToByteArray(name, hiscoreData.Name1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.IntToByteArraySingleBCD(score, hiscoreData.Score1.Length));
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name, hiscoreData.Name2.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.IntToByteArraySingleBCD(score, hiscoreData.Score2.Length));
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name, hiscoreData.Name3.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.IntToByteArraySingleBCD(score, hiscoreData.Score3.Length));
                    break;               
            }
            #endregion

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.IntToByteArraySingleBCD(0, hiscoreData.Score1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.IntToByteArraySingleBCD(0, hiscoreData.Score2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.IntToByteArraySingleBCD(0, hiscoreData.Score3.Length));
           
            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}|{1}|{2}", 1, HiConvert.ByteArraySingleBCDToInt(hiscoreData.Score1), ByteArrayToString(hiscoreData.Name1)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 2, HiConvert.ByteArraySingleBCDToInt(hiscoreData.Score2), ByteArrayToString(hiscoreData.Name2)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 3, HiConvert.ByteArraySingleBCDToInt(hiscoreData.Score3), ByteArrayToString(hiscoreData.Name3)) + Environment.NewLine;

            return retString;
        }
    }
}