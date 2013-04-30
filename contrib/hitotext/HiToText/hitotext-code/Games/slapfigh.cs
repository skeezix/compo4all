using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class slapfigh : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] HiScore;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score10;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name10;

            public byte Area1;
            public byte Area2;
            public byte Area3;
            public byte Area4;
            public byte Area5;
            public byte Area6;
            public byte Area7;
            public byte Area8;
            public byte Area9;
            public byte Area10;
        }

        public slapfigh()
        {
            m_numEntries = 10;
            m_format = "RANK|SCORE|NAME|AREA";
            m_gamesSupported = "slapfigh,slapfgtr,slapbtuk,slapbtjp,slapfiga";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] >= 0x0a && data[i] <= 0x23)
                {
                    byte[] newdata = HiConvert.HexStringToByteArray((data[i] + 55).ToString("X2"));
                    sb.Append((char)(int)newdata[0]);
                }
                else if (data[i] == 0x24)
                    sb.Append('!');
                else if (data[i] == 0x25)
                    sb.Append(',');
                else if (data[i] == 0x26)
                    sb.Append('.');
                else if (data[i] == 0x27)
                    sb.Append('+');
                else if (data[i] == 0x28)
                    sb.Append('-');
                else if (data[i] == 0x29)
                    sb.Append('&');
                else if (data[i] == 0x2a)
                    sb.Append('?');
                else if (data[i] == 0x2d)
                    sb.Append(' ');
            }

            return sb.ToString();
        }

        public byte[] StringToByteArray(string str)
        {
            while (str.Length < 3)
            {
                str = str + " ";
            }
            byte[] data = new byte[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 'A' && str[i] <= 'Z')
                    data[i] = (byte)((int)str[i] - 55);
                else if (str[i] == '!')
                    data[i] = 0x24;
                else if (str[i] == ',')
                    data[i] = 0x25;
                else if (str[i] == '.')
                    data[i] = 0x26;
                else if (str[i] == '+')
                    data[i] = 0x27;
                else if (str[i] == '-')
                    data[i] = 0x28;
                else if (str[i] == '&')
                    data[i] = 0x29;
                else if (str[i] == '?')
                    data[i] = 0x2a;
                else if (str[i] == ' ')
                    data[i] = 0x2d;
            }

            return data;
        }

        public int ByteArrayToScore(byte[] byteData)
        {
            StringBuilder sb = new StringBuilder();
            if (byteData.Length < 3)
            {
                // invalid length, has to be 3
                return 0;
            }

            // Score = Low nibble 3rd byte + 2nd byte + 1st byte + high nibble 3rd byte           
            sb.Append((byteData[2] & 0x0f).ToString("X1"));
            sb.Append(byteData[1].ToString("X2"));
            sb.Append(byteData[0].ToString("X2"));
            sb.Append((byteData[2] >> 4 & 0x0f).ToString("X1"));
            return Int32.Parse(sb.ToString());
        }

        public byte[] ScoreToByteArray(int score)
        {
            StringBuilder sb = new StringBuilder();
            byte[] byteArray = HiConvert.IntToByteArrayHex(score, 3);

            sb.Append((byteArray[1] & 0x0f).ToString("X1"));
            sb.Append(((byteArray[2] >> 4) & 0x0f).ToString("X1"));

            sb.Append((byteArray[0] & 0x0f).ToString("X1"));
            sb.Append(((byteArray[1] >> 4) & 0x0f).ToString("X1"));

            sb.Append((byteArray[2] & 0x0f).ToString("X1"));
            sb.Append(((byteArray[0] >> 4) & 0x0f).ToString("X1"));
            return HiConvert.HexStringToByteArray(sb.ToString());
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = System.Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2];
            byte[] area = new byte[] { (byte)System.Convert.ToInt32(args[3]) };

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = 10;
            if (score > ByteArrayToScore(hiscoreData.Score1))
                rank = 0;
            else if (score > ByteArrayToScore(hiscoreData.Score2))
                rank = 1;
            else if (score > ByteArrayToScore(hiscoreData.Score3))
                rank = 2;
            else if (score > ByteArrayToScore(hiscoreData.Score4))
                rank = 3;
            else if (score > ByteArrayToScore(hiscoreData.Score5))
                rank = 4;
            else if (score > ByteArrayToScore(hiscoreData.Score6))
                rank = 5;
            else if (score > ByteArrayToScore(hiscoreData.Score7))
                rank = 6;
            else if (score > ByteArrayToScore(hiscoreData.Score8))
                rank = 7;
            else if (score > ByteArrayToScore(hiscoreData.Score9))
                rank = 8;
            else if (score > ByteArrayToScore(hiscoreData.Score10))
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
                    hiscoreData.Area2 = hiscoreData.Area1;
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
                    hiscoreData.Area3 = hiscoreData.Area2;
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, hiscoreData.Score3);
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, hiscoreData.Name3);
                    hiscoreData.Area4 = hiscoreData.Area3;
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, hiscoreData.Score4);
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, hiscoreData.Name4);
                    hiscoreData.Area5 = hiscoreData.Area4;
                    if (rank < 3)
                        goto case 2;
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, hiscoreData.Score5);
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, hiscoreData.Name5);
                    hiscoreData.Area6 = hiscoreData.Area5;
                    if (rank < 4)
                        goto case 3;
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, hiscoreData.Score6);
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, hiscoreData.Name6);
                    hiscoreData.Area7 = hiscoreData.Area6;
                    if (rank < 5)
                        goto case 4;
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, hiscoreData.Score7);
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, hiscoreData.Name7);
                    hiscoreData.Area8 = hiscoreData.Area7;
                    if (rank < 6)
                        goto case 5;
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, hiscoreData.Score8);
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, hiscoreData.Name8);
                    hiscoreData.Area9 = hiscoreData.Area8;
                    if (rank < 7)
                        goto case 6;
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, hiscoreData.Score9);
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, hiscoreData.Name9);
                    hiscoreData.Area10 = hiscoreData.Area9;
                    if (rank < 8)
                        goto case 7;
                    break;
                default:
                    break;
            }
            #endregion

            #region REPLACE NEW
            switch (rank)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Name1, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, ScoreToByteArray(score));
                    hiscoreData.Area1 = area[0];
                    HiConvert.ByteArrayCopy(hiscoreData.HiScore, ScoreToByteArray(score));
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, ScoreToByteArray(score));
                    hiscoreData.Area2 = area[0];
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, ScoreToByteArray(score));
                    hiscoreData.Area3 = area[0];
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, ScoreToByteArray(score));
                    hiscoreData.Area4 = area[0];
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, ScoreToByteArray(score));
                    hiscoreData.Area5 = area[0];
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, ScoreToByteArray(score));
                    hiscoreData.Area6 = area[0];
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, ScoreToByteArray(score));
                    hiscoreData.Area7 = area[0];
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, ScoreToByteArray(score));
                    hiscoreData.Area8 = area[0];
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, ScoreToByteArray(score));
                    hiscoreData.Area9 = area[0];
                    break;
                case 9:
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, ScoreToByteArray(score));
                    hiscoreData.Area10 = area[0];
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

            retString += String.Format("{0}|{1}|{2}|{3}", 1, ByteArrayToScore(hiscoreData.Score1), ByteArrayToString(hiscoreData.Name1), (int)hiscoreData.Area1) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 2, ByteArrayToScore(hiscoreData.Score2), ByteArrayToString(hiscoreData.Name2), (int)hiscoreData.Area2) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 3, ByteArrayToScore(hiscoreData.Score3), ByteArrayToString(hiscoreData.Name3), (int)hiscoreData.Area3) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 4, ByteArrayToScore(hiscoreData.Score4), ByteArrayToString(hiscoreData.Name4), (int)hiscoreData.Area4) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 5, ByteArrayToScore(hiscoreData.Score5), ByteArrayToString(hiscoreData.Name5), (int)hiscoreData.Area5) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 6, ByteArrayToScore(hiscoreData.Score6), ByteArrayToString(hiscoreData.Name6), (int)hiscoreData.Area6) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 7, ByteArrayToScore(hiscoreData.Score7), ByteArrayToString(hiscoreData.Name7), (int)hiscoreData.Area7) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 8, ByteArrayToScore(hiscoreData.Score8), ByteArrayToString(hiscoreData.Name8), (int)hiscoreData.Area8) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 9, ByteArrayToScore(hiscoreData.Score9), ByteArrayToString(hiscoreData.Name9), (int)hiscoreData.Area9) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 10, ByteArrayToScore(hiscoreData.Score10), ByteArrayToString(hiscoreData.Name10), (int)hiscoreData.Area10) + Environment.NewLine;

            return retString;
        }
    }
}