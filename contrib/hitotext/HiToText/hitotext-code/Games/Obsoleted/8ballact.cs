using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using System.Text.RegularExpressions;
using HTTF = HiToText.Formatting;
using VBA = HiToText.Formatting.ConvertValueToByteArray;
using SetScore = HiToText.Formatting.ConvertValuesToBytes;
using HiToStr = HiToText.Formatting.ConvertByteArraysToStrings;
using TextParams = HiToText.Utils.TextDecodingParameters;
using HiToText.Utils;

namespace HiGames
{
    class _8ballact : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Score1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Unused1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Score2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Unused2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Score3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Unused3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Score4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Unused4;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Score5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Unused5;
        }

        public TextParams tParams = new TextParams();

        public _8ballact()
        {
            m_numEntries = 5;
            m_format = "RANK|SCORE|NAME";
            m_gamesSupported = "8ballact,8ballact2,8ballat2,8bpm";
            m_extensionsRequired = ".hi";

            tParams.Format =
                StringFormatFlag.NeedsSpecialMapping |
                StringFormatFlag.ASCIIUpper;

            tParams.AddMapping(' ', 0x00);

            tParams.AddOffset(new Offset(0x01, Offset.FlagOffsets.Upper));
        }

        public string ConvertName(byte[] name)
        {
            return HTTF.ByteToString(name, tParams);
        }

        public string ConvertScoreDisplay(byte[] score)
        {
            return (ConvertScore(score) * 10).ToString();
        }

        public int ConvertScore(byte[] score)
        {
            int toReturn = 0;
            for (int i = 0; i < score.Length; i++)
            {
                if (score[i] == 0x1c)
                    toReturn += (int)Math.Pow(10.0, (double)(score.Length - i - 1));
                else if (score[i] == 0x1d)
                    toReturn += ((int)Math.Pow(10.0, (double)(score.Length - i - 1))) * 2;
                else if (score[i] == 0x1e)
                    toReturn += ((int)Math.Pow(10.0, (double)(score.Length - i - 1))) * 3;
                else if (score[i] == 0x1f)
                    toReturn += ((int)Math.Pow(10.0, (double)(score.Length - i - 1))) * 4;
                else if (score[i] == 0x20)
                    toReturn += ((int)Math.Pow(10.0, (double)(score.Length - i - 1))) * 5;
                else if (score[i] == 0x21)
                    toReturn += ((int)Math.Pow(10.0, (double)(score.Length - i - 1))) * 6;
                else if (score[i] == 0x22)
                    toReturn += ((int)Math.Pow(10.0, (double)(score.Length - i - 1))) * 7;
                else if (score[i] == 0x23)
                    toReturn += ((int)Math.Pow(10.0, (double)(score.Length - i - 1))) * 8;
                else if (score[i] == 0x24)
                    toReturn += ((int)Math.Pow(10.0, (double)(score.Length - i - 1))) * 9;
            }

            return toReturn;
        }

        public byte[] ConvertName(string name)
        {
            return HTTF.StringToByte(name, tParams);
        }

        public byte[] ConvertScore(string score)
        {
            byte[] toReturn = new byte[6];
            string scoreStr = score.PadLeft(toReturn.Length, '0');
            bool isPad = true;
            for (int i = 0; i < scoreStr.Length; i++)
            {
                if (scoreStr[i].Equals('0') && isPad)
                    toReturn[i] = 0x00;
                else if (scoreStr[i].Equals('0') && !isPad)
                    toReturn[i] = 0x1b;
                else if (scoreStr[i].Equals('1'))
                {
                    toReturn[i] = 0x1c;
                    isPad = false;
                }
                else if (scoreStr[i].Equals('2'))
                {
                    toReturn[i] = 0x1d;
                    isPad = false;
                }
                else if (scoreStr[i].Equals('3'))
                {
                    toReturn[i] = 0x1e;
                    isPad = false;
                }
                else if (scoreStr[i].Equals('4'))
                {
                    toReturn[i] = 0x1f;
                    isPad = false;
                }
                else if (scoreStr[i].Equals('5'))
                {
                    toReturn[i] = 0x20;
                    isPad = false;
                }
                else if (scoreStr[i].Equals('6'))
                {
                    toReturn[i] = 0x21;
                    isPad = false;
                }
                else if (scoreStr[i].Equals('7'))
                {
                    toReturn[i] = 0x22;
                    isPad = false;
                }
                else if (scoreStr[i].Equals('8'))
                {
                    toReturn[i] = 0x23;
                    isPad = false;
                }
                else if (scoreStr[i].Equals('9'))
                {
                    toReturn[i] = 0x24;
                    isPad = false;
                }
            }
            return toReturn;
        }

        public override void SetHiScore(string[] args)
        {
            //int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]) / 10;
            string name = args[2];

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));
            Regex rxScore = new Regex("^Score.*$");
            Regex rxName = new Regex("^Name.*$");

            //Determining rank.
            int rank = HTTF.DetermineRank(score, rxScore, hiscoreData, ConvertScore);

            //Adjusting lower scores.
            List<Regex> adjusters = new List<Regex>(new Regex[] { rxScore, rxName });
            hiscoreData = (HiscoreData)HTTF.AdjustScores(rank, hiscoreData, adjusters);

            //Replacing new scores.
            List<Placement> placements = new List<Placement>();
            placements.Add(new Placement(name, rxName, ConvertName));
            placements.Add(new Placement(score.ToString(), rxScore, ConvertScore));

            hiscoreData = (HiscoreData)HTTF.ReplaceNew(rank, hiscoreData, placements);

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public void ModifyName(int rank, string name)
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            List<Placement> placements = new List<Placement>();
            placements.Add(new Placement(name, new Regex("^Name.*$"), ConvertName));

            hiscoreData = (HiscoreData)HTTF.ReplaceNew(rank - 1, hiscoreData, placements);

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            hiscoreData = (HiscoreData)HTTF.EmptyScores(hiscoreData, new Regex("^Score.*$"), ConvertScore);

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            List<DisplayData> formatting = new List<DisplayData>();
            formatting.Add(new DisplayData(null, DisplayData.CannedDisplay.AscendingFrom1));
            formatting.Add(new DisplayData(new Regex("^Score.*$"), ConvertScoreDisplay));
            formatting.Add(new DisplayData(new Regex("^Name.*$"), ConvertName));

            retString += HTTF.HiToString(hiscoreData, formatting);

            return retString;
        }
    }
}