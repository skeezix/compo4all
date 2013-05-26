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
    class baddudes : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Stage1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Stage2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Stage3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Stage4;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Stage5;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Stage6;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Stage7;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Stage8;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Stage9;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Stage10;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name11;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score11;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Stage11;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name12;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score12;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Stage12;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name13;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score13;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Stage13;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name14;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score14;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Stage14;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name15;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score15;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Stage15;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name16;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score16;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Stage16;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name17;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score17;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Stage17;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name18;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score18;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Stage18;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name19;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score19;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Stage19;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name20;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score20;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Stage20;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] HiScore;
        }

        public TextParams tParams = new TextParams();

        public baddudes()
        {
            m_numEntries = 20;
            m_format = "RANK|SCORE|NAME|STAGE";
            m_gamesSupported = "baddudes,drgninja";
            m_extensionsRequired = ".hi";

            tParams.Format = StringFormatFlag.ASCIIStandard;
        }

        public override void SetHiScore(string[] args)
        {
            //int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2].PadRight(3, ' ').Substring(0, 3);
            int stage = System.Convert.ToInt32(args[3]);

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));
            Regex rxScore = new Regex("^Score.*$");
            Regex rxName = new Regex("^Name.*$");
            Regex rxStage = new Regex("^Stage.*$");
            Regex rxHiScore = new Regex("^HiScore$");

            //Determining rank.
            int rank = HTTF.DetermineRank(score, rxScore, hiscoreData, HTTF.ByteArrayToInt.Standard);

            //Adjusting lower scores.
            List<Regex> adjusters = new List<Regex>(new Regex[] { rxScore, rxName, rxStage });
            hiscoreData = (HiscoreData)HTTF.AdjustScores(rank, hiscoreData, adjusters);

            //Replacing new scores.
            //Delegate creation.
            VBA dScore = SetScore.ConvertData(score, hiscoreData.Score1.Length, HiConvert.IntToByteArrayHex);
            VBA dStage = SetScore.ConvertData(stage, hiscoreData.Stage1.Length, HiConvert.IntToByteArrayHex);

            //Placement creation.
            List<Placement> placements = new List<Placement>();
            placements.Add(new Placement(name, rxName, SetScore.ConvertName(tParams)));
            placements.Add(new Placement(score.ToString(), rxScore, dScore));
            placements.Add(new Placement(score.ToString(), rxHiScore, true, dScore));
            placements.Add(new Placement(stage.ToString(), rxStage, dStage));

            hiscoreData = (HiscoreData)HTTF.ReplaceNew(rank, hiscoreData, placements);

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public void ModifyName(int rank, string name)
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            List<Placement> placements = new List<Placement>();
            placements.Add(new Placement(name, new Regex("^Name.*$"), SetScore.ConvertName(tParams)));

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
            formatting.Add(new DisplayData(new Regex("^Score.*$"), HiToStr.Standard));
            formatting.Add(new DisplayData(new Regex("^Name.*$"), HiToStr.ConvertName(tParams)));
            formatting.Add(new DisplayData(new Regex("^Stage.*$"), HiToStr.Standard));

            retString += HTTF.HiToString(hiscoreData, formatting);

            return retString;
        }
    }
}