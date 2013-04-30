using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class toki : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score11;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score12;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score13;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score14;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score15;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score16;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score17;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score18;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score19;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score20;

            public byte UnusedA1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name1;
            public byte UnusedA2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name2;
            public byte UnusedA3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name3;
            public byte UnusedA4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name4;
            public byte UnusedA5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name5;
            public byte UnusedA6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name6;
            public byte UnusedA7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name7;
            public byte UnusedA8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name8;
            public byte UnusedA9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name9;
            public byte UnusedA10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name10;
            public byte UnusedA11;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name11;
            public byte UnusedA12;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name12;
            public byte UnusedA13;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name13;
            public byte UnusedA14;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name14;
            public byte UnusedA15;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name15;
            public byte UnusedA16;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name16;
            public byte UnusedA17;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name17;
            public byte UnusedA18;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name18;
            public byte UnusedA19;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name19;
            public byte UnusedA20;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name20;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Area1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Area2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Area3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Area4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Area5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Area6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Area7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Area8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Area9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Area10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Area11;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Area12;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Area13;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Area14;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Area15;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Area16;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Area17;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Area18;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Area19;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Area20;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] HiScore;
        }

        public toki()
        {
            m_numEntries = 20;
            m_format = "RANK|SCORE|NAME|AREA";
            m_gamesSupported = "toki,tokib,tokiu,tokia,juju,jujub";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == 0x00)
                    sb.Append(' ');
                else if (data[i] == 0x20)
                    sb.Append(' ');
                else if (data[i] == 0x5b)
                    sb.Append('['); //Selection is '!', however displays as '['
                else if (data[i] == 0x5c)
                    sb.Append('\\'); //Selection is '?', however displays as '\'
                else if (data[i] == 0x5d)
                    sb.Append(']'); //Selection is '&', however displays as ']'
                else
                    sb.Append((char)(int)data[i]);
            }

            return sb.ToString();
        }

        public byte[] StringToByteArray(string str)
        {
            byte[] data = new byte[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                    data[i] = 0x20;
                else if (str[i] == '[')
                    data[i] = 0x5b;
                else if (str[i] == '\\')
                    data[i] = 0x5c;
                else if (str[i] == ']')
                    data[i] = 0x5d;
                else
                    data[i] = (byte)((int)str.ToUpper()[i]);
            }

            return data;
        }

        public int GetArea(string area)
        {
            switch (area)
            { 
                case "1-A":
                    return 0;
                case "1-B":
                    return 1;
                case "1-C":
                    return 2;
                case "1-D":
                    return 3;
                case "1-E":
                    return 4;
                case "1-F":
                    return 5;
                case "1-G":
                    return 6;
                case "1-H":
                    return 7;
                case "1-I":
                    return 8;
                case "1-J":
                    return 9;
                case "2-A":
                    return 10;
                case "2-B":
                    return 11;
                case "2-C":
                    return 12;
                case "2-D":
                    return 13;
                case "2-E":
                    return 14;
                case "2-F":
                    return 15;
                case "2-G":
                    return 16;
                case "2-H":
                    return 17;
                case "3-A":
                    return 18;
                case "3-B":
                    return 19;
                case "3-C":
                    return 20;
                case "3-D":
                    return 21;
                case "3-E":
                    return 22;
                case "3-F":
                    return 23;
                case "3-G":
                    return 24;
                case "3-H":
                    return 25;
                case "3-I":
                    return 26;
                case "3-J":
                    return 27;
                case "3-K":
                    return 28;
                case "3-L":
                    return 29;
                case "3-M":
                    return 30;
                case "3-N":
                    return 31;
                case "3-O":
                    return 32;
                case "3-P":
                    return 33;
                case "3-Q":
                    return 34;
                case "4-A":
                    return 35;
                case "4-B":
                    return 36;
                case "4-C":
                    return 37;
                case "4-D":
                    return 38;
                case "4-E":
                    return 39;
                case "4-F":
                    return 40;
                case "4-G":
                    return 41;
                case "4-H":
                    return 42;
                case "4-I":
                    return 43;
                case "4-J":
                    return 44;
                case "4-K":
                    return 45;
                case "4-L":
                    return 46;
                case "5-A":
                    return 47;
                case "5-B":
                    return 48;
                case "5-C":
                    return 49;
                case "5-D":
                    return 50;
                case "5-E":
                    return 51;
                case "5-F":
                    return 52;
                case "5-G":
                    return 53;
                case "5-H":
                    return 54;
                case "5-I":
                    return 55;
                case "5-J":
                    return 56;
                case "5-K":
                    return 57;
                case "5-L":
                    return 58;
                case "5-M":
                    return 59;
                case "6-A":
                    return 60;
                case "6-B":
                    return 61;
                case "6-C":
                    return 62;
                case "6-D":
                    return 63;
                case "6-E":
                    return 64;
            }

            return 0;
        }

        public string GetArea(int area)
        {
            switch (area)
            {
                case 0:
                    return "1-A";
                case 1:
                    return "1-B";
                case 2:
                    return "1-C";
                case 3:
                    return "1-D";
                case 4:
                    return "1-E";
                case 5:
                    return "1-F";
                case 6:
                    return "1-G";
                case 7:
                    return "1-H";
                case 8:
                    return "1-I";
                case 9:
                    return "1-J";
                case 10:
                    return "2-A";
                case 11:
                    return "2-B";
                case 12:
                    return "2-C";
                case 13:
                    return "2-D";
                case 14:
                    return "2-E";
                case 15:
                    return "2-F";
                case 16:
                    return "2-G";
                case 17:
                    return "2-H";
                case 18:
                    return "3-A";
                case 19:
                    return "3-B";
                case 20:
                    return "3-C";
                case 21:
                    return "3-D";
                case 22:
                    return "3-E";
                case 23:
                    return "3-F";
                case 24:
                    return "3-G";
                case 25:
                    return "3-H";
                case 26:
                    return "3-I";
                case 27:
                    return "3-J";
                case 28:
                    return "3-K";
                case 29:
                    return "3-L";
                case 30:
                    return "3-M";
                case 31:
                    return "3-N";
                case 32:
                    return "3-O";
                case 33:
                    return "3-P";
                case 34:
                    return "3-Q";
                case 35:
                    return "4-A";
                case 36:
                    return "4-B";
                case 37:
                    return "4-C";
                case 38:
                    return "4-D";
                case 39:
                    return "4-E";
                case 40:
                    return "4-F";
                case 41:
                    return "4-G";
                case 42:
                    return "4-H";
                case 43:
                    return "4-I";
                case 44:
                    return "4-J";
                case 45:
                    return "4-K";
                case 46:
                    return "4-L";
                case 47:
                    return "5-A";
                case 48:
                    return "5-B";
                case 49:
                    return "5-C";
                case 50:
                    return "5-D";
                case 51:
                    return "5-E";
                case 52:
                    return "5-F";
                case 53:
                    return "5-G";
                case 54:
                    return "5-H";
                case 55:
                    return "5-I";
                case 56:
                    return "5-J";
                case 57:
                    return "5-K";
                case 58:
                    return "5-L";
                case 59:
                    return "5-M";
                case 60:
                    return "6-A";
                case 61:
                    return "6-B";
                case 62:
                    return "6-C";
                case 63:
                    return "6-D";
                case 64:
                    return "6-E";
            }
            return "1-A";
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2];
            int area = GetArea(args[3]);

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
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score11))
                rank = 10;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score12))
                rank = 11;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score13))
                rank = 12;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score14))
                rank = 13;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score15))
                rank = 14;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score16))
                rank = 15;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score17))
                rank = 16;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score18))
                rank = 17;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score19))
                rank = 18;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score20))
                rank = 19;
            #endregion

            #region ADJUST
            int adjust = NumEntries - 1;
            if (rank < NumEntries - 1)
                adjust = NumEntries - 2;
            switch (adjust)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, hiscoreData.Score1);
                    HiConvert.ByteArrayCopy(hiscoreData.Area2, hiscoreData.Area1);
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, hiscoreData.Name1);
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
                    HiConvert.ByteArrayCopy(hiscoreData.Area3, hiscoreData.Area2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, hiscoreData.Score3);
                    HiConvert.ByteArrayCopy(hiscoreData.Area4, hiscoreData.Area3);
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, hiscoreData.Name3);
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, hiscoreData.Score4);
                    HiConvert.ByteArrayCopy(hiscoreData.Area5, hiscoreData.Area4);
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, hiscoreData.Name4);
                    if (rank < 3)
                        goto case 2;
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, hiscoreData.Score5);
                    HiConvert.ByteArrayCopy(hiscoreData.Area6, hiscoreData.Area5);
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, hiscoreData.Name5);
                    if (rank < 4)
                        goto case 3;
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, hiscoreData.Score6);
                    HiConvert.ByteArrayCopy(hiscoreData.Area7, hiscoreData.Area6);
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, hiscoreData.Name6);
                    if (rank < 5)
                        goto case 4;
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, hiscoreData.Score7);
                    HiConvert.ByteArrayCopy(hiscoreData.Area8, hiscoreData.Area7);
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, hiscoreData.Name7);
                    if (rank < 6)
                        goto case 5;
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, hiscoreData.Score8);
                    HiConvert.ByteArrayCopy(hiscoreData.Area9, hiscoreData.Area8);
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, hiscoreData.Name8);
                    if (rank < 7)
                        goto case 6;
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, hiscoreData.Score9);
                    HiConvert.ByteArrayCopy(hiscoreData.Area10, hiscoreData.Area9);
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, hiscoreData.Name9);
                    if (rank < 8)
                        goto case 7;
                    break;
                case 9:
                    HiConvert.ByteArrayCopy(hiscoreData.Score11, hiscoreData.Score10);
                    HiConvert.ByteArrayCopy(hiscoreData.Area11, hiscoreData.Area10);
                    HiConvert.ByteArrayCopy(hiscoreData.Name11, hiscoreData.Name10);
                    if (rank < 9)
                        goto case 8;
                    break;
                case 10:
                    HiConvert.ByteArrayCopy(hiscoreData.Score12, hiscoreData.Score11);
                    HiConvert.ByteArrayCopy(hiscoreData.Area12, hiscoreData.Area11);
                    HiConvert.ByteArrayCopy(hiscoreData.Name12, hiscoreData.Name11);
                    if (rank < 10)
                        goto case 9;
                    break;
                case 11:
                    HiConvert.ByteArrayCopy(hiscoreData.Score13, hiscoreData.Score12);
                    HiConvert.ByteArrayCopy(hiscoreData.Area13, hiscoreData.Area12);
                    HiConvert.ByteArrayCopy(hiscoreData.Name13, hiscoreData.Name12);
                    if (rank < 11)
                        goto case 10;
                    break;
                case 12:
                    HiConvert.ByteArrayCopy(hiscoreData.Score14, hiscoreData.Score13);
                    HiConvert.ByteArrayCopy(hiscoreData.Area14, hiscoreData.Area13);
                    HiConvert.ByteArrayCopy(hiscoreData.Name14, hiscoreData.Name13);
                    if (rank < 12)
                        goto case 11;
                    break;
                case 13:
                    HiConvert.ByteArrayCopy(hiscoreData.Score15, hiscoreData.Score14);
                    HiConvert.ByteArrayCopy(hiscoreData.Area15, hiscoreData.Area14);
                    HiConvert.ByteArrayCopy(hiscoreData.Name15, hiscoreData.Name14);
                    if (rank < 13)
                        goto case 12;
                    break;
                case 14:
                    HiConvert.ByteArrayCopy(hiscoreData.Score16, hiscoreData.Score15);
                    HiConvert.ByteArrayCopy(hiscoreData.Area16, hiscoreData.Area15);
                    HiConvert.ByteArrayCopy(hiscoreData.Name16, hiscoreData.Name15);
                    if (rank < 14)
                        goto case 13;
                    break;
                case 15:
                    HiConvert.ByteArrayCopy(hiscoreData.Score17, hiscoreData.Score16);
                    HiConvert.ByteArrayCopy(hiscoreData.Area17, hiscoreData.Area16);
                    HiConvert.ByteArrayCopy(hiscoreData.Name17, hiscoreData.Name16);
                    if (rank < 15)
                        goto case 14;
                    break;
                case 16:
                    HiConvert.ByteArrayCopy(hiscoreData.Score18, hiscoreData.Score17);
                    HiConvert.ByteArrayCopy(hiscoreData.Area18, hiscoreData.Area17);
                    HiConvert.ByteArrayCopy(hiscoreData.Name18, hiscoreData.Name17);
                    if (rank < 16)
                        goto case 15;
                    break;
                case 17:
                    HiConvert.ByteArrayCopy(hiscoreData.Score19, hiscoreData.Score18);
                    HiConvert.ByteArrayCopy(hiscoreData.Area19, hiscoreData.Area18);
                    HiConvert.ByteArrayCopy(hiscoreData.Name19, hiscoreData.Name18);
                    if (rank < 17)
                        goto case 16;
                    break;
                case 18:
                    HiConvert.ByteArrayCopy(hiscoreData.Score20, hiscoreData.Score19);
                    HiConvert.ByteArrayCopy(hiscoreData.Area20, hiscoreData.Area19);
                    HiConvert.ByteArrayCopy(hiscoreData.Name20, hiscoreData.Name19);
                    if (rank < 18)
                        goto case 17;
                    break;
            }
            #endregion

            #region REPLACE_NEW
            switch (rank)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Name1, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.IntToByteArrayHex(score, hiscoreData.Score1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Area1, HiConvert.IntToByteArrayHexAsHex(area, hiscoreData.Area1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.HiScore, HiConvert.IntToByteArrayHex(score, hiscoreData.HiScore.Length));
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.IntToByteArrayHex(score, hiscoreData.Score2.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Area2, HiConvert.IntToByteArrayHexAsHex(area, hiscoreData.Area2.Length));
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.IntToByteArrayHex(score, hiscoreData.Score3.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Area3, HiConvert.IntToByteArrayHexAsHex(area, hiscoreData.Area3.Length));
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.IntToByteArrayHex(score, hiscoreData.Score4.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Area4, HiConvert.IntToByteArrayHexAsHex(area, hiscoreData.Area4.Length));
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.IntToByteArrayHex(score, hiscoreData.Score5.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Area5, HiConvert.IntToByteArrayHexAsHex(area, hiscoreData.Area5.Length));
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, HiConvert.IntToByteArrayHex(score, hiscoreData.Score6.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Area6, HiConvert.IntToByteArrayHexAsHex(area, hiscoreData.Area6.Length));
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, HiConvert.IntToByteArrayHex(score, hiscoreData.Score7.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Area7, HiConvert.IntToByteArrayHexAsHex(area, hiscoreData.Area7.Length));
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, HiConvert.IntToByteArrayHex(score, hiscoreData.Score8.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Area8, HiConvert.IntToByteArrayHexAsHex(area, hiscoreData.Area8.Length));
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, HiConvert.IntToByteArrayHex(score, hiscoreData.Score9.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Area9, HiConvert.IntToByteArrayHexAsHex(area, hiscoreData.Area9.Length));
                    break;
                case 9:
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, HiConvert.IntToByteArrayHex(score, hiscoreData.Score10.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Area10, HiConvert.IntToByteArrayHexAsHex(area, hiscoreData.Area10.Length));
                    break;
                case 10:
                    HiConvert.ByteArrayCopy(hiscoreData.Name11, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score11, HiConvert.IntToByteArrayHex(score, hiscoreData.Score11.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Area11, HiConvert.IntToByteArrayHexAsHex(area, hiscoreData.Area11.Length));
                    break;
                case 11:
                    HiConvert.ByteArrayCopy(hiscoreData.Name12, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score12, HiConvert.IntToByteArrayHex(score, hiscoreData.Score12.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Area12, HiConvert.IntToByteArrayHexAsHex(area, hiscoreData.Area12.Length));
                    break;
                case 12:
                    HiConvert.ByteArrayCopy(hiscoreData.Name13, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score13, HiConvert.IntToByteArrayHex(score, hiscoreData.Score13.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Area13, HiConvert.IntToByteArrayHexAsHex(area, hiscoreData.Area13.Length));
                    break;
                case 13:
                    HiConvert.ByteArrayCopy(hiscoreData.Name14, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score14, HiConvert.IntToByteArrayHex(score, hiscoreData.Score14.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Area14, HiConvert.IntToByteArrayHexAsHex(area, hiscoreData.Area14.Length));
                    break;
                case 14:
                    HiConvert.ByteArrayCopy(hiscoreData.Name15, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score15, HiConvert.IntToByteArrayHex(score, hiscoreData.Score15.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Area15, HiConvert.IntToByteArrayHexAsHex(area, hiscoreData.Area15.Length));
                    break;
                case 15:
                    HiConvert.ByteArrayCopy(hiscoreData.Name16, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score16, HiConvert.IntToByteArrayHex(score, hiscoreData.Score16.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Area16, HiConvert.IntToByteArrayHexAsHex(area, hiscoreData.Area16.Length));
                    break;
                case 16:
                    HiConvert.ByteArrayCopy(hiscoreData.Name17, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score17, HiConvert.IntToByteArrayHex(score, hiscoreData.Score17.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Area17, HiConvert.IntToByteArrayHexAsHex(area, hiscoreData.Area17.Length));
                    break;
                case 17:
                    HiConvert.ByteArrayCopy(hiscoreData.Name18, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score18, HiConvert.IntToByteArrayHex(score, hiscoreData.Score18.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Area18, HiConvert.IntToByteArrayHexAsHex(area, hiscoreData.Area18.Length));
                    break;
                case 18:
                    HiConvert.ByteArrayCopy(hiscoreData.Name19, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score19, HiConvert.IntToByteArrayHex(score, hiscoreData.Score19.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Area19, HiConvert.IntToByteArrayHexAsHex(area, hiscoreData.Area19.Length));
                    break;
                case 19:
                    HiConvert.ByteArrayCopy(hiscoreData.Name20, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score20, HiConvert.IntToByteArrayHex(score, hiscoreData.Score20.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Area20, HiConvert.IntToByteArrayHexAsHex(area, hiscoreData.Area20.Length));
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
            HiConvert.ByteArrayCopy(hiscoreData.Score11, HiConvert.IntToByteArrayHex(0, hiscoreData.Score11.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score12, HiConvert.IntToByteArrayHex(0, hiscoreData.Score12.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score13, HiConvert.IntToByteArrayHex(0, hiscoreData.Score13.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score14, HiConvert.IntToByteArrayHex(0, hiscoreData.Score14.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score15, HiConvert.IntToByteArrayHex(0, hiscoreData.Score15.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score16, HiConvert.IntToByteArrayHex(0, hiscoreData.Score16.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score17, HiConvert.IntToByteArrayHex(0, hiscoreData.Score17.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score18, HiConvert.IntToByteArrayHex(0, hiscoreData.Score18.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score19, HiConvert.IntToByteArrayHex(0, hiscoreData.Score19.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score20, HiConvert.IntToByteArrayHex(0, hiscoreData.Score20.Length));

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}|{1}|{2}|{3}", 1, HiConvert.ByteArrayHexToInt(hiscoreData.Score1).ToString().PadLeft(7, '0'), ByteArrayToString(hiscoreData.Name1), GetArea(HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Area1))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 2, HiConvert.ByteArrayHexToInt(hiscoreData.Score2).ToString().PadLeft(7, '0'), ByteArrayToString(hiscoreData.Name2), GetArea(HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Area2))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 3, HiConvert.ByteArrayHexToInt(hiscoreData.Score3).ToString().PadLeft(7, '0'), ByteArrayToString(hiscoreData.Name3), GetArea(HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Area3))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 4, HiConvert.ByteArrayHexToInt(hiscoreData.Score4).ToString().PadLeft(7, '0'), ByteArrayToString(hiscoreData.Name4), GetArea(HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Area4))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 5, HiConvert.ByteArrayHexToInt(hiscoreData.Score5).ToString().PadLeft(7, '0'), ByteArrayToString(hiscoreData.Name5), GetArea(HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Area5))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 6, HiConvert.ByteArrayHexToInt(hiscoreData.Score6).ToString().PadLeft(7, '0'), ByteArrayToString(hiscoreData.Name6), GetArea(HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Area6))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 7, HiConvert.ByteArrayHexToInt(hiscoreData.Score7).ToString().PadLeft(7, '0'), ByteArrayToString(hiscoreData.Name7), GetArea(HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Area7))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 8, HiConvert.ByteArrayHexToInt(hiscoreData.Score8).ToString().PadLeft(7, '0'), ByteArrayToString(hiscoreData.Name8), GetArea(HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Area8))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 9, HiConvert.ByteArrayHexToInt(hiscoreData.Score9).ToString().PadLeft(7, '0'), ByteArrayToString(hiscoreData.Name9), GetArea(HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Area9))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 10, HiConvert.ByteArrayHexToInt(hiscoreData.Score10).ToString().PadLeft(7, '0'), ByteArrayToString(hiscoreData.Name10), GetArea(HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Area10))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 11, HiConvert.ByteArrayHexToInt(hiscoreData.Score11).ToString().PadLeft(7, '0'), ByteArrayToString(hiscoreData.Name11), GetArea(HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Area11))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 12, HiConvert.ByteArrayHexToInt(hiscoreData.Score12).ToString().PadLeft(7, '0'), ByteArrayToString(hiscoreData.Name12), GetArea(HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Area12))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 13, HiConvert.ByteArrayHexToInt(hiscoreData.Score13).ToString().PadLeft(7, '0'), ByteArrayToString(hiscoreData.Name13), GetArea(HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Area13))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 14, HiConvert.ByteArrayHexToInt(hiscoreData.Score14).ToString().PadLeft(7, '0'), ByteArrayToString(hiscoreData.Name14), GetArea(HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Area14))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 15, HiConvert.ByteArrayHexToInt(hiscoreData.Score15).ToString().PadLeft(7, '0'), ByteArrayToString(hiscoreData.Name15), GetArea(HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Area15))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 16, HiConvert.ByteArrayHexToInt(hiscoreData.Score16).ToString().PadLeft(7, '0'), ByteArrayToString(hiscoreData.Name16), GetArea(HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Area16))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 17, HiConvert.ByteArrayHexToInt(hiscoreData.Score17).ToString().PadLeft(7, '0'), ByteArrayToString(hiscoreData.Name17), GetArea(HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Area17))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 18, HiConvert.ByteArrayHexToInt(hiscoreData.Score18).ToString().PadLeft(7, '0'), ByteArrayToString(hiscoreData.Name18), GetArea(HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Area18))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 19, HiConvert.ByteArrayHexToInt(hiscoreData.Score19).ToString().PadLeft(7, '0'), ByteArrayToString(hiscoreData.Name19), GetArea(HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Area19))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 20, HiConvert.ByteArrayHexToInt(hiscoreData.Score20).ToString().PadLeft(7, '0'), ByteArrayToString(hiscoreData.Name20), GetArea(HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Area20))) + Environment.NewLine;

            return retString;
        }
    }
}