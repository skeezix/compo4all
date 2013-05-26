using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class gyruss : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            public byte Rank1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name1;
            public byte Unused1;

            public byte Rank2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name2;
            public byte Unused2;

            public byte Rank3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name3;
            public byte Unused3;

            public byte Rank4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name4;
            public byte Unused4;

            public byte Rank5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name5;
            public byte Unused5;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] HiScore;
        }

        public gyruss()
        {
            m_numEntries = 5;
            m_format = "RANK|SCORE|NAME";
            m_gamesSupported = "gyruss,gyrussce";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == 0x34 || data[i] == 0xee)
                    sb.Append('A');
                else if (data[i] == 0xe7)
                    sb.Append('B');
                else if (data[i] == 0x03)
                    sb.Append('C');
                else if (data[i] == 0xc4 || data[i] == 0xdc)
                    sb.Append('D');
                else if (data[i] == 0xff || data[i] == 0x0f)
                    sb.Append('E');
                else if (data[i] == 0x25)
                    sb.Append('F');
                else if (data[i] == 0xc2)
                    sb.Append('G');
                else if (data[i] == 0x87)
                    sb.Append('H');
                else if (data[i] == 0x88 || data[i] == 0x48)
                    sb.Append('I');
                else if (data[i] == 0x40)
                    sb.Append('J');
                else if (data[i] == 0x51 || data[i] == 0xd7)
                    sb.Append('K');
                else if (data[i] == 0xe8)
                    sb.Append('L');
                else if (data[i] == 0xa5 || data[i] == 0x3a)
                    sb.Append('M');
                else if (data[i] == 0x29 || data[i] == 0x47)
                    sb.Append('N');
                else if (data[i] == 0xb2 || data[i] == 0xb1)
                    sb.Append('O');
                else if (data[i] == 0x6a)
                    sb.Append('P');
                else if (data[i] == 0xc6)
                    sb.Append('Q');
                else if (data[i] == 0xbf || data[i] == 0x6d)
                    sb.Append('R');
                else if (data[i] == 0xc1)
                    sb.Append('S');
                else if (data[i] == 0xfc || data[i] == 0x39)
                    sb.Append('T');
                else if (data[i] == 0xc3 || data[i] == 0xf5)
                    sb.Append('U');
                else if (data[i] == 0xf1)
                    sb.Append('V');
                else if (data[i] == 0xb4)
                    sb.Append('W');
                else if (data[i] == 0x0d)
                    sb.Append('X');
                else if (data[i] == 0xb0 || data[i] == 0xa7)
                    sb.Append('Y');
                else if (data[i] == 0x0b)
                    sb.Append('Z');
                else if (data[i] == 0xf8 || data[i] == 0xd3)
                    sb.Append('.');
            }

            return sb.ToString();
        }

        public byte[] StringToByteArray(string str)
        {
            byte[] data = new byte[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'A')
                    data[i] = 0x34;
                else if (str[i] == 'B')
                    data[i] = 0xe7;
                else if (str[i] == 'C')
                    data[i] = 0x03;
                else if (str[i] == 'D')
                    data[i] = 0xc4;
                else if (str[i] == 'E')
                    data[i] = 0xff;
                else if (str[i] == 'F')
                    data[i] = 0x25;
                else if (str[i] == 'G')
                    data[i] = 0xc2;
                else if (str[i] == 'H')
                    data[i] = 0x87;
                else if (str[i] == 'I')
                    data[i] = 0x88;
                else if (str[i] == 'J')
                    data[i] = 0x40;
                else if (str[i] == 'K')
                    data[i] = 0x51;
                else if (str[i] == 'L')
                    data[i] = 0xe8;
                else if (str[i] == 'M')
                    data[i] = 0xa5;
                else if (str[i] == 'N')
                    data[i] = 0x29;
                else if (str[i] == 'O')
                    data[i] = 0xb2;
                else if (str[i] == 'P')
                    data[i] = 0x6a;
                else if (str[i] == 'Q')
                    data[i] = 0xc6;
                else if (str[i] == 'R')
                    data[i] = 0xbf;
                else if (str[i] == 'S')
                    data[i] = 0xc1;
                else if (str[i] == 'T')
                    data[i] = 0xfc;
                else if (str[i] == 'U')
                    data[i] = 0xc3;
                else if (str[i] == 'V')
                    data[i] = 0xf1;
                else if (str[i] == 'W')
                    data[i] = 0xb4;
                else if (str[i] == 'X')
                    data[i] = 0x0d;
                else if (str[i] == 'Y')
                    data[i] = 0xb0;
                else if (str[i] == 'Z')
                    data[i] = 0x0b;
                else if (str[i] == '.')
                    data[i] = 0xf8;
            }

            return data;
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2];

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
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, hiscoreData.Score3);
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, hiscoreData.Name3);
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, hiscoreData.Score4);
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
                    HiConvert.ByteArrayCopy(hiscoreData.Name1, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score1.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.HiScore, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.HiScore.Length)));
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score2.Length)));
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score3.Length)));
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score4.Length)));
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score5.Length)));
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

            retString += String.Format("{0}|{1}|{2}", 1, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score1)), ByteArrayToString(hiscoreData.Name1)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 2, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score2)), ByteArrayToString(hiscoreData.Name2)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 3, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score3)), ByteArrayToString(hiscoreData.Name3)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 4, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score4)), ByteArrayToString(hiscoreData.Name4)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 5, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score5)), ByteArrayToString(hiscoreData.Name5)) + Environment.NewLine;

            return retString;
        }
    }
}