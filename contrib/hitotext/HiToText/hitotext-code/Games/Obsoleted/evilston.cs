using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;
using System.Text.RegularExpressions;
using HTTF = HiToText.Formatting;
using VBA = HiToText.Formatting.ConvertValueToByteArray;
using SetScore = HiToText.Formatting.ConvertValuesToBytes;
using HiToStr = HiToText.Formatting.ConvertByteArraysToStrings;
using TextParams = HiToText.Utils.TextDecodingParameters;

namespace HiGames
{
    class evilston : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {            
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Stage1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Stage2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Stage3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Stage4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name4;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Stage5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name5;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Stage6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name6;          

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] HiScore;
        }

        public TextParams tParams = new TextParams();

        public evilston()
        {
            // Max. score: 999,999
            m_numEntries = 6;
            m_format = "RANK|SCORE|NAME|STAGE";
            m_gamesSupported = "evilston";
            m_extensionsRequired = ".hi";
            tParams.Format = StringFormatFlag.ASCIIStandard;
        }

        public string ConvertName(byte[] name)
        {
            return HTTF.ByteToString(name, tParams);
        }

        public byte[] ConvertName(string name)
        {
            return HTTF.StringToByte(name, tParams);
        }

        public byte[] ConvertScore(string score)
        {
            return HiConvert.IntToByteArrayHex(Convert.ToInt32(score), 3);
        }

        public byte[] ConvertStage(string stage)
        {
            return HiConvert.IntToByteArrayHex(Convert.ToInt32(stage), 1);
        }


        public override void SetHiScore(string[] args)
        {
            //int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2].ToUpper().PadRight(6, ' ').Substring(0, 6);
            int stage = System.Convert.ToInt32(args[3]);

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));
            Regex rxScore = new Regex("^Score.*$");
            Regex rxName = new Regex("^Name.*$");
            Regex rxStage = new Regex("^Stage.*$");
            
            //Determining rank.
            int rank = HTTF.DetermineRank(score, rxScore, hiscoreData, HTTF.ByteArrayToInt.Standard);          
    
            //Adjusting lower scores.
            List<Regex> adjusters = new List<Regex>(new Regex[] { rxScore, rxStage, rxName });
            hiscoreData = (HiscoreData)HTTF.AdjustScores(rank, hiscoreData, adjusters);

            //Replacing new scores.
            List<Placement> placements = new List<Placement>();
            placements.Add(new Placement(score.ToString(), rxScore, ConvertScore));
            placements.Add(new Placement(stage.ToString(), rxStage, ConvertStage));
            placements.Add(new Placement(name, rxName, ConvertName));
            placements.Add(new Placement(score.ToString(), new Regex("^HiScore$"), true, ConvertScore));

            hiscoreData = (HiscoreData)HTTF.ReplaceNew(rank, hiscoreData, placements);

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void ModifyName(int rank, string name)
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

            //We also want to get the top score and empty that, is present.-------------|
            hiscoreData = (HiscoreData)HTTF.EmptyScores(hiscoreData, new Regex("^.*Score.*$"), ConvertScore);

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
            formatting.Add(new DisplayData(new Regex("^Name.*$"), ConvertName));
            formatting.Add(new DisplayData(new Regex("^Stage.*$"), HiToStr.Standard));

            retString += HTTF.HiToString(hiscoreData, formatting);

            return retString;
        }
    }
}