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
    class _005 : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            public byte Header;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score5;
        }

        public _005()
        {
            m_numEntries = 5;
            m_format = "RANK|SCORE";
            m_gamesSupported = "005";
            m_extensionsRequired = ".hi";
        }

        public byte[] ConvertScore(string score)
        {
            return HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(Convert.ToInt32(score), 2));
        }

        //Not standard, so need to create our own ConvertScore returning a string.
        public string ConvertScore(byte[] score)
        {
            return (HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(score)) * 10).ToString();
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]) / 10;

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));
            Regex rxScore = new Regex("^Score.*$");

            //Determining rank.
            int rank = HTTF.DetermineRank(score, rxScore, hiscoreData, HTTF.ByteArrayToInt.Reversed);

            //Adjusting lower scores.
            hiscoreData = (HiscoreData)HTTF.AdjustScores(
                rank, hiscoreData, new List<Regex>(new Regex[] { rxScore }));

            //Replacing new scores.
            List<Placement> placements = new List<Placement>();
            placements.Add(new Placement(score.ToString(), rxScore, ConvertScore));

            hiscoreData = (HiscoreData)HTTF.ReplaceNew(rank, hiscoreData, placements);

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        //No name, so no modify allowed.
        public void ModifyName(int rank, string name)
        {
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
            formatting.Add(new DisplayData(new Regex("^Score.*$"), ConvertScore));
            retString += HTTF.HiToString(hiscoreData, formatting);

            return retString;
        }
    }
}

