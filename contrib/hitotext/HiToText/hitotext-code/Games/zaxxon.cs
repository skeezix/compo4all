using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class zaxxon : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] UnknownA1;
            public byte Rank1;
            public byte UnknownB1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] ScoreLong1;
            public byte UnknownC1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name1;
            public byte UnknownD1;
            public byte UnknownE1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreShort1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] UnknownF1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] UnknownA2;
            public byte Rank2;
            public byte UnknownB2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] ScoreLong2;
            public byte UnknownC2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name2;
            public byte UnknownD2;
            public byte UnknownE2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreShort2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] UnknownF2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] UnknownA3;
            public byte Rank3;
            public byte UnknownB3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] ScoreLong3;
            public byte UnknownC3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name3;
            public byte UnknownD3;
            public byte UnknownE3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreShort3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] UnknownF3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] UnknownA4;
            public byte Rank4;
            public byte UnknownB4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] ScoreLong4;
            public byte UnknownC4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name4;
            public byte UnknownD4;
            public byte UnknownE4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreShort4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] UnknownF4;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] UnknownA5;
            public byte Rank5;
            public byte UnknownB5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] ScoreLong5;
            public byte UnknownC5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name5;
            public byte UnknownD5;
            public byte UnknownE5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreShort5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] UnknownF5;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] UnknownA6;
            public byte Rank6;
            public byte UnknownB6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] ScoreLong6;
            public byte UnknownC6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name6;
            public byte UnknownD6;
            public byte UnknownE6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreShort6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] UnknownF6;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] HiScore;
        }

        public zaxxon()
        {
            m_numEntries = 6;
            m_format = "RANK|SCORE|NAME";
            m_gamesSupported = "zaxxon,zaxxon2,zaxxonb,szaxxon";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] >= 0x11 && data[i] <= 0x2a)
                    sb.Append(((char)(((int)data[i]) + 65 - 0x11)));
                else if (data[i] == 0x10)
                    sb.Append(' ');
                else if (data[i] == 0x60)
                    sb.Append(' ');
                else if (data[i] == 0x2b)
                    sb.Append('.');
                else if (data[i] == 0x2c)
                    sb.Append('-');
            }

            return sb.ToString();
        }

        public byte[] StringToByteArray(string str)
        {
            byte[] data = new byte[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 'A' && str[i] <= 'Z')
                    data[i] = (byte)((int)str[i] - 65 + 0x11);
                else if (str[i] == '.')
                    data[i] = 0x2b;
                else if (str[i] == '-')
                    data[i] = 0x2c;
                else if (str[i] == ' ')
                    data[i] = 0x10;
            }

            return data;
        }

        public int ByteArrayToLongScore(byte[] byteData)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < byteData.Length; i++)
            {
                byte[] newData = HiConvert.HexStringToByteArray(byteData[i].ToString("X2"));
                sb.Append(newData[0]);
            }

            return Int32.Parse(sb.ToString());
        }

        public byte[] LongScoreToByteArray(int score)
        {
            int bytesInScore = 6;
            StringBuilder sb = new StringBuilder();
            byte[] byteArray = new byte[bytesInScore];
            string scoreAsString = score.ToString().PadLeft(bytesInScore, '0');

            for (int i = 0; i < byteArray.Length; i++)
                sb.Append("0" + scoreAsString[i]);

            return HiConvert.HexStringToByteArray(sb.ToString());
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = System.Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2];

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = 6;
            if (score > ByteArrayToLongScore(hiscoreData.ScoreLong1))
                rank = 0;
            else if (score > ByteArrayToLongScore(hiscoreData.ScoreLong2))
                rank = 1;
            else if (score > ByteArrayToLongScore(hiscoreData.ScoreLong3))
                rank = 2;
            else if (score > ByteArrayToLongScore(hiscoreData.ScoreLong4))
                rank = 3;
            else if (score > ByteArrayToLongScore(hiscoreData.ScoreLong5))
                rank = 4;
            else if (score > ByteArrayToLongScore(hiscoreData.ScoreLong6))
                rank = 5;
            #endregion

            #region ADJUST
            int adjust = 5;
            if (rank < 5)
                adjust = 4;
            switch (adjust)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreLong2, hiscoreData.ScoreLong1);
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreShort2, hiscoreData.ScoreShort1);
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, hiscoreData.Name1);
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreLong3, hiscoreData.ScoreLong2);
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreShort3, hiscoreData.ScoreShort2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreLong4, hiscoreData.ScoreLong3);
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreShort4, hiscoreData.ScoreShort3);
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, hiscoreData.Name3);
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreLong5, hiscoreData.ScoreLong4);
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreShort5, hiscoreData.ScoreShort4);
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, hiscoreData.Name4);
                    if (rank < 3)
                        goto case 2;
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreLong6, hiscoreData.ScoreLong5);
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreShort6, hiscoreData.ScoreShort5);
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, hiscoreData.Name5);
                    if (rank < 4)
                        goto case 3;
                    break;
                default:
                    break;
            }
            #endregion

            #region REPLACE_NEW
            //NOTE: Rank is not saved, as it will always be the same.
            switch (rank)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreLong1, LongScoreToByteArray(score));
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreShort1, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreShort1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.HiScore, HiConvert.IntToByteArrayHex(score, hiscoreData.HiScore.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name1, StringToByteArray(name));
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreLong2, LongScoreToByteArray(score));
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreShort2, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreShort2.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name));
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreLong3, LongScoreToByteArray(score));
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreShort3, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreShort3.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name));
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreLong4, LongScoreToByteArray(score));
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreShort4, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreShort4.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name));
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreLong5, LongScoreToByteArray(score));
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreShort5, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreShort5.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name));
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreLong6, LongScoreToByteArray(score));
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreShort6, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreShort6.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, StringToByteArray(name));
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
            
            HiConvert.ByteArrayCopy(hiscoreData.ScoreLong1, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreLong1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreLong2, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreLong2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreLong3, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreLong3.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreLong4, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreLong4.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreLong5, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreLong5.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreLong6, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreLong6.Length));

            HiConvert.ByteArrayCopy(hiscoreData.ScoreShort1, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreShort1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreShort2, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreShort2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreShort3, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreShort3.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreShort4, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreShort4.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreShort5, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreShort5.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreShort6, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreShort6.Length));

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}|{1}|{2}", 1, ByteArrayToLongScore(hiscoreData.ScoreLong1), ByteArrayToString(hiscoreData.Name1)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 2, ByteArrayToLongScore(hiscoreData.ScoreLong2), ByteArrayToString(hiscoreData.Name2)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 3, ByteArrayToLongScore(hiscoreData.ScoreLong3), ByteArrayToString(hiscoreData.Name3)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 4, ByteArrayToLongScore(hiscoreData.ScoreLong4), ByteArrayToString(hiscoreData.Name4)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 5, ByteArrayToLongScore(hiscoreData.ScoreLong5), ByteArrayToString(hiscoreData.Name5)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 6, ByteArrayToLongScore(hiscoreData.ScoreLong6), ByteArrayToString(hiscoreData.Name6)) + Environment.NewLine;

            return retString;
        }
    }
}
