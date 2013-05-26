using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class nemesis : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            public byte Gender1;
            public byte Zodiac1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] Unknown1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score1;

            public byte Gender2;
            public byte Zodiac2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] Unknown2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score2;

            public byte Gender3;
            public byte Zodiac3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] Unknown3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score3;

            public byte Gender4;
            public byte Zodiac4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] Unknown4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score4;

            public byte Gender5;
            public byte Zodiac5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] Unknown5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score5;

            public byte Gender6;
            public byte Zodiac6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] Unknown6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score6;

            public byte Gender7;
            public byte Zodiac7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] Unknown7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score7;

            public byte Gender8;
            public byte Zodiac8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] Unknown8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score8;

            public byte Gender9;
            public byte Zodiac9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] Unknown9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score9;

            public byte Gender10;
            public byte Zodiac10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] Unknown10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score10;
            
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] HiScore;

            public byte CheckByte;
        }

        public nemesis()
        {
            m_numEntries = 10;
            m_format = "RANK|SCORE|NAME|GENDER|ZODIAC";
            m_gamesSupported = "nemesis,nemesisuk,nemesuk,gradius";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] >= 0x01 && data[i] <= 0x1a)
                    sb.Append(((char)((((int)data[i])) + 65 - 0x01)));
                else if (data[i] == 0x00)
                    sb.Append(' ');
                else if (data[i] == 0x1b)
                    sb.Append('-');
                else if (data[i] == 0x1c)
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
                    data[i] = (byte)(((int)str[i] - 65 + 0x01));
                else if (str[i] == ' ')
                    data[i] = 0x00;
                else if (str[i] == '-')
                    data[i] = 0x1b;
                else if (str[i] == '.')
                    data[i] = 0x1c;
            }

            return data;
        }

        public string GetGenderToString(byte gender)
        {
            switch (gender)
            {
                case 1:
                    return "FEMALE";
                default:
                    return "MALE";
            }
        }

        public byte GetGenderToByte(string gender)
        {
            switch (gender)
            {
                case "FEMALE":
                case "F":
                    return 1;
                default:
                    return 0;
            }
        }

        //TODO: Get names of zodiac symbols
        public string GetZodiacToString(byte zodiac)
        {
            switch (zodiac)
            {
                case 1:
                    return "1";
                case 2:
                    return "2";
                case 3:
                    return "3";
                case 4:
                    return "4";
                case 5:
                    return "5";
                case 6:
                    return "6";
                case 7:
                    return "7";
                case 8:
                    return "8";
                case 9:
                    return "9";
                case 10:
                    return "10";
                case 11:
                    return "11";
                default:
                    return "0";
            }
        }

        public byte GetZodiacToByte(string zodiac)
        {
            switch (zodiac)
            {
                case "1":
                    return 1;
                case "2":
                    return 2;
                case "3":
                    return 3;
                case "4":
                    return 4;
                case "5":
                    return 5;
                case "6":
                    return 6;
                case "7":
                    return 7;
                case "8":
                    return 8;
                case "9":
                    return 9;
                case "10":
                    return 10;
                case "11":
                    return 11;
                default:
                    return 0;
            }
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2].ToUpper().PadRight(3, 'A').Substring(0, 3);
            string gender = args[3].ToUpper();
            string zodiac = args[4].ToUpper();
            byte[] unknown = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00 };
            
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
                    HiConvert.ByteArrayCopy(hiscoreData.Unknown2, hiscoreData.Unknown1);
                    hiscoreData.Gender2 = hiscoreData.Gender1;
                    hiscoreData.Zodiac2 = hiscoreData.Zodiac1;
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
                    HiConvert.ByteArrayCopy(hiscoreData.Unknown3, hiscoreData.Unknown2);
                    hiscoreData.Gender3 = hiscoreData.Gender2;
                    hiscoreData.Zodiac3 = hiscoreData.Zodiac2; 
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, hiscoreData.Score3);
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, hiscoreData.Name3);
                    HiConvert.ByteArrayCopy(hiscoreData.Unknown4, hiscoreData.Unknown3);
                    hiscoreData.Gender4 = hiscoreData.Gender3;
                    hiscoreData.Zodiac4 = hiscoreData.Zodiac3;
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, hiscoreData.Score4);
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, hiscoreData.Name4);
                    HiConvert.ByteArrayCopy(hiscoreData.Unknown5, hiscoreData.Unknown4);
                    hiscoreData.Gender5 = hiscoreData.Gender4;
                    hiscoreData.Zodiac5 = hiscoreData.Zodiac4;
                    if (rank < 3)
                        goto case 2;
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, hiscoreData.Score5);
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, hiscoreData.Name5);
                    HiConvert.ByteArrayCopy(hiscoreData.Unknown6, hiscoreData.Unknown5);
                    hiscoreData.Gender6 = hiscoreData.Gender5;
                    hiscoreData.Zodiac6 = hiscoreData.Zodiac5;
                    if (rank < 4)
                        goto case 3;
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, hiscoreData.Score6);
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, hiscoreData.Name6);
                    HiConvert.ByteArrayCopy(hiscoreData.Unknown7, hiscoreData.Unknown6);
                    hiscoreData.Gender7 = hiscoreData.Gender6;
                    hiscoreData.Zodiac7 = hiscoreData.Zodiac6;
                    if (rank < 5)
                        goto case 4;
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, hiscoreData.Score7);
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, hiscoreData.Name7);
                    HiConvert.ByteArrayCopy(hiscoreData.Unknown8, hiscoreData.Unknown7);
                    hiscoreData.Gender8 = hiscoreData.Gender7;
                    hiscoreData.Zodiac8 = hiscoreData.Zodiac7;
                    if (rank < 6)
                        goto case 5;
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, hiscoreData.Score8);
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, hiscoreData.Name8);
                    HiConvert.ByteArrayCopy(hiscoreData.Unknown9, hiscoreData.Unknown8);
                    hiscoreData.Gender9 = hiscoreData.Gender8;
                    hiscoreData.Zodiac9 = hiscoreData.Zodiac8;
                    if (rank < 7)
                        goto case 6;
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, hiscoreData.Score9);
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, hiscoreData.Name9);
                    HiConvert.ByteArrayCopy(hiscoreData.Unknown10, hiscoreData.Unknown9);
                    hiscoreData.Gender10 = hiscoreData.Gender9;
                    hiscoreData.Zodiac10 = hiscoreData.Zodiac9;
                    if (rank < 8)
                        goto case 7;
                    break;
            }
            #endregion

            #region REPLACE_NEW
            switch (rank)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Name1, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.IntToByteArrayHex(score, hiscoreData.Score1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Unknown1, unknown);
                    HiConvert.ByteArrayCopy(hiscoreData.HiScore, hiscoreData.Score1);
                    hiscoreData.Gender1 = GetGenderToByte(gender);
                    hiscoreData.Zodiac1 = GetZodiacToByte(zodiac);
                    hiscoreData.CheckByte = hiscoreData.Score1[2];
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.IntToByteArrayHex(score, hiscoreData.Score2.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Unknown2, unknown);
                    hiscoreData.Gender2 = GetGenderToByte(gender);
                    hiscoreData.Zodiac2 = GetZodiacToByte(zodiac);
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.IntToByteArrayHex(score, hiscoreData.Score3.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Unknown3, unknown);
                    hiscoreData.Gender3 = GetGenderToByte(gender);
                    hiscoreData.Zodiac3 = GetZodiacToByte(zodiac);
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.IntToByteArrayHex(score, hiscoreData.Score4.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Unknown4, unknown);
                    hiscoreData.Gender4 = GetGenderToByte(gender);
                    hiscoreData.Zodiac4 = GetZodiacToByte(zodiac);
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.IntToByteArrayHex(score, hiscoreData.Score5.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Unknown5, unknown);
                    hiscoreData.Gender5 = GetGenderToByte(gender);
                    hiscoreData.Zodiac5 = GetZodiacToByte(zodiac);
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, HiConvert.IntToByteArrayHex(score, hiscoreData.Score6.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Unknown6, unknown);
                    hiscoreData.Gender6 = GetGenderToByte(gender);
                    hiscoreData.Zodiac6 = GetZodiacToByte(zodiac);
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, HiConvert.IntToByteArrayHex(score, hiscoreData.Score7.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Unknown7, unknown);
                    hiscoreData.Gender7 = GetGenderToByte(gender);
                    hiscoreData.Zodiac7 = GetZodiacToByte(zodiac);
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, HiConvert.IntToByteArrayHex(score, hiscoreData.Score8.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Unknown8, unknown);
                    hiscoreData.Gender8 = GetGenderToByte(gender);
                    hiscoreData.Zodiac8 = GetZodiacToByte(zodiac);
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, HiConvert.IntToByteArrayHex(score, hiscoreData.Score9.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Unknown9, unknown);
                    hiscoreData.Gender9 = GetGenderToByte(gender);
                    hiscoreData.Zodiac9 = GetZodiacToByte(zodiac);
                    break;
                case 9:
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, HiConvert.IntToByteArrayHex(score, hiscoreData.Score10.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Unknown10, unknown);
                    hiscoreData.Gender10 = GetGenderToByte(gender);
                    hiscoreData.Zodiac10 = GetZodiacToByte(zodiac);
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

            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 1, HiConvert.ByteArrayHexToInt(hiscoreData.Score1), ByteArrayToString(hiscoreData.Name1), GetGenderToString(hiscoreData.Gender1), GetZodiacToString(hiscoreData.Zodiac1)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 2, HiConvert.ByteArrayHexToInt(hiscoreData.Score2), ByteArrayToString(hiscoreData.Name2), GetGenderToString(hiscoreData.Gender2), GetZodiacToString(hiscoreData.Zodiac2)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 3, HiConvert.ByteArrayHexToInt(hiscoreData.Score3), ByteArrayToString(hiscoreData.Name3), GetGenderToString(hiscoreData.Gender3), GetZodiacToString(hiscoreData.Zodiac3)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 4, HiConvert.ByteArrayHexToInt(hiscoreData.Score4), ByteArrayToString(hiscoreData.Name4), GetGenderToString(hiscoreData.Gender4), GetZodiacToString(hiscoreData.Zodiac4)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 5, HiConvert.ByteArrayHexToInt(hiscoreData.Score5), ByteArrayToString(hiscoreData.Name5), GetGenderToString(hiscoreData.Gender5), GetZodiacToString(hiscoreData.Zodiac5)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 6, HiConvert.ByteArrayHexToInt(hiscoreData.Score6), ByteArrayToString(hiscoreData.Name6), GetGenderToString(hiscoreData.Gender6), GetZodiacToString(hiscoreData.Zodiac6)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 7, HiConvert.ByteArrayHexToInt(hiscoreData.Score7), ByteArrayToString(hiscoreData.Name7), GetGenderToString(hiscoreData.Gender7), GetZodiacToString(hiscoreData.Zodiac7)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 8, HiConvert.ByteArrayHexToInt(hiscoreData.Score8), ByteArrayToString(hiscoreData.Name8), GetGenderToString(hiscoreData.Gender8), GetZodiacToString(hiscoreData.Zodiac8)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 9, HiConvert.ByteArrayHexToInt(hiscoreData.Score9), ByteArrayToString(hiscoreData.Name9), GetGenderToString(hiscoreData.Gender9), GetZodiacToString(hiscoreData.Zodiac9)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 10, HiConvert.ByteArrayHexToInt(hiscoreData.Score10), ByteArrayToString(hiscoreData.Name10), GetGenderToString(hiscoreData.Gender10), GetZodiacToString(hiscoreData.Zodiac10)) + Environment.NewLine;
       
            return retString;
        }
    }
}