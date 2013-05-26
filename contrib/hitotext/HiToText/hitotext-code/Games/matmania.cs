using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class matmania : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score1;
            public byte Round1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Name1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score2;
            public byte Round2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Name2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score3;
            public byte Round3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Name3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score4;
            public byte Round4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Name4;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score5;
            public byte Round5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Unused5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Name5;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] HiScore;
        }

        public matmania()
        {
            m_numEntries = 5;
            m_format = "RANK|SCORE|NAME|ROUND";
            m_gamesSupported = "matmania,excthour";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] >= 0xbb && data[i] <= 0xd4)
                    sb.Append(((char)(((int)data[i]) + 65 - 0xbb)));
                else if (data[i] == 0xb0)
                    sb.Append(' ');
                else if (data[i] == 0xb1)
                    sb.Append('0');
                else if (data[i] == 0xb2)
                    sb.Append('1');
                else if (data[i] == 0xb3)
                    sb.Append('2');
                else if (data[i] == 0xb4)
                    sb.Append('3');
                else if (data[i] == 0xb5)
                    sb.Append('4');
                else if (data[i] == 0xb6)
                    sb.Append('5');
                else if (data[i] == 0xb7)
                    sb.Append('6');
                else if (data[i] == 0xb8)
                    sb.Append('7');
                else if (data[i] == 0xb9)
                    sb.Append('8');
                else if (data[i] == 0xba)
                    sb.Append('9');
                else if (data[i] == 0xd5)
                    sb.Append('©');
                else if (data[i] == 0xd6)
                    sb.Append('?');
                else if (data[i] == 0xd7)
                    sb.Append('!');
                else if (data[i] == 0xd8)
                    sb.Append('-');
                else if (data[i] == 0xd9)
                    sb.Append('.');
                else if (data[i] == 0xda)
                    sb.Append(',');
            }

            return sb.ToString();
        }

        public byte[] StringToByteArray(string str)
        {
            byte[] data = new byte[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 'A' && str[i] <= 'Z')
                    data[i] = (byte)((int)str[i] - 65 + 0xbb);
                else if (str[i] == ' ')
                    data[i] = 0xb0;
                else if (str[i] == '0')
                    data[i] = 0xb1;
                else if (str[i] == '1')
                    data[i] = 0xb2;
                else if (str[i] == '2')
                    data[i] = 0xb3;
                else if (str[i] == '3')
                    data[i] = 0xb4;
                else if (str[i] == '4')
                    data[i] = 0xb5;
                else if (str[i] == '5')
                    data[i] = 0xb6;
                else if (str[i] == '6')
                    data[i] = 0xb7;
                else if (str[i] == '7')
                    data[i] = 0xb8;
                else if (str[i] == '8')
                    data[i] = 0xb9;
                else if (str[i] == '9')
                    data[i] = 0xba;
                else if (str[i] == '©')
                    data[i] = 0xd5;
                else if (str[i] == '?')
                    data[i] = 0xd6;
                else if (str[i] == '!')
                    data[i] = 0xd7;
                else if (str[i] == '-')
                    data[i] = 0xd8;
                else if (str[i] == '.')
                    data[i] = 0xd9;
                else if (str[i] == ',')
                    data[i] = 0xda;
            }

            return data;
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]) / 10;
            string name = args[2];
            int round = System.Convert.ToInt32(args[3]);

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = NumEntries;
            if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score1)))
                rank = 0;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score2)))
                rank = 1;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score3)))
                rank = 2;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score4)))
                rank = 3;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score5)))
                rank = 4;
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
                    hiscoreData.Round2 = hiscoreData.Round1;
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
                    hiscoreData.Round3 = hiscoreData.Round2;
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, hiscoreData.Score3);
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, hiscoreData.Name3);
                    hiscoreData.Round4 = hiscoreData.Round3;
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, hiscoreData.Score4);
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, hiscoreData.Name4);
                    hiscoreData.Round5 = hiscoreData.Round4;
                    if (rank < 3)
                        goto case 2;
                    break;
            }
            #endregion

            #region REPLACE_NEW
            switch (rank)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Name1, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score1.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.HiScore, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.HiScore.Length)));
                    hiscoreData.Round1 = HiConvert.IntToByteArrayHex(round, 1)[0];
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score2.Length)));
                    hiscoreData.Round2 = HiConvert.IntToByteArrayHex(round, 1)[0];
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score3.Length)));
                    hiscoreData.Round3 = HiConvert.IntToByteArrayHex(round, 1)[0];
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score4.Length)));
                    hiscoreData.Round4 = HiConvert.IntToByteArrayHex(round, 1)[0];
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score5.Length)));
                    hiscoreData.Round5 = HiConvert.IntToByteArrayHex(round, 1)[0];
                    break;
            }
            #endregion

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.IntToByteArrayHex(0, hiscoreData.Score1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.IntToByteArrayHex(0, hiscoreData.Score2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.IntToByteArrayHex(0, hiscoreData.Score3.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.IntToByteArrayHex(0, hiscoreData.Score4.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.IntToByteArrayHex(0, hiscoreData.Score5.Length));

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}|{1}|{2}|{3}", 1, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score1)) * 10, ByteArrayToString(hiscoreData.Name1), Int32.Parse(hiscoreData.Round1.ToString("X2"))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 2, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score2)) * 10, ByteArrayToString(hiscoreData.Name2), Int32.Parse(hiscoreData.Round2.ToString("X2"))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 3, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score3)) * 10, ByteArrayToString(hiscoreData.Name3), Int32.Parse(hiscoreData.Round3.ToString("X2"))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 4, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score4)) * 10, ByteArrayToString(hiscoreData.Name4), Int32.Parse(hiscoreData.Round4.ToString("X2"))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 5, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score5)) * 10, ByteArrayToString(hiscoreData.Name5), Int32.Parse(hiscoreData.Round5.ToString("X2"))) + Environment.NewLine;

            return retString;
        }
    }
}