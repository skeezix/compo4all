using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class defender : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 29)]
            public byte[] UnusedA;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Score1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name1;
            
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Score2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Score3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Score4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name4;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Score5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name5;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Score6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name6;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Score7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name7;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Score8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name8;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 131)]
            public byte[] UnusedB;
        }

        public defender()
        {
            m_numEntries = 8;
            m_format = "RANK|SCORE|NAME";
            m_gamesSupported = "defender,defence,defendb,defndjeu,defendg,defendw,defcmnd,startrkd,tornado1,tornado2,zero,zero2";
            m_extensionsRequired = ".nv";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            String tmp = HiConvert.ByteArrayToHexString(data);

            for (int i = 0; i < data.Length / 2; i++)
                sb.Append((char)Convert.ToInt32("0x" + tmp.Substring((i * 4) + 1, 1) + tmp.Substring((i * 4) + 3, 1), 16));
            
            return sb.ToString();
        }

        public byte[] StringToByteArray(string str)
        {
            byte[] data = new byte[str.Length * 2];

            int val = 78;
            String tmp = val.ToString("X2");

            for (int i = 0; i < str.Length; i++)
            {
                data[i * 2] = Byte.Parse("F" + ((int)str[i]).ToString("X2").Substring(0, 1), System.Globalization.NumberStyles.AllowHexSpecifier);
                data[(i * 2) + 1] = Byte.Parse("F" + ((int)str[i]).ToString("X2").Substring(1, 1), System.Globalization.NumberStyles.AllowHexSpecifier);
            }

            return data;
        }

        public int ByteArrayToScore(byte[] data)
        {
            int score = 0;
            
            for (int i = 0; i < data.Length; i++)
                score += ((int)(data[i] - 0xF0)) * Convert.ToInt32(Math.Pow(10, ((data.Length - i) - 1)));

            return score;
        }

        public byte[] ScoreToByteArray(int score, int numBytes)
        {
            string scoreAsStr = score.ToString().PadLeft(numBytes,'0');
            byte[] data = new byte[scoreAsStr.Length];

            for (int i = 0; i < data.Length; i++)
                data[i] = Convert.ToByte(0xF0 + Convert.ToByte(scoreAsStr.Substring(i, 1)));

            return data;
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2];

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = 8;
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
            #endregion

            #region ADJUST
            int adjust = 7;
            if (rank < 7)
                adjust = 6;
            switch (adjust)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, hiscoreData.Score1);
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, hiscoreData.Name1);
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, hiscoreData.Score3);
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, hiscoreData.Name3);
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, hiscoreData.Score4);
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, hiscoreData.Name4);
                    if (rank < 3)
                        goto case 2;
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, hiscoreData.Score5);
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, hiscoreData.Name5);
                    if (rank < 4)
                        goto case 3;
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, hiscoreData.Score6);
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, hiscoreData.Name6);
                    if (rank < 5)
                        goto case 4;
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, hiscoreData.Score7);
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, hiscoreData.Name7);
                    if (rank < 6)
                        goto case 5;
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
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, ScoreToByteArray(score, hiscoreData.Score1.Length));
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, ScoreToByteArray(score, hiscoreData.Score2.Length));
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, ScoreToByteArray(score, hiscoreData.Score3.Length));
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, ScoreToByteArray(score, hiscoreData.Score4.Length));
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, ScoreToByteArray(score, hiscoreData.Score5.Length));
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, ScoreToByteArray(score, hiscoreData.Score6.Length));
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, ScoreToByteArray(score, hiscoreData.Score7.Length));
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, ScoreToByteArray(score, hiscoreData.Score8.Length));
                    break;
            }
            #endregion

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.Score1, ScoreToByteArray(0, hiscoreData.Score1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score2, ScoreToByteArray(0, hiscoreData.Score2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score3, ScoreToByteArray(0, hiscoreData.Score3.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score4, ScoreToByteArray(0, hiscoreData.Score4.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score5, ScoreToByteArray(0, hiscoreData.Score5.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score6, ScoreToByteArray(0, hiscoreData.Score6.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score7, ScoreToByteArray(0, hiscoreData.Score7.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score8, ScoreToByteArray(0, hiscoreData.Score8.Length));

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

            return retString;
        }
    }
}