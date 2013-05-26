using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class narc : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16400)]
            public byte[] UnusedA;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Score1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Checksum1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Score2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Checksum2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Score3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Checksum3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Score4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Checksum4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Score5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Checksum5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Score6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Checksum6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Score7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Checksum7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Score8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Checksum8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Score9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Checksum9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Score10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Checksum10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Score11;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name11;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Checksum11;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Score12;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name12;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Checksum12;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Score13;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name13;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Checksum13;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Score14;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name14;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Checksum14;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Score15;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name15;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Checksum15;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Score16;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name16;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Checksum16;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Score17;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name17;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Checksum17;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Score18;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name18;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Checksum18;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Score19;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name19;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Checksum19;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Score20;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name20;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Checksum20;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16048)]
            public byte[] UnusedB;
        }

        public narc()
        {
            m_numEntries = 20;
            m_format = "RANK|SCORE|NAME";
            m_gamesSupported = "narc,narc3";
            m_extensionsRequired = ".nv";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if ((data[i] >= 'A' && data[i] <= 'Z') || data[i] == 32)
                    sb.Append(((char)(((int)data[i]))));
            }

            return sb.ToString();
        }

        public byte[] StringToByteArray(string str)
        {
            byte[] data = new byte[6];

            data[0] = 32;
            data[2] = 32;
            data[4] = 32;

            for (int i = 0; i < str.Length; i++)
            {
                if ((str[i] >= 'A' && str[i] <= 'Z') || data[i] == 32)
                    data[i*2] = (byte)((int)str[i]);
            }

            return data;
        }

        public string ByteArrayToScore(byte[] byteArray)
        {
            string tmpString = null;
            for (int i = 0; i < byteArray.Length; i = i + 2)
            {
                tmpString += byteArray[i].ToString("X2");
            }
            return tmpString;

        }

        public byte[] ScoreToByteArray(int score)
        {
            byte[] returnByteArray = new byte[8];
            string scoreAsStr = score.ToString();
            while (scoreAsStr.Length < 8)
            {
                scoreAsStr = "0" + scoreAsStr;
            }

            returnByteArray[6] = byte.Parse(scoreAsStr.Substring(scoreAsStr.Length - 2, 2), System.Globalization.NumberStyles.HexNumber);
            if (score > 99)
            {
                returnByteArray[4] = byte.Parse(scoreAsStr.Substring(scoreAsStr.Length - 4, 2), System.Globalization.NumberStyles.HexNumber);
                if (score > 9999)
                {
                    returnByteArray[2] = byte.Parse(scoreAsStr.Substring(scoreAsStr.Length - 6, 2), System.Globalization.NumberStyles.HexNumber);
                    if (score > 999999)
                    {
                        returnByteArray[0] = byte.Parse(scoreAsStr.Substring(scoreAsStr.Length - 8, 2), System.Globalization.NumberStyles.HexNumber);
                    }
                }
            }
            return returnByteArray;
        }

        public byte[] GetChecksum(byte[] name, byte[] score)
        {
            byte[] checksum = new byte[2];
            int total = 0;
            for (int i = 0; i < score.Length; i++)
            {
                total += score[i];
            }
            for (int i = 0; i < name.Length; i++)
            {
                total += name[i];
            }
            if (total > 255)
            {
                checksum[0] = (byte)(0x1FF - total);
            }
            else
            {
                checksum[0] = (byte)(0xFF - total);
            }
            return checksum;

        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = System.Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2];

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = NumEntries;
            if (score > Int32.Parse(ByteArrayToScore(hiscoreData.Score1)))
                rank = 0;
            else if (score > Int32.Parse(ByteArrayToScore(hiscoreData.Score2)))
                rank = 1;
            else if (score > Int32.Parse(ByteArrayToScore(hiscoreData.Score3)))
                rank = 2;
            else if (score > Int32.Parse(ByteArrayToScore(hiscoreData.Score4)))
                rank = 3;
            else if (score > Int32.Parse(ByteArrayToScore(hiscoreData.Score5)))
                rank = 4;
            else if (score > Int32.Parse(ByteArrayToScore(hiscoreData.Score6)))
                rank = 5;
            else if (score > Int32.Parse(ByteArrayToScore(hiscoreData.Score7)))
                rank = 6;
            else if (score > Int32.Parse(ByteArrayToScore(hiscoreData.Score8)))
                rank = 7;
            else if (score > Int32.Parse(ByteArrayToScore(hiscoreData.Score9)))
                rank = 8;
            else if (score > Int32.Parse(ByteArrayToScore(hiscoreData.Score10)))
                rank = 9;
            else if (score > Int32.Parse(ByteArrayToScore(hiscoreData.Score11)))
                rank = 10;
            else if (score > Int32.Parse(ByteArrayToScore(hiscoreData.Score12)))
                rank = 11;
            else if (score > Int32.Parse(ByteArrayToScore(hiscoreData.Score13)))
                rank = 12;
            else if (score > Int32.Parse(ByteArrayToScore(hiscoreData.Score14)))
                rank = 13;
            else if (score > Int32.Parse(ByteArrayToScore(hiscoreData.Score15)))
                rank = 14;
            else if (score > Int32.Parse(ByteArrayToScore(hiscoreData.Score16)))
                rank = 15;
            else if (score > Int32.Parse(ByteArrayToScore(hiscoreData.Score17)))
                rank = 16;
            else if (score > Int32.Parse(ByteArrayToScore(hiscoreData.Score18)))
                rank = 17;
            else if (score > Int32.Parse(ByteArrayToScore(hiscoreData.Score19)))
                rank = 18;
            else if (score > Int32.Parse(ByteArrayToScore(hiscoreData.Score20)))
                rank = 19;
            #endregion

            #region ADJUST
            int adjust = 19;
            if (rank < 19)
                adjust = 18;
            switch (adjust)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, hiscoreData.Score1);
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, hiscoreData.Name1);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum2, hiscoreData.Checksum1);
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum3, hiscoreData.Checksum2);
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, hiscoreData.Score3);
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, hiscoreData.Name3);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum4, hiscoreData.Checksum3);
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, hiscoreData.Score4);
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, hiscoreData.Name4);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum5, hiscoreData.Checksum4);
                    if (rank < 3)
                        goto case 2;
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, hiscoreData.Score5);
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, hiscoreData.Name5);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum6, hiscoreData.Checksum5);
                    if (rank < 4)
                        goto case 3;
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, hiscoreData.Score6);
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, hiscoreData.Name6);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum7, hiscoreData.Checksum6);
                    if (rank < 5)
                        goto case 4;
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, hiscoreData.Score7);
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, hiscoreData.Name7);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum8, hiscoreData.Checksum7);
                    if (rank < 6)
                        goto case 5;
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, hiscoreData.Score8);
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, hiscoreData.Name8);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum9, hiscoreData.Checksum8);
                    if (rank < 7)
                        goto case 6;
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, hiscoreData.Score9);
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, hiscoreData.Name9);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum10, hiscoreData.Checksum9);
                    if (rank < 8)
                        goto case 7;
                    break;
                case 9:
                    HiConvert.ByteArrayCopy(hiscoreData.Score11, hiscoreData.Score10);
                    HiConvert.ByteArrayCopy(hiscoreData.Name11, hiscoreData.Name10);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum11, hiscoreData.Checksum10);
                    if (rank < 9)
                        goto case 8;
                    break;
                case 10:
                    HiConvert.ByteArrayCopy(hiscoreData.Score12, hiscoreData.Score11);
                    HiConvert.ByteArrayCopy(hiscoreData.Name12, hiscoreData.Name11);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum12, hiscoreData.Checksum11);
                    if (rank < 10)
                        goto case 9;
                    break;
                case 11:
                    HiConvert.ByteArrayCopy(hiscoreData.Score13, hiscoreData.Score12);
                    HiConvert.ByteArrayCopy(hiscoreData.Name13, hiscoreData.Name12);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum13, hiscoreData.Checksum12);
                    if (rank < 11)
                        goto case 10;
                    break;
                case 12:
                    HiConvert.ByteArrayCopy(hiscoreData.Score14, hiscoreData.Score13);
                    HiConvert.ByteArrayCopy(hiscoreData.Name14, hiscoreData.Name13);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum14, hiscoreData.Checksum13);
                    if (rank < 12)
                        goto case 11;
                    break;
                case 13:
                    HiConvert.ByteArrayCopy(hiscoreData.Score15, hiscoreData.Score14);
                    HiConvert.ByteArrayCopy(hiscoreData.Name15, hiscoreData.Name14);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum15, hiscoreData.Checksum14);
                    if (rank < 13)
                        goto case 12;
                    break;
                case 14:
                    HiConvert.ByteArrayCopy(hiscoreData.Score16, hiscoreData.Score15);
                    HiConvert.ByteArrayCopy(hiscoreData.Name16, hiscoreData.Name15);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum16, hiscoreData.Checksum15);
                    if (rank < 14)
                        goto case 13;
                    break;
                case 15:
                    HiConvert.ByteArrayCopy(hiscoreData.Score17, hiscoreData.Score16);
                    HiConvert.ByteArrayCopy(hiscoreData.Name17, hiscoreData.Name16);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum17, hiscoreData.Checksum16);
                    if (rank < 15)
                        goto case 14;
                    break;
                case 16:
                    HiConvert.ByteArrayCopy(hiscoreData.Score18, hiscoreData.Score17);
                    HiConvert.ByteArrayCopy(hiscoreData.Name18, hiscoreData.Name17);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum18, hiscoreData.Checksum17);
                    if (rank < 16)
                        goto case 15;
                    break;
                case 17:
                    HiConvert.ByteArrayCopy(hiscoreData.Score19, hiscoreData.Score18);
                    HiConvert.ByteArrayCopy(hiscoreData.Name19, hiscoreData.Name18);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum19, hiscoreData.Checksum18);
                    if (rank < 17)
                        goto case 16;
                    break;
                case 18:
                    HiConvert.ByteArrayCopy(hiscoreData.Score20, hiscoreData.Score19);
                    HiConvert.ByteArrayCopy(hiscoreData.Name20, hiscoreData.Name19);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum20, hiscoreData.Checksum19);
                    if (rank < 18)
                        goto case 17;
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
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum1, GetChecksum(hiscoreData.Name1, hiscoreData.Score1));
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, ScoreToByteArray(score));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum2, GetChecksum(hiscoreData.Name2, hiscoreData.Score2));
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, ScoreToByteArray(score));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum3, GetChecksum(hiscoreData.Name3, hiscoreData.Score3));
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, ScoreToByteArray(score));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum4, GetChecksum(hiscoreData.Name4, hiscoreData.Score4));
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, ScoreToByteArray(score));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum5, GetChecksum(hiscoreData.Name5, hiscoreData.Score5));
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, ScoreToByteArray(score));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum6, GetChecksum(hiscoreData.Name6, hiscoreData.Score6));
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, ScoreToByteArray(score));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum7, GetChecksum(hiscoreData.Name7, hiscoreData.Score7));
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, ScoreToByteArray(score));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum8, GetChecksum(hiscoreData.Name8, hiscoreData.Score8));
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, ScoreToByteArray(score));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum9, GetChecksum(hiscoreData.Name9, hiscoreData.Score9));
                    break;
                case 9:
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, ScoreToByteArray(score));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum10, GetChecksum(hiscoreData.Name10, hiscoreData.Score10));
                    break;
                case 10:
                    HiConvert.ByteArrayCopy(hiscoreData.Name11, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score11, ScoreToByteArray(score));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum11, GetChecksum(hiscoreData.Name11, hiscoreData.Score11));
                    break;
                case 11:
                    HiConvert.ByteArrayCopy(hiscoreData.Name12, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score12, ScoreToByteArray(score));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum12, GetChecksum(hiscoreData.Name12, hiscoreData.Score12));
                    break;
                case 12:
                    HiConvert.ByteArrayCopy(hiscoreData.Name13, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score13, ScoreToByteArray(score));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum13, GetChecksum(hiscoreData.Name13, hiscoreData.Score13));
                    break;
                case 13:
                    HiConvert.ByteArrayCopy(hiscoreData.Name14, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score14, ScoreToByteArray(score));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum14, GetChecksum(hiscoreData.Name14, hiscoreData.Score14));
                    break;
                case 14:
                    HiConvert.ByteArrayCopy(hiscoreData.Name15, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score15, ScoreToByteArray(score));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum15, GetChecksum(hiscoreData.Name15, hiscoreData.Score15));
                    break;
                case 15:
                    HiConvert.ByteArrayCopy(hiscoreData.Name16, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score16, ScoreToByteArray(score));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum16, GetChecksum(hiscoreData.Name16, hiscoreData.Score16));
                    break;
                case 16:
                    HiConvert.ByteArrayCopy(hiscoreData.Name17, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score17, ScoreToByteArray(score));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum17, GetChecksum(hiscoreData.Name17, hiscoreData.Score17));
                    break;
                case 17:
                    HiConvert.ByteArrayCopy(hiscoreData.Name18, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score18, ScoreToByteArray(score));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum18, GetChecksum(hiscoreData.Name18, hiscoreData.Score18));
                    break;
                case 18:
                    HiConvert.ByteArrayCopy(hiscoreData.Name19, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score19, ScoreToByteArray(score));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum19, GetChecksum(hiscoreData.Name19, hiscoreData.Score19));
                    break;
                case 19:
                    HiConvert.ByteArrayCopy(hiscoreData.Name20, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score20, ScoreToByteArray(score));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum20, GetChecksum(hiscoreData.Name20, hiscoreData.Score20));
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

            HiConvert.ByteArrayCopy(hiscoreData.Checksum1, GetChecksum(hiscoreData.Name1, hiscoreData.Score1));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum2, GetChecksum(hiscoreData.Name1, hiscoreData.Score2));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum3, GetChecksum(hiscoreData.Name1, hiscoreData.Score3));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum4, GetChecksum(hiscoreData.Name1, hiscoreData.Score4));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum5, GetChecksum(hiscoreData.Name1, hiscoreData.Score5));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum6, GetChecksum(hiscoreData.Name1, hiscoreData.Score6));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum7, GetChecksum(hiscoreData.Name1, hiscoreData.Score7));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum8, GetChecksum(hiscoreData.Name1, hiscoreData.Score8));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum9, GetChecksum(hiscoreData.Name1, hiscoreData.Score9));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum10, GetChecksum(hiscoreData.Name1, hiscoreData.Score10));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum11, GetChecksum(hiscoreData.Name1, hiscoreData.Score11));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum12, GetChecksum(hiscoreData.Name1, hiscoreData.Score12));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum13, GetChecksum(hiscoreData.Name1, hiscoreData.Score13));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum14, GetChecksum(hiscoreData.Name1, hiscoreData.Score14));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum15, GetChecksum(hiscoreData.Name1, hiscoreData.Score15));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum16, GetChecksum(hiscoreData.Name1, hiscoreData.Score16));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum17, GetChecksum(hiscoreData.Name1, hiscoreData.Score17));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum18, GetChecksum(hiscoreData.Name1, hiscoreData.Score18));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum19, GetChecksum(hiscoreData.Name1, hiscoreData.Score19));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum20, GetChecksum(hiscoreData.Name1, hiscoreData.Score20));

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}|{1}|{2}", 1, ByteArrayToScore(hiscoreData.Score1), ByteArrayToString(hiscoreData.Name1)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 2, ByteArrayToScore(hiscoreData.Score2), ByteArrayToString(hiscoreData.Name2)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 3, ByteArrayToScore(hiscoreData.Score3), ByteArrayToString(hiscoreData.Name3)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 4, ByteArrayToScore(hiscoreData.Score4), ByteArrayToString(hiscoreData.Name4)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 5, ByteArrayToScore(hiscoreData.Score5), ByteArrayToString(hiscoreData.Name5)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 6, ByteArrayToScore(hiscoreData.Score6), ByteArrayToString(hiscoreData.Name6)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 7, ByteArrayToScore(hiscoreData.Score7), ByteArrayToString(hiscoreData.Name7)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 8, ByteArrayToScore(hiscoreData.Score8), ByteArrayToString(hiscoreData.Name8)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 9, ByteArrayToScore(hiscoreData.Score9), ByteArrayToString(hiscoreData.Name9)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 10, ByteArrayToScore(hiscoreData.Score10), ByteArrayToString(hiscoreData.Name10)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 11, ByteArrayToScore(hiscoreData.Score11), ByteArrayToString(hiscoreData.Name11)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 12, ByteArrayToScore(hiscoreData.Score12), ByteArrayToString(hiscoreData.Name12)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 13, ByteArrayToScore(hiscoreData.Score13), ByteArrayToString(hiscoreData.Name13)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 14, ByteArrayToScore(hiscoreData.Score14), ByteArrayToString(hiscoreData.Name14)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 15, ByteArrayToScore(hiscoreData.Score15), ByteArrayToString(hiscoreData.Name15)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 16, ByteArrayToScore(hiscoreData.Score16), ByteArrayToString(hiscoreData.Name16)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 17, ByteArrayToScore(hiscoreData.Score17), ByteArrayToString(hiscoreData.Name17)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 18, ByteArrayToScore(hiscoreData.Score18), ByteArrayToString(hiscoreData.Name18)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 19, ByteArrayToScore(hiscoreData.Score19), ByteArrayToString(hiscoreData.Name19)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 20, ByteArrayToScore(hiscoreData.Score20), ByteArrayToString(hiscoreData.Name20)) + Environment.NewLine;

            return retString;
        }
    }
}
