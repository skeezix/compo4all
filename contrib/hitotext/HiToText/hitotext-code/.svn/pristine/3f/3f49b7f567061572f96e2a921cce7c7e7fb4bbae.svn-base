using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class tron : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1284)]
            public byte[] UnusedA;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Name1;
            public byte Level1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Name2;
            public byte Level2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Name3;
            public byte Level3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Name4;
            public byte Level4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Name5;
            public byte Level5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Name6;
            public byte Level6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Name7;
            public byte Level7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Name8;
            public byte Level8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Name9;
            public byte Level9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Name10;
            public byte Level10;
            
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreTop;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] UnknownA11;
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

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 694)]
            public byte[] UnusedB;
        }

        public tron()
        {
            m_numEntries = 10;
            m_format = "RANK|SCORE|NAME|LEVEL";
            m_gamesSupported = "tron,tron2,tron3,tron4";
            m_extensionsRequired = ".nv";
        }

        public string ByteArrayToString(byte[] data)
        {
            return HiConvert.ByteArrayToString(data);
        }

        public byte[] StringToByteArray(string str)
        {
            byte[] data = new byte[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 'A' && str[i] <= 'Z' || str[i] == ' ')
                    data[i] = (byte)(str[i]);
            }

            return data;
        }

        public int ByteArrayToScore(byte[] data)
        {
            return HiConvert.ByteArrayHexToInt(data);
        }

        public byte[] ScoreToByteArray(int score, int numBytes)
        {
            return HiConvert.IntToByteArrayHex(score, numBytes);
        }

        public static void ByteArrayCopy(byte[] dest, byte[] src)
        {
            for (int i = 0; i < dest.Length; i++)
            {
                if (i < src.Length)
                    dest[i] = src[i];
                else
                {
                    dest[i] = 0x00;
                    dest[i + 1] = 0x00;
                    i++;
                }
            }
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2].PadRight(2, ' ').Substring(0, 2);
            int level = System.Convert.ToInt32(args[3]);

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
            int adjust = NumEntries - 1;
            if (rank < NumEntries - 1)
                adjust = NumEntries - 2;
            switch (adjust)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, hiscoreData.Score1);
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, hiscoreData.Name1);
                    hiscoreData.Level2 = hiscoreData.Level1;
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
                    hiscoreData.Level3 = hiscoreData.Level2;
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, hiscoreData.Score3);
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, hiscoreData.Name3);
                    hiscoreData.Level4 = hiscoreData.Level3;
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, hiscoreData.Score4);
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, hiscoreData.Name4);
                    hiscoreData.Level5 = hiscoreData.Level4;
                    if (rank < 3)
                        goto case 2;
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, hiscoreData.Score5);
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, hiscoreData.Name5);
                    hiscoreData.Level6 = hiscoreData.Level5;
                    if (rank < 4)
                        goto case 3;
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, hiscoreData.Score6);
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, hiscoreData.Name6);
                    hiscoreData.Level7 = hiscoreData.Level6;
                    if (rank < 5)
                        goto case 4;
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, hiscoreData.Score7);
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, hiscoreData.Name7);
                    hiscoreData.Level8 = hiscoreData.Level7;
                    if (rank < 6)
                        goto case 5;
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, hiscoreData.Score8);
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, hiscoreData.Name8);
                    hiscoreData.Level9 = hiscoreData.Level8;
                    if (rank < 7)
                        goto case 6;
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, hiscoreData.Score9);
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, hiscoreData.Name9);
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
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreTop, ScoreToByteArray(score, hiscoreData.ScoreTop.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, ScoreToByteArray(score, hiscoreData.Score1.Length));
                    hiscoreData.Level1 = (byte)level;
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, ScoreToByteArray(score, hiscoreData.Score2.Length));
                    hiscoreData.Level2 = (byte)level;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, ScoreToByteArray(score, hiscoreData.Score3.Length));
                    hiscoreData.Level3 = (byte)level;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, ScoreToByteArray(score, hiscoreData.Score4.Length));
                    hiscoreData.Level4 = (byte)level;
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, ScoreToByteArray(score, hiscoreData.Score5.Length));
                    hiscoreData.Level5 = (byte)level;
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, ScoreToByteArray(score, hiscoreData.Score6.Length));
                    hiscoreData.Level6 = (byte)level;
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, ScoreToByteArray(score, hiscoreData.Score7.Length));
                    hiscoreData.Level7 = (byte)level;
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, ScoreToByteArray(score, hiscoreData.Score8.Length));
                    hiscoreData.Level8 = (byte)level;
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, ScoreToByteArray(score, hiscoreData.Score9.Length));
                    hiscoreData.Level9 = (byte)level;
                    break;
                case 9:
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, ScoreToByteArray(score, hiscoreData.Score10.Length));
                    hiscoreData.Level10 = (byte)level;
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
            HiConvert.ByteArrayCopy(hiscoreData.Score9, ScoreToByteArray(0, hiscoreData.Score9.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score10, ScoreToByteArray(0, hiscoreData.Score10.Length));

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}|{1}|{2}|{3}", 1, ByteArrayToScore(hiscoreData.Score1), ByteArrayToString(hiscoreData.Name1), hiscoreData.Level1) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 2, ByteArrayToScore(hiscoreData.Score2), ByteArrayToString(hiscoreData.Name2), hiscoreData.Level2) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 3, ByteArrayToScore(hiscoreData.Score3), ByteArrayToString(hiscoreData.Name3), hiscoreData.Level3) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 4, ByteArrayToScore(hiscoreData.Score4), ByteArrayToString(hiscoreData.Name4), hiscoreData.Level4) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 5, ByteArrayToScore(hiscoreData.Score5), ByteArrayToString(hiscoreData.Name5), hiscoreData.Level5) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 6, ByteArrayToScore(hiscoreData.Score6), ByteArrayToString(hiscoreData.Name6), hiscoreData.Level6) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 7, ByteArrayToScore(hiscoreData.Score7), ByteArrayToString(hiscoreData.Name7), hiscoreData.Level7) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 8, ByteArrayToScore(hiscoreData.Score8), ByteArrayToString(hiscoreData.Name8), hiscoreData.Level8) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 9, ByteArrayToScore(hiscoreData.Score9), ByteArrayToString(hiscoreData.Name9), hiscoreData.Level9) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 10, ByteArrayToScore(hiscoreData.Score10), ByteArrayToString(hiscoreData.Name10), hiscoreData.Level10) + Environment.NewLine;

            return retString;
        }
    }
}