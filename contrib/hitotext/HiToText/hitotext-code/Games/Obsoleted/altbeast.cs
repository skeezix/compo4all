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
    class altbeast : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score1;
            public byte Round1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score2;
            public byte Round2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score3;
            public byte Round3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score4;
            public byte Round4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name4;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score5;
            public byte Round5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name5;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score6;
            public byte Round6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name6;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score7;
            public byte Round7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name7;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Unused1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] ScoreA1;
            public byte RoundA1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameA1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] ScoreA2;
            public byte RoundA2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameA2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] ScoreA3;
            public byte RoundA3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameA3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] ScoreA4;
            public byte RoundA4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameA4;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] ScoreA5;
            public byte RoundA5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameA5;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] ScoreA6;
            public byte RoundA6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameA6;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] ScoreA7;
            public byte RoundA7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameA7;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Unused2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] HiScore;
        }

        public TextParams tParams = new TextParams();

        public altbeast()
        {
            m_numEntries = 7;
            m_format = "RANK|SCORE|NAME|ROUND";
            m_gamesSupported = "altbeast,altbeas2,altbeaj3,altbeas4,altbeas5,altbeasj,altbeaj1";
            m_extensionsRequired = ".hi";

            tParams.Format = StringFormatFlag.ASCIIStandard;
        }

        public byte[] ConvertScore(string score)
        {
            return HiConvert.IntToByteArrayHex(Convert.ToInt32(score), 4);
        }

        public override void SetHiScore(string[] args)
        {
            //int rankGiven = System.Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2];
            int round = System.Convert.ToInt32(args[3]);

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));
            Regex rxScore = new Regex("^Score[1-7]$");
            Regex rxHiScore = new Regex("^HiScore$");
            Regex rxName = new Regex("^Name[1-7]$");
            Regex rxRound = new Regex("^Round[1-7]$");
            Regex rxScoreA = new Regex("^ScoreA[1-7]$");
            Regex rxNameA = new Regex("^NameA[1-7]$");
            Regex rxRoundA = new Regex("^RoundA[1-7]$");

            //Determining rank.
            int rank = HTTF.DetermineRank(score, rxScore, hiscoreData, HTTF.ByteArrayToInt.Standard);

            //Adjusting lower scores.
            List<Regex> adjusters = new List<Regex>(new Regex[] { rxScore, rxName, rxRound, rxScoreA, rxNameA, rxRoundA });
            hiscoreData = (HiscoreData)HTTF.AdjustScores(rank, hiscoreData, adjusters);

            //Replacing new scores.
            //Delegate creation.
            VBA dScore = SetScore.ConvertData(score, hiscoreData.Score1.Length, HiConvert.IntToByteArrayHex);

            //Placement creation.
            List<Placement> placements = new List<Placement>();
            placements.Add(new Placement(name, rxName, SetScore.ConvertName(tParams)));
            placements.Add(new Placement(name, rxNameA, SetScore.ConvertName(tParams)));
            placements.Add(new Placement(score.ToString(), rxScore, dScore));
            placements.Add(new Placement(score.ToString(), rxScoreA, dScore));
            placements.Add(new Placement(score.ToString(), rxHiScore, true, ConvertScore));
            placements.Add(new Placement(round.ToString(), rxRound, HTTF.ConvertValuesToBytes.ConvertByte));
            placements.Add(new Placement(round.ToString(), rxRoundA, HTTF.ConvertValuesToBytes.ConvertByte));

            hiscoreData = (HiscoreData)HTTF.ReplaceNew(rank, hiscoreData, placements);

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public void ModifyName(int rank, string name)
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            List<Placement> placements = new List<Placement>();
            placements.Add(new Placement(name, new Regex("^Name[1-7]$"), SetScore.ConvertName(tParams)));
            placements.Add(new Placement(name, new Regex("^NameA[1-7]$"), SetScore.ConvertName(tParams)));

            hiscoreData = (HiscoreData)HTTF.ReplaceNew(rank - 1, hiscoreData, placements);

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));
            VBA dScore = SetScore.ConvertData(0, hiscoreData.Score1.Length, HiConvert.IntToByteArrayHex);

            //We also want to get the top score and empty that.
            hiscoreData = (HiscoreData)HTTF.EmptyScores(hiscoreData, new Regex("^.*Score.*$"), dScore);

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
            formatting.Add(new DisplayData(new Regex("^Score[1-7]$"), HiToStr.Standard));
            formatting.Add(new DisplayData(new Regex("^Name[1-7]$"), HiToStr.ConvertName(tParams)));
            formatting.Add(new DisplayData(new Regex("^Round[1-7]$"), HiToStr.Standard));

            retString += HTTF.HiToString(hiscoreData, formatting);

            return retString;
        }
    }
}

