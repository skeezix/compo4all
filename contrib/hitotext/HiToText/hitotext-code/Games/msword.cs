using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class msword : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name1;
            public byte FirstBlank1;
            public byte Floor1;
            public byte Partner1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] SecondBlank1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name2;
            public byte FirstBlank2;
            public byte Floor2;
            public byte Partner2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] SecondBlank2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name3;
            public byte FirstBlank3;
            public byte Floor3;
            public byte Partner3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] SecondBlank3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name4;
            public byte FirstBlank4;
            public byte Floor4;
            public byte Partner4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] SecondBlank4;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name5;
            public byte FirstBlank5;
            public byte Floor5;
            public byte Partner5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] SecondBlank5;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name6;
            public byte FirstBlank6;
            public byte Floor6;
            public byte Partner6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] SecondBlank6;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name7;
            public byte FirstBlank7;
            public byte Floor7;
            public byte Partner7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] SecondBlank7;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name8;
            public byte FirstBlank8;
            public byte Floor8;
            public byte Partner8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] SecondBlank8;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name9;
            public byte FirstBlank9;
            public byte Floor9;
            public byte Partner9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] SecondBlank9;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name10;
            public byte FirstBlank10;
            public byte Floor10;
            public byte Partner10;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] HiScore;
        }

        public msword()
        {
            m_numEntries = 10;
            m_format = "RANK|SCORE|NAME|FLOOR|PARTNER";
            m_gamesSupported = "msword,mswordu,mswordj,mswordr1";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] >= 0x00 && data[i] <= 0x32)
                    sb.Append(((char)((((int)data[i]) / 2) + 65)));
                if (data[i] >= 0x34 && data[i] <= 0x46)
                    sb.Append(((((int)data[i]) / 2) - 0x1a).ToString());
                else if (data[i] == 0x48)
                    sb.Append(',');
                else if (data[i] == 0x4e)
                    sb.Append(' ');
                else if (data[i] == 0x4c)
                    sb.Append('&');
                else if (data[i] == 0x4a)
                    sb.Append('?');
            }

            return sb.ToString();
        }

        public byte[] StringToByteArray(string str)
        {
            byte[] data = new byte[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                int tmp = (int)str[i];
                if (str[i] >= 'A' && str[i] <= 'Z')
                    data[i] = (byte)(((int)str[i] - 65) * 2);
                else if (str[i] == '0')
                    data[i] = 0x34;
                else if (str[i] == '1')
                    data[i] = 0x36;
                else if (str[i] == '2')
                    data[i] = 0x38;
                else if (str[i] == '3')
                    data[i] = 0x3a;
                else if (str[i] == '4')
                    data[i] = 0x3c;
                else if (str[i] == '5')
                    data[i] = 0x3e;
                else if (str[i] == '6')
                    data[i] = 0x40;
                else if (str[i] == '7')
                    data[i] = 0x42;
                else if (str[i] == '8')
                    data[i] = 0x44;
                else if (str[i] == '9')
                    data[i] = 0x46;
                else if (str[i] == ',')
                    data[i] = 0x48;
                else if (str[i] == '&')
                    data[i] = 0x4c;
                else if (str[i] == ' ')
                    data[i] = 0x4e;
                else if (str[i] == '?')
                    data[i] = 0x4a;
            }

            return data;
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2];
            int floor = System.Convert.ToInt32(args[3]);
            int partner = System.Convert.ToInt32(args[4]);

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = 10;
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
            int adjust = 9;
            if (rank < 9)
                adjust = 8;
            switch (adjust)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, hiscoreData.Score1);
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, hiscoreData.Name1);
                    hiscoreData.Partner2 = hiscoreData.Partner1;
                    hiscoreData.Floor2 = hiscoreData.Floor1;
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
                    hiscoreData.Partner3 = hiscoreData.Partner2;
                    hiscoreData.Floor3 = hiscoreData.Floor2;
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, hiscoreData.Score3);
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, hiscoreData.Name3);
                    hiscoreData.Partner4 = hiscoreData.Partner3;
                    hiscoreData.Floor4 = hiscoreData.Floor3;
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, hiscoreData.Score4);
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, hiscoreData.Name4);
                    hiscoreData.Partner5 = hiscoreData.Partner4;
                    hiscoreData.Floor5 = hiscoreData.Floor4;
                    if (rank < 3)
                        goto case 2;
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, hiscoreData.Score5);
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, hiscoreData.Name5);
                    hiscoreData.Partner6 = hiscoreData.Partner5;
                    hiscoreData.Floor6 = hiscoreData.Floor5;
                    if (rank < 4)
                        goto case 3;
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, hiscoreData.Score6);
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, hiscoreData.Name6);
                    hiscoreData.Partner7 = hiscoreData.Partner6;
                    hiscoreData.Floor7 = hiscoreData.Floor6;
                    if (rank < 5)
                        goto case 4;
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, hiscoreData.Score7);
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, hiscoreData.Name7);
                    hiscoreData.Partner8 = hiscoreData.Partner7;
                    hiscoreData.Floor8 = hiscoreData.Floor7;
                    if (rank < 6)
                        goto case 5;
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, hiscoreData.Score8);
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, hiscoreData.Name8);
                    hiscoreData.Partner9 = hiscoreData.Partner8;
                    hiscoreData.Floor9 = hiscoreData.Floor8;
                    if (rank < 7)
                        goto case 6;
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, hiscoreData.Score9);
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, hiscoreData.Name9);
                    hiscoreData.Partner10 = hiscoreData.Partner9;
                    hiscoreData.Floor10 = hiscoreData.Floor9;
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
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.IntToByteArrayHex(score, hiscoreData.Score1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.HiScore, HiConvert.IntToByteArrayHex(score, hiscoreData.HiScore.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name1, StringToByteArray(name));
                    hiscoreData.Partner1 = (byte)partner;
                    hiscoreData.Floor1 = (byte)floor;
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.IntToByteArrayHex(score, hiscoreData.Score2.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name));
                    hiscoreData.Partner2 = (byte)partner;
                    hiscoreData.Floor2 = (byte)floor;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.IntToByteArrayHex(score, hiscoreData.Score3.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name));
                    hiscoreData.Partner3 = (byte)partner;
                    hiscoreData.Floor3 = (byte)floor;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.IntToByteArrayHex(score, hiscoreData.Score4.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name));
                    hiscoreData.Partner4 = (byte)partner;
                    hiscoreData.Floor4 = (byte)floor;
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.IntToByteArrayHex(score, hiscoreData.Score5.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name));
                    hiscoreData.Partner5 = (byte)partner;
                    hiscoreData.Floor5 = (byte)floor;
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, HiConvert.IntToByteArrayHex(score, hiscoreData.Score6.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, StringToByteArray(name));
                    hiscoreData.Partner6 = (byte)partner;
                    hiscoreData.Floor6 = (byte)floor;
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, HiConvert.IntToByteArrayHex(score, hiscoreData.Score7.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, StringToByteArray(name));
                    hiscoreData.Partner7 = (byte)partner;
                    hiscoreData.Floor7 = (byte)floor;
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, HiConvert.IntToByteArrayHex(score, hiscoreData.Score8.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, StringToByteArray(name));
                    hiscoreData.Partner8 = (byte)partner;
                    hiscoreData.Floor8 = (byte)floor;
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, HiConvert.IntToByteArrayHex(score, hiscoreData.Score9.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, StringToByteArray(name));
                    hiscoreData.Partner9 = (byte)partner;
                    hiscoreData.Floor9 = (byte)floor;
                    break;
                case 9:
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, HiConvert.IntToByteArrayHex(score, hiscoreData.Score10.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, StringToByteArray(name));
                    hiscoreData.Partner10 = (byte)partner;
                    hiscoreData.Floor10 = (byte)floor;
                    break;
                default:
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

        //TODO: Determine what partner is what value.
        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 1, HiConvert.ByteArrayHexToInt(hiscoreData.Score1), ByteArrayToString(hiscoreData.Name1), hiscoreData.Floor1, hiscoreData.Partner1) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 2, HiConvert.ByteArrayHexToInt(hiscoreData.Score2), ByteArrayToString(hiscoreData.Name2), hiscoreData.Floor2, hiscoreData.Partner2) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 3, HiConvert.ByteArrayHexToInt(hiscoreData.Score3), ByteArrayToString(hiscoreData.Name3), hiscoreData.Floor3, hiscoreData.Partner3) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 4, HiConvert.ByteArrayHexToInt(hiscoreData.Score4), ByteArrayToString(hiscoreData.Name4), hiscoreData.Floor4, hiscoreData.Partner4) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 5, HiConvert.ByteArrayHexToInt(hiscoreData.Score5), ByteArrayToString(hiscoreData.Name5), hiscoreData.Floor5, hiscoreData.Partner5) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 6, HiConvert.ByteArrayHexToInt(hiscoreData.Score6), ByteArrayToString(hiscoreData.Name6), hiscoreData.Floor6, hiscoreData.Partner6) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 7, HiConvert.ByteArrayHexToInt(hiscoreData.Score7), ByteArrayToString(hiscoreData.Name7), hiscoreData.Floor7, hiscoreData.Partner7) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 8, HiConvert.ByteArrayHexToInt(hiscoreData.Score8), ByteArrayToString(hiscoreData.Name8), hiscoreData.Floor8, hiscoreData.Partner8) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 9, HiConvert.ByteArrayHexToInt(hiscoreData.Score9), ByteArrayToString(hiscoreData.Name9), hiscoreData.Floor9, hiscoreData.Partner9) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 10, HiConvert.ByteArrayHexToInt(hiscoreData.Score10), ByteArrayToString(hiscoreData.Name10), hiscoreData.Floor10, hiscoreData.Partner10) + Environment.NewLine;

            return retString;
        }
    }
}

