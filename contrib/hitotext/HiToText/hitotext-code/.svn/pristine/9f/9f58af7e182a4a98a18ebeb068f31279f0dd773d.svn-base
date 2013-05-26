using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class srumbler : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] NameA;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] NameB;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] NameC;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] NameD;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] NameE;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] NameF;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] NameG;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 14)]
            public byte[] NameRanks;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] ScoreA;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] ScoreB;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] ScoreC;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] ScoreD;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] ScoreE;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] ScoreF;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] ScoreG;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 14)]
            public byte[] ScoreRanks;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] HiScore;
        }

        public srumbler()
        {
            m_numEntries = 7;
            m_format = "RANK|SCORE|NAME";
            m_gamesSupported = "srumbler,srumblr2,rushcrsh";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                //TODO: Lower case letters are just replacements for unknown characters in the table.
                if (data[i] == 0x3a)
                    sb.Append('a');
                else if (data[i] == 0x3b)
                    sb.Append('b');
                else if (data[i] == 0x3c)
                    sb.Append('c');
                else if (data[i] == 0x3e)
                    sb.Append('d');
                else if (data[i] == 0x5b)
                    sb.Append('.');
                else if (data[i] == 0x5c)
                    sb.Append('-');
                else if (data[i] == 0x5d)
                    sb.Append('e');
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
                if (str[i] == 'a')
                    data[i] = 0x3a;
                else if (str[i] == 'b')
                    data[i] = 0x3b;
                else if (str[i] == 'c')
                    data[i] = 0x3c;
                else if (str[i] == 'd')
                    data[i] = 0x3e;
                else if (str[i] == '.')
                    data[i] = 0x5b;
                else if (str[i] == '-')
                    data[i] = 0x5c;
                else if (str[i] == 'e')
                    data[i] = 0x5d;
                else
                    data[i] = (byte)((int)str[i]);
            }

            return data;
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2];

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE POINTERS
            List<byte[]> Scores = new List<byte[]>();
            List<byte[]> Names = new List<byte[]>();

            byte rankLast;

            for (int i = 0; i < NumEntries; i++)
            {
                int rankPointer = Convert.ToInt32(hiscoreData.ScoreRanks[(i * 2) + 1]);
                switch (rankPointer)
                {
                    case 0xf2:
                        Scores.Add(hiscoreData.ScoreG);
                        Names.Add(hiscoreData.NameG);
                        break;
                    case 0xee:
                        Scores.Add(hiscoreData.ScoreF);
                        Names.Add(hiscoreData.NameF);
                        break;
                    case 0xea:
                        Scores.Add(hiscoreData.ScoreE);
                        Names.Add(hiscoreData.NameE);
                        break;
                    case 0xe6:
                        Scores.Add(hiscoreData.ScoreD);
                        Names.Add(hiscoreData.NameD);
                        break;
                    case 0xe2:
                        Scores.Add(hiscoreData.ScoreC);
                        Names.Add(hiscoreData.NameC);
                        break;
                    case 0xde:
                        Scores.Add(hiscoreData.ScoreB);
                        Names.Add(hiscoreData.NameB);
                        break;
                    case 0xda:
                        Scores.Add(hiscoreData.ScoreA);
                        Names.Add(hiscoreData.NameA);
                        break;
                    default:
                        break;
                }
            }

            #endregion

            #region DETERMINE RANK
            int rank = NumEntries;
            for (int i = 0; i < NumEntries; i++)
            {
                if (score > HiConvert.ByteArrayHexToInt(Scores[i]))
                {
                    rank = i;
                    break;
                }
            }
            rankLast = hiscoreData.ScoreRanks[13];
            #endregion

            #region ADJUST
            int adjust = NumEntries - 1;
            if (rank < NumEntries - 1)
                adjust = NumEntries - 2;
            switch (adjust)
            {
                case 0:
                    hiscoreData.ScoreRanks[3] = hiscoreData.ScoreRanks[1];
                    hiscoreData.NameRanks[3] = hiscoreData.NameRanks[1];
                    break;
                case 1:
                    hiscoreData.ScoreRanks[5] = hiscoreData.ScoreRanks[3];
                    hiscoreData.NameRanks[5] = hiscoreData.NameRanks[3];
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    hiscoreData.ScoreRanks[7] = hiscoreData.ScoreRanks[5];
                    hiscoreData.NameRanks[7] = hiscoreData.NameRanks[5];
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    hiscoreData.ScoreRanks[9] = hiscoreData.ScoreRanks[7];
                    hiscoreData.NameRanks[9] = hiscoreData.NameRanks[7];
                    if (rank < 3)
                        goto case 2;
                    break;
                case 4:
                    hiscoreData.ScoreRanks[11] = hiscoreData.ScoreRanks[9];
                    hiscoreData.NameRanks[13] = hiscoreData.NameRanks[9];
                    if (rank < 4)
                        goto case 3;
                    break;
                case 5:
                    hiscoreData.ScoreRanks[13] = hiscoreData.ScoreRanks[11];
                    hiscoreData.NameRanks[13] = hiscoreData.NameRanks[11];
                    if (rank < 5)
                        goto case 4;
                    break;
                default:
                    break;
            }
            #endregion

            #region REPLACE_NEW
            if (rank < NumEntries)
            {
                HiConvert.ByteArrayCopy(Names[NumEntries - 1], StringToByteArray(name));
                HiConvert.ByteArrayCopy(Scores[NumEntries - 1], HiConvert.IntToByteArrayHex(score, Scores[NumEntries - 1].Length));

                hiscoreData.ScoreRanks[(rank * 2) + 1] = rankLast;
                hiscoreData.NameRanks[(rank * 2) + 1] = rankLast;

                if (rank == 0)
                    HiConvert.ByteArrayCopy(hiscoreData.HiScore, HiConvert.IntToByteArrayHex(score, hiscoreData.HiScore.Length));
            }
            #endregion

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.ScoreA, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreA.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreB, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreB.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreC, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreC.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreD, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreD.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreE, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreE.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreF, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreF.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreG, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreG.Length));

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            for (int i = 0; i < NumEntries; i++)
            {
                int rankPointer = Convert.ToInt32(hiscoreData.ScoreRanks[(i * 2) + 1]);
                switch (rankPointer)
                {
                    case 0xf2:
                        retString += String.Format(
                            "{0}|{1}|{2}",
                            i + 1,
                            HiConvert.ByteArrayHexToInt(hiscoreData.ScoreG),
                            ByteArrayToString(hiscoreData.NameG)) + Environment.NewLine;
                        break;
                    case 0xee:
                        retString += String.Format(
                            "{0}|{1}|{2}",
                            i + 1,
                            HiConvert.ByteArrayHexToInt(hiscoreData.ScoreF),
                            ByteArrayToString(hiscoreData.NameF)) + Environment.NewLine;
                        break;
                    case 0xea:
                        retString += String.Format(
                            "{0}|{1}|{2}",
                            i + 1,
                            HiConvert.ByteArrayHexToInt(hiscoreData.ScoreE),
                            ByteArrayToString(hiscoreData.NameE)) + Environment.NewLine;
                        break;
                    case 0xe6:
                        retString += String.Format(
                            "{0}|{1}|{2}",
                            i + 1,
                            HiConvert.ByteArrayHexToInt(hiscoreData.ScoreD),
                            ByteArrayToString(hiscoreData.NameD)) + Environment.NewLine;
                        break;
                    case 0xe2:
                        retString += String.Format(
                            "{0}|{1}|{2}",
                            i + 1,
                            HiConvert.ByteArrayHexToInt(hiscoreData.ScoreC),
                            ByteArrayToString(hiscoreData.NameC)) + Environment.NewLine;
                        break;
                    case 0xde:
                        retString += String.Format(
                            "{0}|{1}|{2}",
                            i + 1,
                            HiConvert.ByteArrayHexToInt(hiscoreData.ScoreB),
                            ByteArrayToString(hiscoreData.NameB)) + Environment.NewLine;
                        break;
                    case 0xda:
                        retString += String.Format(
                            "{0}|{1}|{2}",
                            i + 1,
                            HiConvert.ByteArrayHexToInt(hiscoreData.ScoreA),
                            ByteArrayToString(hiscoreData.NameA)) + Environment.NewLine;
                        break;
                    default:
                        break;
                }
            }

            return retString;
        }
    }
}

