using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class cleopatr : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            public byte ScoreTableShown;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Blocks1;
            public byte Level1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Blocks2;
            public byte Level2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Blocks3;
            public byte Level3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Blocks4;
            public byte Level4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name4;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Blocks5;
            public byte Level5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name5;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Blocks6;
            public byte Level6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name6;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Blocks7;
            public byte Level7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name7;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Blocks8;
            public byte Level8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name8;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Blocks9;
            public byte Level9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name9;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Blocks10;
            public byte Level10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name10;

            public byte CheckByte;
        }

        public cleopatr()
        {
            // Max. score: ???????????
            m_numEntries = 10;
            m_format = "RANK|SCORE|NAME|LEVEL|BLOCKS";
            m_gamesSupported = "cleopatr";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == 0x00)
                    sb.Append(' ');
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
                if (str[i] == (char)0x00 || str[i] == ' ')
                    data[i] = 0x00;
                else
                    data[i] = (byte)((int)str[i]);
            }

            return data;
        }

        public byte SetLevelFromString(string str)
        {
            if (str == "ALL" || Convert.ToByte(str) >= 0x64) return 0x64; // Level 100 (ALL)
            return Convert.ToByte(str);
        }

        public string GetLevelFromByte(byte level)
        {
            if (level == 0x64) return "ALL";
            return level.ToString();
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2].PadRight(3, '.').Substring(0, 3);
            byte level = SetLevelFromString (args[3].ToUpper());
            int blocks = System.Convert.ToInt32(args[4]);

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = NumEntries;
            if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score1))
                rank = 0;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score2))
                rank = 1;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score3))
                rank = 2;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score4))
                rank = 3;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score5))
                rank = 4;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score6))
                rank = 5;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score7))
                rank = 6;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score8))
                rank = 7;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score9))
                rank = 8;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score10))
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
                    HiConvert.ByteArrayCopy(hiscoreData.Blocks2, hiscoreData.Blocks1);
                    hiscoreData.Level2 = hiscoreData.Level1;
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
                    HiConvert.ByteArrayCopy(hiscoreData.Blocks3, hiscoreData.Blocks2);
                    hiscoreData.Level3 = hiscoreData.Level2;
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, hiscoreData.Score3);
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, hiscoreData.Name3);
                    HiConvert.ByteArrayCopy(hiscoreData.Blocks4, hiscoreData.Blocks3);
                    hiscoreData.Level4 = hiscoreData.Level3;
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, hiscoreData.Score4);
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, hiscoreData.Name4);
                    HiConvert.ByteArrayCopy(hiscoreData.Blocks5, hiscoreData.Blocks4);
                    hiscoreData.Level5 = hiscoreData.Level4;
                    if (rank < 3)
                        goto case 2;
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, hiscoreData.Score5);
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, hiscoreData.Name5);
                    HiConvert.ByteArrayCopy(hiscoreData.Blocks6, hiscoreData.Blocks5);
                    hiscoreData.Level6 = hiscoreData.Level5;
                    if (rank < 4)
                        goto case 3;
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, hiscoreData.Score6);
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, hiscoreData.Name6);
                    HiConvert.ByteArrayCopy(hiscoreData.Blocks7, hiscoreData.Blocks6);
                    hiscoreData.Level7 = hiscoreData.Level6;
                    if (rank < 5)
                        goto case 4;
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, hiscoreData.Score7);
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, hiscoreData.Name7);
                    HiConvert.ByteArrayCopy(hiscoreData.Blocks8, hiscoreData.Blocks7);
                    hiscoreData.Level8 = hiscoreData.Level7;
                    if (rank < 6)
                        goto case 5;
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, hiscoreData.Score8);
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, hiscoreData.Name8);
                    HiConvert.ByteArrayCopy(hiscoreData.Blocks9, hiscoreData.Blocks8);
                    hiscoreData.Level9 = hiscoreData.Level8;
                    if (rank < 7)
                        goto case 6;
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, hiscoreData.Score9);
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, hiscoreData.Name9);
                    HiConvert.ByteArrayCopy(hiscoreData.Blocks10, hiscoreData.Blocks9);
                    hiscoreData.Level10 = hiscoreData.Level9;
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
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Blocks1, HiConvert.IntToByteArrayHexAsHex(blocks, hiscoreData.Blocks1.Length));
                    hiscoreData.Level1 = level;
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score2.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Blocks2, HiConvert.IntToByteArrayHexAsHex(blocks, hiscoreData.Blocks2.Length));
                    hiscoreData.Level2 = level;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score3.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Blocks3, HiConvert.IntToByteArrayHexAsHex(blocks, hiscoreData.Blocks3.Length));
                    hiscoreData.Level3 = level;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score4.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Blocks4, HiConvert.IntToByteArrayHexAsHex(blocks, hiscoreData.Blocks4.Length));
                    hiscoreData.Level4 = level;
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score5.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Blocks5, HiConvert.IntToByteArrayHexAsHex(blocks, hiscoreData.Blocks5.Length));
                    hiscoreData.Level5 = level;
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score6.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Blocks6, HiConvert.IntToByteArrayHexAsHex(blocks, hiscoreData.Blocks6.Length));
                    hiscoreData.Level6 = level;
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score7.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Blocks7, HiConvert.IntToByteArrayHexAsHex(blocks, hiscoreData.Blocks7.Length));
                    hiscoreData.Level7 = level;
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score8.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Blocks8, HiConvert.IntToByteArrayHexAsHex(blocks, hiscoreData.Blocks8.Length));
                    hiscoreData.Level8 = level;
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score9.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Blocks9, HiConvert.IntToByteArrayHexAsHex(blocks, hiscoreData.Blocks9.Length));
                    hiscoreData.Level9 = level;
                    break;
                case 9:
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score10.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Blocks10, HiConvert.IntToByteArrayHexAsHex(blocks, hiscoreData.Blocks10.Length));
                    hiscoreData.Level10 = level;
                    break;        
            }
            #endregion

            hiscoreData.ScoreTableShown = 0x01; // Set to 01 to tell game that score tables has been shown.
            hiscoreData.CheckByte = 0x01;

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score3.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score4.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score5.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score6, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score6.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score7, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score7.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score8, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score8.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score9, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score9.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score10, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score10.Length));
           
            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 1, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score1), ByteArrayToString(hiscoreData.Name1), GetLevelFromByte(hiscoreData.Level1), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Blocks1)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 2, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score2), ByteArrayToString(hiscoreData.Name2), GetLevelFromByte(hiscoreData.Level2), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Blocks2)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 3, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score3), ByteArrayToString(hiscoreData.Name3), GetLevelFromByte(hiscoreData.Level3), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Blocks3)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 4, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score4), ByteArrayToString(hiscoreData.Name4), GetLevelFromByte(hiscoreData.Level4), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Blocks4)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 5, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score5), ByteArrayToString(hiscoreData.Name5), GetLevelFromByte(hiscoreData.Level5), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Blocks5)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 6, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score6), ByteArrayToString(hiscoreData.Name6), GetLevelFromByte(hiscoreData.Level6), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Blocks6)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 7, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score7), ByteArrayToString(hiscoreData.Name7), GetLevelFromByte(hiscoreData.Level7), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Blocks7)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 8, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score8), ByteArrayToString(hiscoreData.Name8), GetLevelFromByte(hiscoreData.Level8), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Blocks8)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 9, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score9), ByteArrayToString(hiscoreData.Name9), GetLevelFromByte(hiscoreData.Level9), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Blocks9)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 10, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score10), ByteArrayToString(hiscoreData.Name10), GetLevelFromByte(hiscoreData.Level10), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Blocks10)) + Environment.NewLine;

            return retString;
        }
    }
}