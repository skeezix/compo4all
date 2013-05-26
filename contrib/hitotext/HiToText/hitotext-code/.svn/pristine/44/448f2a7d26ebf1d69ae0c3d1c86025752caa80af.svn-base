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
    class ajax : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name1;
            public byte Unknown1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name2;
            public byte Unknown2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name3;
            public byte Unknown3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name4;
            public byte Unknown4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score4;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name5;
            public byte Unknown5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score5;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name6;
            public byte Unknown6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score6;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name7;
            public byte Unknown7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score7;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name8;
            public byte Unknown8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score8;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name9;
            public byte Unknown9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score9;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name10;
            public byte Unknown10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score10;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] HiScore;
        }

        public TextParams tParams = new TextParams();

        public ajax()
        {
            m_numEntries = 10;
            m_format = "RANK|SCORE|NAME";
            m_gamesSupported = "ajax,ajaxj,typhoon";
            m_extensionsRequired = ".hi";

            tParams.Format =
                StringFormatFlag.NeedsSpecialMapping |
                StringFormatFlag.ASCIIUpper;

            tParams.AddMapping('.', 0x2b);
            tParams.AddMapping('!', 0x2c);

            tParams.AddOffset(new Offset(0x11, Offset.FlagOffsets.Upper));
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
            return HiConvert.IntToByteArrayHex(Convert.ToInt32(score), 4);
        }

        public byte[] ConvertUnknown(string unknown)
        {
            return HiConvert.IntToByteArrayHexAsHex(Convert.ToInt32(unknown), 1);
        }

        public override void SetHiScore(string[] args)
        {
            //int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2].ToUpper().PadRight(3, 'A').Substring(0, 3);
            int unknown = 0x11; // it seems that the value is always 0x11 for the player
            
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));
            Regex rxScore = new Regex("^Score.*$");
            Regex rxName = new Regex("^Name.*$");
            Regex rxUnknown = new Regex("^Unknown.*$");

            //Determining rank.
            int rank = HTTF.DetermineRank(
                score, rxScore, hiscoreData, HTTF.ByteArrayToInt.Standard);

            //Adjusting lower scores.
            List<Regex> adjusters = new List<Regex>(new Regex[] { rxScore, rxName, rxUnknown });
            hiscoreData = (HiscoreData)HTTF.AdjustScores(rank, hiscoreData, adjusters);

            //Replacing new scores.
            List<Placement> placements = new List<Placement>();
            placements.Add(new Placement(name, rxName, ConvertName));
            placements.Add(new Placement(score.ToString(), rxScore, ConvertScore));
            placements.Add(new Placement(score.ToString(), new Regex("^HiScore$"), true, ConvertScore));
            placements.Add(new Placement(unknown.ToString(), rxUnknown, ConvertUnknown));

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

            //We also want to get the top score and empty that.
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

            retString += HTTF.HiToString(hiscoreData, formatting);

            return retString;
        }
    }
}