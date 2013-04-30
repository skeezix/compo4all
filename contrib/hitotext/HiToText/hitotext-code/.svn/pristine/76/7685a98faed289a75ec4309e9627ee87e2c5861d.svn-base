using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class metrocrs : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] SpaceA1;
            public byte Round1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] SpaceB1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Name1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Footer1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] SpaceA2;
            public byte Round2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] SpaceB2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Name2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Footer2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] SpaceA3;
            public byte Round3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] SpaceB3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Name3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Footer3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] SpaceA4;
            public byte Round4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] SpaceB4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Name4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Footer4;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] SpaceA5;
            public byte Round5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] SpaceB5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Name5;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] HiScoreShort;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] HiScoreLong;
        }

        public metrocrs()
        {
            m_numEntries = 5;
            m_format = "RANK|SCORE|NAME|ROUND";
            m_gamesSupported = "metrocrs,metrocra";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] >= 0x0a && data[i] <= 0x23)
                    sb.Append(((char)(((int)data[i]) + 65 - 0x0a)));
                else if (data[i] == 0x2b)
                    sb.Append(' ');
                else if (data[i] == 0x24)
                    sb.Append('.');
                else if (data[i] == 0x2a)
                    sb.Append('!');
                else if (data[i] == 0x29)
                    sb.Append('”');
                else if (data[i] == 0x28)
                    sb.Append('“');
                else if (data[i] == 0x27)
                    sb.Append('-');
                else if (data[i] == 0x26)
                    sb.Append('/');
                else if (data[i] == 0x25)
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
                    data[i] = (byte)((int)str[i] - 65 + 0x0a);
                else if (str[i] == ' ')
                    data[i] = 0x2b;
                else if (str[i] == '.')
                    data[i] = 0x24;
                else if (str[i] == '!')
                    data[i] = 0x2a;
                else if (str[i] == '”')
                    data[i] = 0x29;
                else if (str[i] == '“')
                    data[i] = 0x28;
                else if (str[i] == '-')
                    data[i] = 0x27;
                else if (str[i] == '/')
                    data[i] = 0x26;
                else if (str[i] == ',')
                    data[i] = 0x25;
            }

            return data;
        }

        public byte[] ScoreToByteArray(int score, int numBytes, byte spaceChar)
        {
            bool nonZero = false;
            byte[] toReturn = HiConvert.IntToByteArraySingleBCD(score, numBytes);

            for (int i = 0; i < toReturn.Length; i++)
            {
                if (toReturn[i].Equals(0x00) && !nonZero)
                    toReturn[i] = spaceChar;
                else
                    nonZero = true;
            }

            return toReturn;
        }

        public int ByteArrayToScore(byte[] score, byte spaceChar)
        {
            byte[] newScore = new byte[score.Length];
            for (int i = 0; i < score.Length; i++)
            {
                if (score[i].Equals(spaceChar))
                    newScore[i] = 0;
                else
                    newScore[i] = score[i];
            }

            return HiConvert.ByteArraySingleBCDToInt(newScore);
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2];
            int round = System.Convert.ToInt32(args[3]);

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = 5;
            if (score > ByteArrayToScore(hiscoreData.Score1, 0x2b))
                rank = 0;
            else if (score > ByteArrayToScore(hiscoreData.Score2, 0x2b))
                rank = 1;
            else if (score > ByteArrayToScore(hiscoreData.Score3, 0x2b))
                rank = 2;
            else if (score > ByteArrayToScore(hiscoreData.Score4, 0x2b))
                rank = 3;
            else if (score > ByteArrayToScore(hiscoreData.Score5, 0x2b))
                rank = 4;
            #endregion

            #region ADJUST
            int adjust = 4;
            if (rank < 4)
                adjust = 3;
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
                default:
                    break;
            }
            #endregion

            #region REPLACE_NEW
            switch (rank)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, ScoreToByteArray(score, hiscoreData.Score1.Length, 0x2b));
                    HiConvert.ByteArrayCopy(hiscoreData.HiScoreLong, ScoreToByteArray(score, hiscoreData.HiScoreLong.Length, 0x2d));
                    HiConvert.ByteArrayCopy(hiscoreData.HiScoreShort, HiConvert.IntToByteArrayHex(score / 10, hiscoreData.HiScoreShort.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name1, StringToByteArray(name));
                    hiscoreData.Round1 = (byte)round;
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, ScoreToByteArray(score, hiscoreData.Score2.Length, 0x2b));
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name));
                    hiscoreData.Round2 = (byte)round;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, ScoreToByteArray(score, hiscoreData.Score3.Length, 0x2b));
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name));
                    hiscoreData.Round3 = (byte)round;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, ScoreToByteArray(score, hiscoreData.Score4.Length, 0x2b));
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name));
                    hiscoreData.Round4 = (byte)round;
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, ScoreToByteArray(score, hiscoreData.Score5.Length, 0x2b));
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name));
                    hiscoreData.Round5 = (byte)round;
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
            
            HiConvert.ByteArrayCopy(hiscoreData.Score1, ScoreToByteArray(0, 7, 0x2b));
            HiConvert.ByteArrayCopy(hiscoreData.Score2, ScoreToByteArray(0, 7, 0x2b));
            HiConvert.ByteArrayCopy(hiscoreData.Score3, ScoreToByteArray(0, 7, 0x2b));
            HiConvert.ByteArrayCopy(hiscoreData.Score4, ScoreToByteArray(0, 7, 0x2b));
            HiConvert.ByteArrayCopy(hiscoreData.Score5, ScoreToByteArray(0, 7, 0x2b));

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}|{1}|{2}|{3}", 1, ByteArrayToScore(hiscoreData.Score1, 0x2b), ByteArrayToString(hiscoreData.Name1), hiscoreData.Round1) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 2, ByteArrayToScore(hiscoreData.Score2, 0x2b), ByteArrayToString(hiscoreData.Name2), hiscoreData.Round2) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 3, ByteArrayToScore(hiscoreData.Score3, 0x2b), ByteArrayToString(hiscoreData.Name3), hiscoreData.Round3) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 4, ByteArrayToScore(hiscoreData.Score4, 0x2b), ByteArrayToString(hiscoreData.Name4), hiscoreData.Round4) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 5, ByteArrayToScore(hiscoreData.Score5, 0x2b), ByteArrayToString(hiscoreData.Name5), hiscoreData.Round5) + Environment.NewLine;
            
            return retString;
        }
    }
}
