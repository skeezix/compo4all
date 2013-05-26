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
    class hyperspt : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct AlternateData
        {
            //Triple Jump World Records.
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] TripleJumpScore1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] TripleJumpName1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] TripleJumpScore2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] TripleJumpName2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] TripleJumpScore3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] TripleJumpName3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] TripleJumpScore4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] TripleJumpName4;

            //Skeet Shooting World Records.
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] SkeetScore1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] SkeetName1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] SkeetScore2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] SkeetName2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] SkeetScore3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] SkeetName3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] SkeetScore4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] SkeetName4;

            //Pole Vault World Records.
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] PoleVaultScore1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] PoleVaultName1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] PoleVaultScore2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] PoleVaultName2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] PoleVaultScore3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] PoleVaultName3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] PoleVaultScore4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] PoleVaultName4;

            //Free Style World Records.
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] FreeStyleScore1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] FreeStyleName1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] FreeStyleScore2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] FreeStyleName2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] FreeStyleScore3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] FreeStyleName3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] FreeStyleScore4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] FreeStyleName4;

            //Weight Lifting World Records.
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] WeightLiftingScore1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] WeightLiftingName1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] WeightLiftingScore2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] WeightLiftingName2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] WeightLiftingScore3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] WeightLiftingName3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] WeightLiftingScore4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] WeightLiftingName4;

            //Archery World Records.
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] ArcheryScore1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ArcheryName1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] ArcheryScore2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ArcheryName2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] ArcheryScore3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ArcheryName3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] ArcheryScore4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ArcheryName4;

            //Long Horse World Records.
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] LongHorseScore1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] LongHorseName1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] LongHorseScore2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] LongHorseName2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] LongHorseScore3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] LongHorseName3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] LongHorseScore4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] LongHorseName4;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Padding;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] HiScore1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] HiName1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] HiScore2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] HiName2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] HiScore3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] HiName3;
        }

        public TextParams tParams = new TextParams();

        public hyperspt()
        {
            m_numEntries = 20;
            m_format = "RANK|SCORE|NAME";
            m_altFormat = new string[7];
            m_altFormat[0] = "FREE STYLE WORLD RECORD" + Environment.NewLine + "RANK|TIME|NAME";
            m_altFormat[1] = "SKEET SHOOTING WORLD RECORD" + Environment.NewLine + "RANK|SCORE|NAME";
            m_altFormat[2] = "LONG HORSE WORLD RECORD" + Environment.NewLine + "RANK|SCORE|NAME";
            m_altFormat[3] = "ARCHERY WORLD RECORD" + Environment.NewLine + "RANK|SCORE|NAME";
            m_altFormat[4] = "TRIPLE JUMP WORLD RECORD" + Environment.NewLine + "RANK|DISTANCE|NAME";
            m_altFormat[5] = "WEIGHT LIFTING WORLD RECORD" + Environment.NewLine + "RANK|WEIGHT|NAME";
            m_altFormat[6] = "POLE VAULT WORLD RECORD" + Environment.NewLine + "RANK|HEIGHT|NAME";
            m_numAltEntries = new int[] { 3, 3, 3, 3, 3, 3, 3 };
            m_gamesSupported = "hyperspt,hpolym84";
            m_extensionsRequired = ".nv";

            tParams.Format =
                StringFormatFlag.NeedsSpecialMapping |
                StringFormatFlag.ASCIIUpper;

            tParams.AddMapping('.', 0x2b);
            tParams.AddMapping(' ', 0x10);
            tParams.AddMapping(' ', 0x00);

            tParams.AddOffset(new Offset(0x11, Offset.FlagOffsets.Upper));
        }

        private int GetAlternateName(string altName)
        {
            switch (altName)
            {
                case "FREE STYLE WORLD RECORD":
                    return 0;
                case "SKEET SHOOTING WORLD RECORD":
                    return 1;
                case "LONG HORSE WORLD RECORD":
                    return 2;
                case "ARCHERY WORLD RECORD":
                    return 3;
                case "TRIPLE JUMP WORLD RECORD":
                    return 4;
                case "WEIGHT LIFTING WORLD RECORD":
                    return 5;
                case "POLE VAULT WORLD RECORD":
                    return 6;
            }
            return -1;
        }

        public byte[] ConvertName(string name)
        {
            return HTTF.StringToByte(name, tParams);
        }

        public byte[] ConvertAltScore(string score)
        {
            return HiConvert.IntToByteArraySingleBCD(Convert.ToInt32(score), 5);
        }

        public byte[] ConvertScore(string score)
        {
            return HiConvert.IntToByteArrayHex(Convert.ToInt32(score), 3);
        }

        public string ConvertName(byte[] name)
        {
            return HTTF.ByteToString(name, tParams);
        }

        private string FormatAsDistance(byte[] scoreByte)
        {
            int score = HiConvert.ByteArraySingleBCDToInt(scoreByte);
            if (score == 0)
                return "0.00m";
            string centimeters = score.ToString().Substring(score.ToString().Length - 2);
            return (score.ToString().Substring(0, score.ToString().Length - centimeters.Length) + "." + centimeters + "m").PadLeft(5, '0');
        }

        private string FormatAsTime(byte[] scoreByte)
        {
            int score = HiConvert.ByteArraySingleBCDToInt(scoreByte);
            if (score == 0)
                return "0.00sec";
            string millseconds = score.ToString().Substring(score.ToString().Length - 2);
            return (score.ToString().Substring(0, score.ToString().Length - millseconds.Length) + "sec" + millseconds).PadLeft(6, '0');
        }

        private string FormatAsWeight(byte[] scoreByte)
        {
            int score = HiConvert.ByteArraySingleBCDToInt(scoreByte);
            if (score == 0)
                return "0kg";
            string kilos = score.ToString().Substring(score.ToString().Length - 1);
            return (score.ToString().Substring(0, score.ToString().Length - kilos.Length) + "kg");
        }

        private string FormatAs10Score(byte[] scoreByte)
        {
            int score = HiConvert.ByteArraySingleBCDToInt(scoreByte);
            if (score == 0)
                return "0.00";
            string _10score = score.ToString().Substring(score.ToString().Length - 2);
            return (score.ToString().Substring(0, score.ToString().Length - _10score.Length) + "." + _10score);
        }

        private int FormatFromDistance(string score)
        {
            return Convert.ToInt32(score.Replace("m", "").Replace(".", ""));
        }

        private int FormatFromTime(string score)
        {
            return Convert.ToInt32(score.Replace("sec", "").Replace(".", ""));
        }

        private int FormatFromWeight(string score)
        {
            return Convert.ToInt32(score.Replace("kg", ""));
        }

        private int FormatFrom10Score(string score)
        {
            return Convert.ToInt32(score.Replace(".", ""));
        }

        public override void SetHiScore(string[] args)
        {
            //int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]) / 10;
            string name = args[2];

            int rank = NumEntries;
            int offset;

            HiscoreData hiscoreData = new HiscoreData();
            //Do not change the below.
            hiscoreData.Score = HiConvert.IntToByteArrayHex(score, 3);
            hiscoreData.Name = ConvertName(name);
            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            #region DETERMINE RANK
            for (int i = 0; i < NumEntries; i++)
            {
                offset = Marshal.SizeOf(typeof(AlternateData)) + (i * Marshal.SizeOf(typeof(HiscoreData)));
                byte[] tmp = { m_data[offset], m_data[offset + 1], m_data[offset + 2] };

                int scoreToCompare = HiConvert.ByteArrayHexToInt(tmp);
                if (score > scoreToCompare)
                {
                    rank = i;
                    break;
                }
            }
            #endregion

            #region ADJUST
            int adjust = -1;
            if (rank < NumEntries - 1)
                adjust = NumEntries - 2;
            for (int i = adjust; i >= 0; i--)
            {
                if (rank > i)
                    break;

                int offsetOldLoc = Marshal.SizeOf(typeof(AlternateData)) + (i * Marshal.SizeOf(typeof(HiscoreData)));
                int offsetNewLoc = Marshal.SizeOf(typeof(AlternateData)) + ((i + 1) * Marshal.SizeOf(typeof(HiscoreData)));

                for (int j = 0; j < byteArray.Length; j++)
                    m_data[offsetNewLoc + j] = m_data[offsetOldLoc + j];
            }

            #endregion

            #region REPLACE NEW
            if (rank < NumEntries)
            {
                offset = Marshal.SizeOf(typeof(AlternateData)) + (rank * Marshal.SizeOf(typeof(HiscoreData)));

                for (int i = 0; i < byteArray.Length; i++)
                    m_data[offset + i] = byteArray[i];

                if (rank < 2)
                {
                    byte[] altArea = new byte[Marshal.SizeOf(typeof(AlternateData))];
                    for (int i = 0; i < altArea.Length; i++)
                        altArea[i] = m_data[i];
                    AlternateData altData = (AlternateData)HiConvert.RawDeserialize(altArea, 0, typeof(AlternateData));

                    if (rank == 0)
                    {
                        altData.HiScore1 = HiConvert.IntToByteArrayHex(score, 3);
                        altData.HiName1 = HTTF.StringToByte(name, tParams);
                    }
                    else if (rank == 1)
                    {
                        altData.HiScore2 = HiConvert.IntToByteArrayHex(score, 3);
                        altData.HiName2 = HTTF.StringToByte(name, tParams);
                    }
                    else if (rank == 2)
                    {
                        altData.HiScore3 = HiConvert.IntToByteArrayHex(score, 3);
                        altData.HiName3 = HTTF.StringToByte(name, tParams);
                    }

                    byte[] newByteArray = new byte[m_data.Length];
                    byte[] scoreArray = HiConvert.RawSerialize(altData);

                    for (int i = 0; i < newByteArray.Length; i++)
                    {
                        if (i < scoreArray.Length)
                            newByteArray[i] = scoreArray[i];
                        else
                            newByteArray[i] = m_data[i];
                    }

                    HiConvert.ByteArrayCopy(m_data, newByteArray);
                }
            }
            #endregion
        }

        public override void SetAlternateScore(string[] args)
        {
            int alternateName = GetAlternateName(args[0]);
            //int rankGiven = Convert.ToInt32(args[1]);
            int score = 0;
            switch (alternateName)
            {
                case 0:
                    score = FormatFromTime(args[2]);
                    if (score == 0)
                        score = 9999;
                    break;
                case 1:
                case 3:
                    score = Convert.ToInt32(args[2]);
                    break;
                case 2:
                    score = FormatFrom10Score(args[2]);
                    break;
                case 4:
                case 6:
                    score = FormatFromDistance(args[2]);
                    break;
                case 5:
                    score = FormatFromWeight(args[2]);
                    break;
            }
            string name = args[3];

            byte[] altArea = new byte[Marshal.SizeOf(typeof(AlternateData))];
            for (int i = 0; i < altArea.Length; i++)
                altArea[i] = m_data[i];
            AlternateData hiscoreData = (AlternateData)HiConvert.RawDeserialize(altArea, 0, typeof(AlternateData));

            #region DETERMINE_RANK
            int rank = NumAltEntries[alternateName];
            switch (alternateName)
            {
                case 0:
                    rank = HTTF.DetermineRank(-score, new Regex("^FreeStyleScore.*$"),
                        hiscoreData, HTTF.ByteArrayToInt.InverseBCD);
                    break;
                case 1:
                    rank = HTTF.DetermineRank(score, new Regex("^SkeetScore.*$"),
                        hiscoreData, HTTF.ByteArrayToInt.BCD);
                    break;
                case 2:
                    rank = HTTF.DetermineRank(score, new Regex("^LongHorseScore.*$"),
                        hiscoreData, HTTF.ByteArrayToInt.BCD);
                    break;
                case 3:
                    rank = HTTF.DetermineRank(score, new Regex("^ArcheryScore.*$"),
                        hiscoreData, HTTF.ByteArrayToInt.BCD);
                    break;
                case 4:
                    rank = HTTF.DetermineRank(score, new Regex("^TripleJumpScore.*$"),
                        hiscoreData, HTTF.ByteArrayToInt.BCD);
                    break;
                case 5:
                    rank = HTTF.DetermineRank(score, new Regex("^WeightLiftingScore.*$"),
                        hiscoreData, HTTF.ByteArrayToInt.BCD);
                    break;
                case 6:
                    rank = HTTF.DetermineRank(score, new Regex("^PoleVaultScore.*$"),
                        hiscoreData, HTTF.ByteArrayToInt.BCD);
                    break;
            }
            #endregion

            #region ADJUST
            List<Regex> adjusters = new List<Regex>();
            switch (alternateName)
            {
                case 0:
                    adjusters = new List<Regex>(new Regex[] { 
                        new Regex("^FreeStyleScore.*$"), new Regex("^FreeStyleName.*$") });
                    hiscoreData = (AlternateData)HTTF.AdjustScores(rank, hiscoreData, adjusters);
                    break;
                case 1:
                    adjusters = new List<Regex>(new Regex[] { 
                        new Regex("^SkeetScore.*$"), new Regex("^SkeetName.*$") });
                    hiscoreData = (AlternateData)HTTF.AdjustScores(rank, hiscoreData, adjusters);
                    break;
                case 2:
                    adjusters = new List<Regex>(new Regex[] { 
                        new Regex("^LongHorseScore.*$"), new Regex("^LongHorseName.*$") });
                    hiscoreData = (AlternateData)HTTF.AdjustScores(rank, hiscoreData, adjusters);
                    break;
                case 3:
                    adjusters = new List<Regex>(new Regex[] { 
                        new Regex("^ArcheryScore.*$"), new Regex("^ArcheryName.*$") });
                    hiscoreData = (AlternateData)HTTF.AdjustScores(rank, hiscoreData, adjusters);
                    break;
                case 4:
                    adjusters = new List<Regex>(new Regex[] { 
                        new Regex("^TripleJumpScore.*$"), new Regex("^TripleJumpName.*$") });
                    hiscoreData = (AlternateData)HTTF.AdjustScores(rank, hiscoreData, adjusters);
                    break;
                case 5:
                    adjusters = new List<Regex>(new Regex[] { 
                        new Regex("^WeightLiftingScore.*$"), new Regex("^WeightLiftingName.*$") });
                    hiscoreData = (AlternateData)HTTF.AdjustScores(rank, hiscoreData, adjusters);
                    break;
                case 6:
                    adjusters = new List<Regex>(new Regex[] { 
                        new Regex("^PoleVaultScore.*$"), new Regex("^PoleVaultName.*$") });
                    hiscoreData = (AlternateData)HTTF.AdjustScores(rank, hiscoreData, adjusters);
                    break;
            }
            #endregion

            #region REPLACE_NEW
            List<Placement> placements = new List<Placement>();
            switch (alternateName)
            {
                case 0:
                    placements.Add(new Placement(name, new Regex("^FreeStyleName.*$"), ConvertName));
                    placements.Add(new Placement(score.ToString(), new Regex("^FreeStyleScore.*$"), ConvertAltScore));
                    hiscoreData = (AlternateData)HTTF.ReplaceNew(rank, hiscoreData, placements);
                    break;
                case 1:
                    placements.Add(new Placement(name, new Regex("^SkeetName.*$"), ConvertName));
                    placements.Add(new Placement(score.ToString(), new Regex("^SkeetScore.*$"), ConvertAltScore));
                    hiscoreData = (AlternateData)HTTF.ReplaceNew(rank, hiscoreData, placements);
                    break;
                case 2:
                    placements.Add(new Placement(name, new Regex("^LongHorseName.*$"), ConvertName));
                    placements.Add(new Placement(score.ToString(), new Regex("^LongHorseScore.*$"), ConvertAltScore));
                    hiscoreData = (AlternateData)HTTF.ReplaceNew(rank, hiscoreData, placements);
                    break;
                case 3:
                    placements.Add(new Placement(name, new Regex("^ArcheryName.*$"), ConvertName));
                    placements.Add(new Placement(score.ToString(), new Regex("^ArcheryScore.*$"), ConvertAltScore));
                    hiscoreData = (AlternateData)HTTF.ReplaceNew(rank, hiscoreData, placements);
                    break;
                case 4:
                    placements.Add(new Placement(name, new Regex("^TripleJumpName.*$"), ConvertName));
                    placements.Add(new Placement(score.ToString(), new Regex("^TripleJumpScore.*$"), ConvertAltScore));
                    hiscoreData = (AlternateData)HTTF.ReplaceNew(rank, hiscoreData, placements);
                    break;
                case 5:
                    placements.Add(new Placement(name, new Regex("^WeightLiftingName.*$"), ConvertName));
                    placements.Add(new Placement(score.ToString(), new Regex("^WeightLiftingScore.*$"), ConvertAltScore));
                    hiscoreData = (AlternateData)HTTF.ReplaceNew(rank, hiscoreData, placements);
                    break;
                case 6:
                    placements.Add(new Placement(name, new Regex("^PoleVaultName.*$"), ConvertName));
                    placements.Add(new Placement(score.ToString(), new Regex("^PoleVaultScore.*$"), ConvertAltScore));
                    hiscoreData = (AlternateData)HTTF.ReplaceNew(rank, hiscoreData, placements);
                    break;
            }
            #endregion

            byte[] byteArray = new byte[m_data.Length];
            byte[] scoreArray = HiConvert.RawSerialize(hiscoreData);

            for (int i = 0; i < byteArray.Length; i++)
            {
                if (i < scoreArray.Length)
                    byteArray[i] = scoreArray[i];
                else
                    byteArray[i] = m_data[i];
            }

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void ModifyName(int rank, string name)
        {
            byte[] nameByte = ConvertName(name);

            int offset = Marshal.SizeOf(typeof(AlternateData)) + ((rank - 1) * Marshal.SizeOf(typeof(HiscoreData)));

            m_data[offset + 3] = nameByte[3];
            m_data[offset + 4] = nameByte[4];
            m_data[offset + 5] = nameByte[5];

            SaveData();
        }

        public override void EmptyScores()
        {
            for (int i = 0; i < NumEntries; i++)
            {
                m_data[Marshal.SizeOf(typeof(AlternateData)) + (i * Marshal.SizeOf(typeof(HiscoreData)))] = 0x00;
                m_data[Marshal.SizeOf(typeof(AlternateData)) + (i * Marshal.SizeOf(typeof(HiscoreData))) + 1] = 0x00;
                m_data[Marshal.SizeOf(typeof(AlternateData)) + (i * Marshal.SizeOf(typeof(HiscoreData))) + 2] = 0x00;
            }

            AlternateData hiscoreData = (AlternateData)HiConvert.RawDeserialize(m_data, 0, typeof(AlternateData));

            hiscoreData = (AlternateData)HTTF.EmptyScores(hiscoreData, new Regex("^.*Score.*$"), ConvertAltScore);
            hiscoreData = (AlternateData)HTTF.EmptyScores(hiscoreData, new Regex("^HiScore.*$"), ConvertScore);

            byte[] byteArray = new byte[m_data.Length];
            byte[] scoreArray = HiConvert.RawSerialize(hiscoreData);

            for (int i = 0; i < byteArray.Length; i++)
            {
                if (i < scoreArray.Length)
                    byteArray[i] = scoreArray[i];
                else
                    byteArray[i] = m_data[i];
            }

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            for (int i = 0; i < NumEntries; i++)
            {
                HiscoreData hiscoreData = new HiscoreData();
                hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, Marshal.SizeOf(typeof(AlternateData)) + (i * Marshal.SizeOf(typeof(HiscoreData))), typeof(HiscoreData));

                retString += String.Format("{0}|{1}|{2}",
                    i + 1,
                    HiConvert.ByteArrayHexToInt(hiscoreData.Score) * 10,
                    ConvertName(hiscoreData.Name) + Environment.NewLine);
            }

            byte[] altArea = new byte[Marshal.SizeOf(typeof(AlternateData))];
            for (int i = 0; i < altArea.Length; i++)
                altArea[i] = m_data[i];
            AlternateData altData = (AlternateData)HiConvert.RawDeserialize(altArea, 0, typeof(AlternateData));

            List<DisplayData> formatting = new List<DisplayData>();

            retString += Environment.NewLine + Environment.NewLine + AltFormat[0] + Environment.NewLine;
            formatting.Add(new DisplayData(null, DisplayData.CannedDisplay.AscendingFrom1));
            formatting.Add(new DisplayData(new Regex("^FreeStyleScore.*$"), FormatAsTime));
            formatting.Add(new DisplayData(new Regex("^FreeStyleName.*$"), ConvertName));
            retString += HTTF.HiToString(altData, formatting);
            retString += AltFormat[1] + Environment.NewLine;
            formatting.Clear();
            formatting.Add(new DisplayData(null, DisplayData.CannedDisplay.AscendingFrom1));
            formatting.Add(new DisplayData(new Regex("^SkeetScore.*$"), HiToStr.BCD));
            formatting.Add(new DisplayData(new Regex("^SkeetName.*$"), ConvertName));
            retString += HTTF.HiToString(altData, formatting);
            retString += AltFormat[2] + Environment.NewLine;
            formatting.Clear();
            formatting.Add(new DisplayData(null, DisplayData.CannedDisplay.AscendingFrom1));
            formatting.Add(new DisplayData(new Regex("^LongHorseScore.*$"), FormatAs10Score));
            formatting.Add(new DisplayData(new Regex("^LongHorseName.*$"), ConvertName));
            retString += HTTF.HiToString(altData, formatting);
            retString += AltFormat[3] + Environment.NewLine;
            formatting.Clear();
            formatting.Add(new DisplayData(null, DisplayData.CannedDisplay.AscendingFrom1));
            formatting.Add(new DisplayData(new Regex("^ArcheryScore.*$"), HiToStr.BCD));
            formatting.Add(new DisplayData(new Regex("^ArcheryName.*$"), ConvertName));
            retString += HTTF.HiToString(altData, formatting);
            retString += AltFormat[4] + Environment.NewLine;
            formatting.Clear();
            formatting.Add(new DisplayData(null, DisplayData.CannedDisplay.AscendingFrom1));
            formatting.Add(new DisplayData(new Regex("^TripleJumpScore.*$"), FormatAsDistance));
            formatting.Add(new DisplayData(new Regex("^TripleJumpName.*$"), ConvertName));
            retString += HTTF.HiToString(altData, formatting);
            retString += AltFormat[5] + Environment.NewLine;
            formatting.Clear();
            formatting.Add(new DisplayData(null, DisplayData.CannedDisplay.AscendingFrom1));
            formatting.Add(new DisplayData(new Regex("^WeightLiftingScore.*$"), FormatAsWeight));
            formatting.Add(new DisplayData(new Regex("^WeightLiftingName.*$"), ConvertName));
            retString += HTTF.HiToString(altData, formatting);
            retString += AltFormat[6] + Environment.NewLine;
            formatting.Clear();
            formatting.Add(new DisplayData(null, DisplayData.CannedDisplay.AscendingFrom1));
            formatting.Add(new DisplayData(new Regex("^PoleVaultScore.*$"), FormatAsDistance));
            formatting.Add(new DisplayData(new Regex("^PoleVaultName.*$"), ConvertName));
            retString += HTTF.HiToString(altData, formatting);

            return retString;
        }
    }
}