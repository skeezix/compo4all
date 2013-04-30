using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class solarq : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Name1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score1Part1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score1Part2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Name2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score2Part1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score2Part2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Name3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score3Part1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score3Part2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Name4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score4Part1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score4Part2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Name5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score5Part1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score5Part2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Name6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score6Part1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score6Part2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Name7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score7Part1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score7Part2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Name8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score8Part1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score8Part2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Name9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score9Part1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score9Part2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Name10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score10Part1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score10Part2;
        }

        public solarq()
        {
            m_numEntries = 10;
            m_format = "RANK|SCORE|NAME";
            m_gamesSupported = "solarq";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();
            byte[] newdata = new byte[3];

            // 4 bytes 3 characters 
            // First, bits with weight 1,2,4,8,16,32 of byte 2
            // Second, bits with weight 1,2,4,8,16,32 of byte 1 and 64,128 of byte 2
            // Third, bits with weight 1,2,4,8,16,32 of byte 4
            newdata[0] = (byte)((int)data[1] & 0x3f); // this and below are inverted respect boxingb
            newdata[1] = (byte)((((int)data[0] & 0x3f) * 4) + (((int)data[1] & 0xc0) / 64));
            newdata[2] = (byte)((int)data[3] & 0x3f);

            for (int i = 0; i < newdata.Length; i++)
            {
                if (newdata[i] >= 0x21 && newdata[i] <= 0x3a)
                    sb.Append(((char)((((int)newdata[i])) + 65 - 0x01 - 0x20)));
                else if (newdata[i] == 0x20)
                    sb.Append(' ');
            }

            return sb.ToString();
        }

        public byte[] StringToByteArray(string str, int maxLength)
        {
            byte[] newdata = new byte[maxLength];
            byte[] data = new byte[str.Length];
                        
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 'A' && str[i] <= 'Z')
                    data[i] = (byte)((int)str[i] - 65 + 0x01 + 0x20);
                else if (str[i] == ' ')
                    data[i] = 0x00 + 0x20;
            }

            newdata[0] = (byte)((((int)data[1]) & 0xfc) / 4);
            newdata[1] = (byte)((((int)data[1] & 0x03) * 64) + (int)data[0]);
            newdata[2] = 0x00; 
            newdata[3] = (byte)(int)data[2];

            return newdata;
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score1 = System.Convert.ToInt32(args[1].PadLeft(6, '0').Substring(0, 2));
            int score2 = System.Convert.ToInt32(args[1].PadLeft(6, '0').Substring(2, 3));
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
            else if (score1 * 1000 + score2 > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score6Part1) * 1000 + HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score6Part2))
                rank = 5;
            else if (score1 * 1000 + score2 > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score7Part1) * 1000 + HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score7Part2))
                rank = 6;
            else if (score1 * 1000 + score2 > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score8Part1) * 1000 + HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score8Part2))
                rank = 7;
            else if (score1 * 1000 + score2 > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score9Part1) * 1000 + HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score9Part2))
                rank = 8;
            else if (score1 * 1000 + score2 > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score10Part1) * 1000 + HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score10Part2))
                rank = 9;
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
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Score6Part1, hiscoreData.Score5Part1);
                    HiConvert.ByteArrayCopy(hiscoreData.Score6Part2, hiscoreData.Score5Part2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, hiscoreData.Name5);
                    if (rank < 4)
                        goto case 3;
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Score7Part1, hiscoreData.Score6Part1);
                    HiConvert.ByteArrayCopy(hiscoreData.Score7Part2, hiscoreData.Score6Part2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, hiscoreData.Name6);
                    if (rank < 5)
                        goto case 4;
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Score8Part1, hiscoreData.Score7Part1);
                    HiConvert.ByteArrayCopy(hiscoreData.Score8Part2, hiscoreData.Score7Part2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, hiscoreData.Name7);
                    if (rank < 6)
                        goto case 5;
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Score9Part1, hiscoreData.Score8Part1);
                    HiConvert.ByteArrayCopy(hiscoreData.Score9Part2, hiscoreData.Score8Part2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, hiscoreData.Name8);
                    if (rank < 7)
                        goto case 6;
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Score10Part1, hiscoreData.Score9Part1);
                    HiConvert.ByteArrayCopy(hiscoreData.Score10Part2, hiscoreData.Score9Part2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, hiscoreData.Name9);
                    if (rank < 8)
                        goto case 7;
                    break;
            }
            #endregion

            #region REPLACE_NEW
            switch (rank)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Name1, StringToByteArray(name, hiscoreData.Name1.Length));
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
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, StringToByteArray(name, hiscoreData.Name6.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score6Part1, HiConvert.IntToByteArrayHexAsHex(score1, hiscoreData.Score6Part1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score6Part2, HiConvert.IntToByteArrayHexAsHex(score2, hiscoreData.Score6Part2.Length));
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, StringToByteArray(name, hiscoreData.Name7.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score7Part1, HiConvert.IntToByteArrayHexAsHex(score1, hiscoreData.Score7Part1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score7Part2, HiConvert.IntToByteArrayHexAsHex(score2, hiscoreData.Score7Part2.Length));
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, StringToByteArray(name, hiscoreData.Name8.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score8Part1, HiConvert.IntToByteArrayHexAsHex(score1, hiscoreData.Score8Part1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score8Part2, HiConvert.IntToByteArrayHexAsHex(score2, hiscoreData.Score8Part2.Length));
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, StringToByteArray(name, hiscoreData.Name9.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score9Part1, HiConvert.IntToByteArrayHexAsHex(score1, hiscoreData.Score9Part1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score9Part2, HiConvert.IntToByteArrayHexAsHex(score2, hiscoreData.Score9Part2.Length));
                    break;
                case 9:
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, StringToByteArray(name, hiscoreData.Name10.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score10Part1, HiConvert.IntToByteArrayHexAsHex(score1, hiscoreData.Score10Part1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score10Part2, HiConvert.IntToByteArrayHexAsHex(score2, hiscoreData.Score10Part2.Length));
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
            HiConvert.ByteArrayCopy(hiscoreData.Score6Part1, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score6Part1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score6Part2, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score6Part2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score7Part1, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score7Part1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score7Part2, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score7Part2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score8Part1, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score8Part1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score8Part2, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score8Part2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score9Part1, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score9Part1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score9Part2, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score9Part2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score10Part1, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score10Part1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score10Part2, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score10Part2.Length));
 
            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            if (HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score1Part1) > 0 || HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score1Part2) > 0)
                retString += String.Format("{0}|{2}|{1}", 1, ByteArrayToString(hiscoreData.Name1), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score1Part1) * 10000 + HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score1Part2) * 10) + Environment.NewLine;
            if (HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score2Part1) > 0 || HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score2Part2) > 0)
                retString += String.Format("{0}|{2}|{1}", 2, ByteArrayToString(hiscoreData.Name2), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score2Part1) * 10000 + HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score2Part2) * 10) + Environment.NewLine;
            if (HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score3Part1) > 0 || HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score3Part2) > 0)
                retString += String.Format("{0}|{2}|{1}", 3, ByteArrayToString(hiscoreData.Name3), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score3Part1) * 10000 + HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score3Part2) * 10) + Environment.NewLine;
            if (HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score4Part1) > 0 || HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score4Part2) > 0)
                retString += String.Format("{0}|{2}|{1}", 4, ByteArrayToString(hiscoreData.Name4), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score4Part1) * 10000 + HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score4Part2) * 10) + Environment.NewLine;
            if (HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score5Part1) > 0 || HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score5Part2) > 0)
                retString += String.Format("{0}|{2}|{1}", 5, ByteArrayToString(hiscoreData.Name5), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score5Part1) * 10000 + HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score5Part2) * 10) + Environment.NewLine;
            if (HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score6Part1) > 0 || HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score6Part2) > 0)
                retString += String.Format("{0}|{2}|{1}", 6, ByteArrayToString(hiscoreData.Name6), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score6Part1) * 10000 + HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score6Part2) * 10) + Environment.NewLine;
            if (HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score7Part1) > 0 || HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score7Part2) > 0)
                retString += String.Format("{0}|{2}|{1}", 7, ByteArrayToString(hiscoreData.Name7), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score7Part1) * 10000 + HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score7Part2) * 10) + Environment.NewLine;
            if (HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score8Part1) > 0 || HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score8Part2) > 0)
                retString += String.Format("{0}|{2}|{1}", 8, ByteArrayToString(hiscoreData.Name8), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score8Part1) * 10000 + HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score8Part2) * 10) + Environment.NewLine;
            if (HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score9Part1) > 0 || HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score9Part2) > 0)
                retString += String.Format("{0}|{2}|{1}", 9, ByteArrayToString(hiscoreData.Name9), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score9Part1) * 10000 + HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score9Part2) * 10) + Environment.NewLine;
            if (HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score10Part1) > 0 || HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score10Part2) > 0)
                retString += String.Format("{0}|{2}|{1}", 10, ByteArrayToString(hiscoreData.Name10), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score10Part1) * 10000 + HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score10Part2) * 10) + Environment.NewLine;
      
            return retString;
        }
    }
}