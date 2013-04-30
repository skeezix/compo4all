using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class qb3 : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            public byte Dummy;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score1Part2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score1Part1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score2Part2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score2Part1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score3Part2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score3Part1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score4Part2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score4Part1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score5Part2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score5Part1;
        }

        public qb3()
        {
            // Max.Score = xxxx
            m_numEntries = 5;
            m_format = "RANK|SCORE|NAME";
            m_gamesSupported = "qb3";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 1; i < data.Length; i += 2)
            {
                if (data[i] >= 0x00 && data[i] <= 0x19)
                    sb.Append((char)(((int)data[i]) + 65));
                else if (data[i] == 0x1a)
                    sb.Append(' ');
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
                    data[2 * i] = 0x00;
                    data[(2 * i) + 1] = (byte)(((int)str[i] - 65));
                }
                else if (str[i] == ' ')
                {
                    data[2 * i] = 0x00;
                    data[(2 * i) + 1] = 0x1a;
                }
            }

            return data;
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score1 = System.Convert.ToInt32(args[1].PadLeft(8, '0').Substring(0, 4));
            int score2 = System.Convert.ToInt32(args[1].PadLeft(8, '0').Substring(4, 3));
            string name = args[2].ToUpper().PadRight(3, ' '); 

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = NumEntries;
            if (score1 * 1000 + score2 > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score1Part1) * 1000 + HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score1Part2))
                rank = 0;
            else if (score1 * 1000 + score2 > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score2Part1) * 1000 + HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score2Part2))
                rank = 1;
            else if (score1 * 1000 + score2 > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score3Part1) * 1000 + HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score3Part2))
                rank = 2;
            else if (score1 * 1000 + score2 > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score4Part1) * 1000 + HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score4Part2))
                rank = 3;
            else if (score1 * 1000 + score2 > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score5Part1) * 1000 + HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score5Part2))
                rank = 4;
            #endregion

            #region ADJUST
            int adjust = NumEntries - 1;
            if (rank < NumEntries - 1)
                adjust = NumEntries - 2;
            switch (adjust)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Score2Part1, hiscoreData.Score1Part1);
                    HiConvert.ByteArrayCopy(hiscoreData.Score2Part2, hiscoreData.Score1Part2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, hiscoreData.Name1);
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3Part1, hiscoreData.Score2Part1);
                    HiConvert.ByteArrayCopy(hiscoreData.Score3Part2, hiscoreData.Score2Part2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4Part1, hiscoreData.Score3Part1);
                    HiConvert.ByteArrayCopy(hiscoreData.Score4Part2, hiscoreData.Score3Part2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, hiscoreData.Name3);
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5Part1, hiscoreData.Score4Part1);
                    HiConvert.ByteArrayCopy(hiscoreData.Score5Part2, hiscoreData.Score4Part2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, hiscoreData.Name4);
                    if (rank < 3)
                        goto case 2;
                    break;
            }
            #endregion

            #region REPLACE_NEW
            switch (rank)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Name1, StringToByteArray(name, hiscoreData.Name1.Length));
                    hiscoreData.Dummy = hiscoreData.Name1[1];
                    HiConvert.ByteArrayCopy(hiscoreData.Score1Part1, HiConvert.IntToByteArrayHexAsHex(score1, hiscoreData.Score1Part1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score1Part2, HiConvert.IntToByteArrayHexAsHex(score2, hiscoreData.Score1Part2.Length));
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name, hiscoreData.Name2.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score2Part1, HiConvert.IntToByteArrayHexAsHex(score1, hiscoreData.Score2Part1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score2Part2, HiConvert.IntToByteArrayHexAsHex(score2, hiscoreData.Score2Part2.Length));
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name, hiscoreData.Name3.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score3Part1, HiConvert.IntToByteArrayHexAsHex(score1, hiscoreData.Score3Part1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score3Part2, HiConvert.IntToByteArrayHexAsHex(score2, hiscoreData.Score3Part2.Length));
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name, hiscoreData.Name4.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score4Part1, HiConvert.IntToByteArrayHexAsHex(score1, hiscoreData.Score4Part1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score4Part2, HiConvert.IntToByteArrayHexAsHex(score2, hiscoreData.Score4Part2.Length));
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name, hiscoreData.Name5.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score5Part1, HiConvert.IntToByteArrayHexAsHex(score1, hiscoreData.Score5Part1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score5Part2, HiConvert.IntToByteArrayHexAsHex(score2, hiscoreData.Score5Part2.Length));
                    break;
            }
            #endregion

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.Score1Part1, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score1Part1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score1Part2, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score1Part2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score2Part1, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score2Part1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score2Part2, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score2Part2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score3Part1, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score3Part1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score3Part2, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score3Part2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score4Part1, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score4Part1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score4Part2, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score4Part2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score5Part1, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score5Part1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score5Part2, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score5Part2.Length));
 
            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}|{1}|{2}", 1, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score1Part1) * 10000 + HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score1Part2) * 10, ByteArrayToString(hiscoreData.Name1)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 2, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score2Part1) * 10000 + HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score2Part2) * 10, ByteArrayToString(hiscoreData.Name2)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 3, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score3Part1) * 10000 + HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score3Part2) * 10, ByteArrayToString(hiscoreData.Name3)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 4, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score4Part1) * 10000 + HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score4Part2) * 10, ByteArrayToString(hiscoreData.Name4)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 5, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score5Part1) * 10000 + HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score5Part2) * 10, ByteArrayToString(hiscoreData.Name5)) + Environment.NewLine;
      
            return retString;
        }
    }
}