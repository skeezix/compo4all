using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class pacmania : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score1;
            public byte Round1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score2;
            public byte Round2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score3;
            public byte Round3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score4;
            public byte Round4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name4;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score5;
            public byte Round5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name5;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score6;
            public byte Round6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name6;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score7;
            public byte Round7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name7;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score8;
            public byte Round8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name8;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score9;
            public byte Round9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name9;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score10;
            public byte Round10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name10;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] HiScore;
        }

        public pacmania()
        {
            m_numEntries = 10;
            m_format = "RANK|SCORE|NAME|ROUND";
            m_gamesSupported = "pacmania";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] >= 0x41 && data[i] <= 0x5a)
                    sb.Append((char)(int)data[i]);
                else if (data[i] == 0x20)
                    sb.Append(' ');
                else if (data[i] == 0x21)
                    sb.Append('!');
                else if (data[i] == 0x26)
                    sb.Append('&');
                else if (data[i] == 0x27)
                    sb.Append('\'');
                else if (data[i] == 0x2c)
                    sb.Append(',');
                else if (data[i] == 0x2e)
                    sb.Append('.');
            }

            return sb.ToString();
        }

        public byte[] StringToByteArray(string str)
        {
            byte[] data = new byte[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 'A' && str[i] <= 'Z')
                    data[i] = (byte)((int)str[i]);
                else if (str[i] == ' ')
                    data[i] = 0x20;
                else if (str[i] == '!')
                    data[i] = 0x21;
                else if (str[i] == '&')
                    data[i] = 0x26;
                else if (str[i] == '\'')
                    data[i] = 0x27;
                else if (str[i] == ',')
                    data[i] = 0x2c;
                else if (str[i] == '.')
                    data[i] = 0x2e;
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
            if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score1))
                rank = 0;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score2))
                rank = 1;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score3))
                rank = 2;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score4))
                rank = 3;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score5))
                rank = 4;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score6))
                rank = 5;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score7))
                rank = 6;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score8))
                rank = 7;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score9))
                rank = 8;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score10))
                rank = 9;
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
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, hiscoreData.Score5);
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, hiscoreData.Name5);
                    hiscoreData.Round6 = hiscoreData.Round5;
                    if (rank < 4)
                        goto case 3;
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, hiscoreData.Score6);
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, hiscoreData.Name6);
                    hiscoreData.Round7 = hiscoreData.Round6;
                    if (rank < 5)
                        goto case 4;
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, hiscoreData.Score7);
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, hiscoreData.Name7);
                    hiscoreData.Round8 = hiscoreData.Round7;
                    if (rank < 6)
                        goto case 5;
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, hiscoreData.Score8);
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, hiscoreData.Name8);
                    hiscoreData.Round9 = hiscoreData.Round8;
                    if (rank < 7)
                        goto case 6;
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, hiscoreData.Score9);
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, hiscoreData.Name9);
                    hiscoreData.Round10 = hiscoreData.Round9;
                    if (rank < 8)
                        goto case 7;
                    break;
                default:
                    break;
            }
            #endregion

            #region REPLACE_NEW
            switch (rank)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Name1, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.IntToByteArrayHex(score, hiscoreData.Score1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.HiScore, HiConvert.IntToByteArrayHex(score, hiscoreData.HiScore.Length));
                    hiscoreData.Round1 = (byte)round;
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.IntToByteArrayHex(score, hiscoreData.Score2.Length));
                    hiscoreData.Round2 = (byte)round;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.IntToByteArrayHex(score, hiscoreData.Score3.Length));
                    hiscoreData.Round3 = (byte)round;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.IntToByteArrayHex(score, hiscoreData.Score4.Length));
                    hiscoreData.Round4 = (byte)round;
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.IntToByteArrayHex(score, hiscoreData.Score5.Length));
                    hiscoreData.Round5 = (byte)round;
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, HiConvert.IntToByteArrayHex(score, hiscoreData.Score6.Length));
                    hiscoreData.Round6 = (byte)round;
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, HiConvert.IntToByteArrayHex(score, hiscoreData.Score7.Length));
                    hiscoreData.Round7 = (byte)round;
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, HiConvert.IntToByteArrayHex(score, hiscoreData.Score8.Length));
                    hiscoreData.Round8 = (byte)round;
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, HiConvert.IntToByteArrayHex(score, hiscoreData.Score9.Length));
                    hiscoreData.Round9 = (byte)round;
                    break;
                case 9:
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, HiConvert.IntToByteArrayHex(score, hiscoreData.Score10.Length));
                    hiscoreData.Round10 = (byte)round;
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
            HiConvert.ByteArrayCopy(hiscoreData.Score6, HiConvert.IntToByteArrayHex(0, hiscoreData.Score6.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score7, HiConvert.IntToByteArrayHex(0, hiscoreData.Score7.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score8, HiConvert.IntToByteArrayHex(0, hiscoreData.Score8.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score9, HiConvert.IntToByteArrayHex(0, hiscoreData.Score9.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score10, HiConvert.IntToByteArrayHex(0, hiscoreData.Score10.Length));

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}|{1}|{2}|{3}", 1, HiConvert.ByteArrayHexToInt(hiscoreData.Score1) * 10, ByteArrayToString(hiscoreData.Name1), hiscoreData.Round1) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 2, HiConvert.ByteArrayHexToInt(hiscoreData.Score2) * 10, ByteArrayToString(hiscoreData.Name2), hiscoreData.Round2) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 3, HiConvert.ByteArrayHexToInt(hiscoreData.Score3) * 10, ByteArrayToString(hiscoreData.Name3), hiscoreData.Round3) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 4, HiConvert.ByteArrayHexToInt(hiscoreData.Score4) * 10, ByteArrayToString(hiscoreData.Name4), hiscoreData.Round4) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 5, HiConvert.ByteArrayHexToInt(hiscoreData.Score5) * 10, ByteArrayToString(hiscoreData.Name5), hiscoreData.Round5) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 6, HiConvert.ByteArrayHexToInt(hiscoreData.Score6) * 10, ByteArrayToString(hiscoreData.Name6), hiscoreData.Round6) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 7, HiConvert.ByteArrayHexToInt(hiscoreData.Score7) * 10, ByteArrayToString(hiscoreData.Name7), hiscoreData.Round7) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 8, HiConvert.ByteArrayHexToInt(hiscoreData.Score8) * 10, ByteArrayToString(hiscoreData.Name8), hiscoreData.Round8) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 9, HiConvert.ByteArrayHexToInt(hiscoreData.Score9) * 10, ByteArrayToString(hiscoreData.Name9), hiscoreData.Round9) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 10, HiConvert.ByteArrayHexToInt(hiscoreData.Score10) * 10, ByteArrayToString(hiscoreData.Name10), hiscoreData.Round10) + Environment.NewLine;

            return retString;
        }
    }
}

