using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    public class NameScore
    {
        public byte[] Score;
        public byte[] Name;

        public NameScore(byte[] s, byte[] n)
        {
            Score = new byte[3];
            Name = new byte[3];
            HiConvert.ByteArrayCopy(Score, s);
            HiConvert.ByteArrayCopy(Name, n);
        }

        public static int CompareScore(NameScore x, NameScore y)
        {
            return HiConvert.ByteArrayHexAsHexToInt(y.Score).CompareTo(HiConvert.ByteArrayHexAsHexToInt(x.Score));
        }
    }

    class paperboy : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 66)]
            public byte[] Header;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreEasyA;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameEasyA;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreEasyB;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameEasyB;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreEasyC;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameEasyC;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreEasyD;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameEasyD;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreEasyE;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameEasyE;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreEasyF;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameEasyF;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreEasyG;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameEasyG;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreEasyH;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameEasyH;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreEasyI;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameEasyI;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreEasyJ;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameEasyJ;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreMiddleA;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameMiddleA;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreMiddleB;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameMiddleB;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreMiddleC;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameMiddleC;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreMiddleD;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameMiddleD;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreMiddleE;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameMiddleE;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreMiddleF;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameMiddleF;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreMiddleG;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameMiddleG;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreMiddleH;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameMiddleH;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreMiddleI;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameMiddleI;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreMiddleJ;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameMiddleJ;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreHardA;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameHardA;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreHardB;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameHardB;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreHardC;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameHardC;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreHardD;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameHardD;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreHardE;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameHardE;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreHardF;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameHardF;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreHardG;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameHardG;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreHardH;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameHardH;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreHardI;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameHardI;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreHardJ;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameHardJ;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1802)]
            public byte[] Footer;
        }

        public paperboy()
        {
            m_numEntries = 10;
            m_format = "RANK|SCORE|NAME";
            m_altFormat = new string[3];
            m_altFormat[0] = "EASY STREET" + Environment.NewLine + "RANK|SCORE|NAME";
            m_altFormat[1] = "MIDDLE ROAD" + Environment.NewLine + "RANK|SCORE|NAME";
            m_altFormat[2] = "HARD WAY" + Environment.NewLine + "RANK|SCORE|NAME";
            m_numAltEntries = new int[] { 10, 10, 10 };
            m_gamesSupported = "paperboy";
            m_extensionsRequired = ".nv";
        }

        private int GetAlternateName(string altName)
        {
            switch (altName)
            {
                case "EASY STREET":
                    return 0;
                case "MIDDLE ROAD":
                    return 1;
                case "HARD WAY":
                    return 2;
            }
            return -1;
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == 0x20)
                    sb.Append(' ');
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
                if (str[i] == ' ')
                    data[i] = 0x20;
                else
                    data[i] = (byte)((int)str[i]);
            }

            return data;
        }

        public override void SetHiScore(string[] args)
        {
            throw new Exception("To change paperboy scores, you must change alternate scores.");
        }

        public override void SetAlternateScore(string[] args)
        {
            int alternateName = GetAlternateName(args[0]);
            int rankGiven = Convert.ToInt32(args[1]);
            int score = Convert.ToInt32(args[2]);
            string name = args[3];

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));
            
            #region MAKE EASY
            List<NameScore> sortedEasy = new List<NameScore>();
            sortedEasy.Add(new NameScore(hiscoreData.ScoreEasyA, hiscoreData.NameEasyA));
            sortedEasy.Add(new NameScore(hiscoreData.ScoreEasyB, hiscoreData.NameEasyB));
            sortedEasy.Add(new NameScore(hiscoreData.ScoreEasyC, hiscoreData.NameEasyC));
            sortedEasy.Add(new NameScore(hiscoreData.ScoreEasyD, hiscoreData.NameEasyD));
            sortedEasy.Add(new NameScore(hiscoreData.ScoreEasyE, hiscoreData.NameEasyE));
            sortedEasy.Add(new NameScore(hiscoreData.ScoreEasyF, hiscoreData.NameEasyF));
            sortedEasy.Add(new NameScore(hiscoreData.ScoreEasyG, hiscoreData.NameEasyG));
            sortedEasy.Add(new NameScore(hiscoreData.ScoreEasyH, hiscoreData.NameEasyH));
            sortedEasy.Add(new NameScore(hiscoreData.ScoreEasyI, hiscoreData.NameEasyI));
            sortedEasy.Add(new NameScore(hiscoreData.ScoreEasyJ, hiscoreData.NameEasyJ));
            sortedEasy.Sort(NameScore.CompareScore);
            #endregion

            #region MAKE MIDDLE
            List<NameScore> sortedMiddle = new List<NameScore>();
            sortedMiddle.Add(new NameScore(hiscoreData.ScoreMiddleA, hiscoreData.NameMiddleA));
            sortedMiddle.Add(new NameScore(hiscoreData.ScoreMiddleB, hiscoreData.NameMiddleB));
            sortedMiddle.Add(new NameScore(hiscoreData.ScoreMiddleC, hiscoreData.NameMiddleC));
            sortedMiddle.Add(new NameScore(hiscoreData.ScoreMiddleD, hiscoreData.NameMiddleD));
            sortedMiddle.Add(new NameScore(hiscoreData.ScoreMiddleE, hiscoreData.NameMiddleE));
            sortedMiddle.Add(new NameScore(hiscoreData.ScoreMiddleF, hiscoreData.NameMiddleF));
            sortedMiddle.Add(new NameScore(hiscoreData.ScoreMiddleG, hiscoreData.NameMiddleG));
            sortedMiddle.Add(new NameScore(hiscoreData.ScoreMiddleH, hiscoreData.NameMiddleH));
            sortedMiddle.Add(new NameScore(hiscoreData.ScoreMiddleI, hiscoreData.NameMiddleI));
            sortedMiddle.Add(new NameScore(hiscoreData.ScoreMiddleJ, hiscoreData.NameMiddleJ));
            sortedMiddle.Sort(NameScore.CompareScore);
            #endregion

            #region MAKE HARD
            List<NameScore> sortedHard = new List<NameScore>();
            sortedHard.Add(new NameScore(hiscoreData.ScoreHardA, hiscoreData.NameHardA));
            sortedHard.Add(new NameScore(hiscoreData.ScoreHardB, hiscoreData.NameHardB));
            sortedHard.Add(new NameScore(hiscoreData.ScoreHardC, hiscoreData.NameHardC));
            sortedHard.Add(new NameScore(hiscoreData.ScoreHardD, hiscoreData.NameHardD));
            sortedHard.Add(new NameScore(hiscoreData.ScoreHardE, hiscoreData.NameHardE));
            sortedHard.Add(new NameScore(hiscoreData.ScoreHardF, hiscoreData.NameHardF));
            sortedHard.Add(new NameScore(hiscoreData.ScoreHardG, hiscoreData.NameHardG));
            sortedHard.Add(new NameScore(hiscoreData.ScoreHardH, hiscoreData.NameHardH));
            sortedHard.Add(new NameScore(hiscoreData.ScoreHardI, hiscoreData.NameHardI));
            sortedHard.Add(new NameScore(hiscoreData.ScoreHardJ, hiscoreData.NameHardJ));
            sortedHard.Sort(NameScore.CompareScore);
            #endregion

            bool isValidNewScore = false;

            #region DETERMINE_RANK
            int rank = NumAltEntries[alternateName];
            switch (alternateName)
            {
                case 0:
                    for (int i = 0; i < NumAltEntries[alternateName]; i++)
                    {
                        if (score > HiConvert.ByteArrayHexAsHexToInt(sortedEasy[i].Score))
                            isValidNewScore = true;
                    }
                    break;
                case 1:
                    for (int i = 0; i < NumAltEntries[alternateName]; i++)
                    {
                        if (score > HiConvert.ByteArrayHexAsHexToInt(sortedMiddle[i].Score))
                            isValidNewScore = true;
                    }
                    break;
                case 2:
                    for (int i = 0; i < NumAltEntries[alternateName]; i++)
                    {
                        if (score > HiConvert.ByteArrayHexAsHexToInt(sortedHard[i].Score))
                            isValidNewScore = true;
                    }
                    break;
            }
            #endregion

            #region REPLACE_NEW
            if (isValidNewScore)
            {
                //NOTE: No sorting is done again because it doesn't matter where the scores are, the game
                //      will sort them automatically, so we save some time.
                switch (alternateName)
                {
                    case 0:
                        sortedEasy.RemoveAt(NumAltEntries[alternateName] - 1);
                        sortedEasy.Add(new NameScore(HiConvert.IntToByteArrayHexAsHex(score, 3), StringToByteArray(name)));
                        break;
                    case 1:
                        sortedMiddle.RemoveAt(NumAltEntries[alternateName] - 1);
                        sortedMiddle.Add(new NameScore(HiConvert.IntToByteArrayHexAsHex(score, 3), StringToByteArray(name)));
                        break;
                    case 2:
                        sortedHard.RemoveAt(NumAltEntries[alternateName] - 1);
                        sortedHard.Add(new NameScore(HiConvert.IntToByteArrayHexAsHex(score, 3), StringToByteArray(name)));
                        break;
                }
            }
            #endregion

            #region REPLANT_INTO_FILE
            switch (alternateName)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreEasyA, sortedEasy[0].Score);
                    HiConvert.ByteArrayCopy(hiscoreData.NameEasyA, sortedEasy[0].Name);
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreEasyB, sortedEasy[1].Score);
                    HiConvert.ByteArrayCopy(hiscoreData.NameEasyB, sortedEasy[1].Name);
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreEasyC, sortedEasy[2].Score);
                    HiConvert.ByteArrayCopy(hiscoreData.NameEasyC, sortedEasy[2].Name);
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreEasyD, sortedEasy[3].Score);
                    HiConvert.ByteArrayCopy(hiscoreData.NameEasyD, sortedEasy[3].Name);
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreEasyE, sortedEasy[4].Score);
                    HiConvert.ByteArrayCopy(hiscoreData.NameEasyE, sortedEasy[4].Name);
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreEasyF, sortedEasy[5].Score);
                    HiConvert.ByteArrayCopy(hiscoreData.NameEasyF, sortedEasy[5].Name);
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreEasyG, sortedEasy[6].Score);
                    HiConvert.ByteArrayCopy(hiscoreData.NameEasyG, sortedEasy[6].Name);
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreEasyH, sortedEasy[7].Score);
                    HiConvert.ByteArrayCopy(hiscoreData.NameEasyH, sortedEasy[7].Name);
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreEasyI, sortedEasy[8].Score);
                    HiConvert.ByteArrayCopy(hiscoreData.NameEasyI, sortedEasy[8].Name);
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreEasyJ, sortedEasy[9].Score);
                    HiConvert.ByteArrayCopy(hiscoreData.NameEasyJ, sortedEasy[9].Name);
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreMiddleA, sortedMiddle[0].Score);
                    HiConvert.ByteArrayCopy(hiscoreData.NameMiddleA, sortedMiddle[0].Name);
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreMiddleB, sortedMiddle[1].Score);
                    HiConvert.ByteArrayCopy(hiscoreData.NameMiddleB, sortedMiddle[1].Name);
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreMiddleC, sortedMiddle[2].Score);
                    HiConvert.ByteArrayCopy(hiscoreData.NameMiddleC, sortedMiddle[2].Name);
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreMiddleD, sortedMiddle[3].Score);
                    HiConvert.ByteArrayCopy(hiscoreData.NameMiddleD, sortedMiddle[3].Name);
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreMiddleE, sortedMiddle[4].Score);
                    HiConvert.ByteArrayCopy(hiscoreData.NameMiddleE, sortedMiddle[4].Name);
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreMiddleF, sortedMiddle[5].Score);
                    HiConvert.ByteArrayCopy(hiscoreData.NameMiddleF, sortedMiddle[5].Name);
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreMiddleG, sortedMiddle[6].Score);
                    HiConvert.ByteArrayCopy(hiscoreData.NameMiddleG, sortedMiddle[6].Name);
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreMiddleH, sortedMiddle[7].Score);
                    HiConvert.ByteArrayCopy(hiscoreData.NameMiddleH, sortedMiddle[7].Name);
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreMiddleI, sortedMiddle[8].Score);
                    HiConvert.ByteArrayCopy(hiscoreData.NameMiddleI, sortedMiddle[8].Name);
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreMiddleJ, sortedMiddle[9].Score);
                    HiConvert.ByteArrayCopy(hiscoreData.NameMiddleJ, sortedMiddle[9].Name);
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreHardA, sortedHard[0].Score);
                    HiConvert.ByteArrayCopy(hiscoreData.NameHardA, sortedHard[0].Name);
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreHardB, sortedHard[1].Score);
                    HiConvert.ByteArrayCopy(hiscoreData.NameHardB, sortedHard[1].Name);
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreHardC, sortedHard[2].Score);
                    HiConvert.ByteArrayCopy(hiscoreData.NameHardC, sortedHard[2].Name);
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreHardD, sortedHard[3].Score);
                    HiConvert.ByteArrayCopy(hiscoreData.NameHardD, sortedHard[3].Name);
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreHardE, sortedHard[4].Score);
                    HiConvert.ByteArrayCopy(hiscoreData.NameHardE, sortedHard[4].Name);
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreHardF, sortedHard[5].Score);
                    HiConvert.ByteArrayCopy(hiscoreData.NameHardF, sortedHard[5].Name);
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreHardG, sortedHard[6].Score);
                    HiConvert.ByteArrayCopy(hiscoreData.NameHardG, sortedHard[6].Name);
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreHardH, sortedHard[7].Score);
                    HiConvert.ByteArrayCopy(hiscoreData.NameHardH, sortedHard[7].Name);
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreHardI, sortedHard[8].Score);
                    HiConvert.ByteArrayCopy(hiscoreData.NameHardI, sortedHard[8].Name);
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreHardJ, sortedHard[9].Score);
                    HiConvert.ByteArrayCopy(hiscoreData.NameHardJ, sortedHard[9].Name);
                    break;
            }
            #endregion

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        private List<NameScore> SortScores(HiscoreData hiscoreData)
        {
            List<NameScore> toReturn = new List<NameScore>();
            toReturn.Add(new NameScore(hiscoreData.ScoreEasyA, hiscoreData.NameEasyA));
            toReturn.Add(new NameScore(hiscoreData.ScoreEasyB, hiscoreData.NameEasyB));
            toReturn.Add(new NameScore(hiscoreData.ScoreEasyC, hiscoreData.NameEasyC));
            toReturn.Add(new NameScore(hiscoreData.ScoreEasyD, hiscoreData.NameEasyD));
            toReturn.Add(new NameScore(hiscoreData.ScoreEasyE, hiscoreData.NameEasyE));
            toReturn.Add(new NameScore(hiscoreData.ScoreEasyF, hiscoreData.NameEasyF));
            toReturn.Add(new NameScore(hiscoreData.ScoreEasyG, hiscoreData.NameEasyG));
            toReturn.Add(new NameScore(hiscoreData.ScoreEasyH, hiscoreData.NameEasyH));
            toReturn.Add(new NameScore(hiscoreData.ScoreEasyI, hiscoreData.NameEasyI));
            toReturn.Add(new NameScore(hiscoreData.ScoreEasyJ, hiscoreData.NameEasyJ));
            toReturn.Add(new NameScore(hiscoreData.ScoreMiddleA, hiscoreData.NameMiddleA));
            toReturn.Add(new NameScore(hiscoreData.ScoreMiddleB, hiscoreData.NameMiddleB));
            toReturn.Add(new NameScore(hiscoreData.ScoreMiddleC, hiscoreData.NameMiddleC));
            toReturn.Add(new NameScore(hiscoreData.ScoreMiddleD, hiscoreData.NameMiddleD));
            toReturn.Add(new NameScore(hiscoreData.ScoreMiddleE, hiscoreData.NameMiddleE));
            toReturn.Add(new NameScore(hiscoreData.ScoreMiddleF, hiscoreData.NameMiddleF));
            toReturn.Add(new NameScore(hiscoreData.ScoreMiddleG, hiscoreData.NameMiddleG));
            toReturn.Add(new NameScore(hiscoreData.ScoreMiddleH, hiscoreData.NameMiddleH));
            toReturn.Add(new NameScore(hiscoreData.ScoreMiddleI, hiscoreData.NameMiddleI));
            toReturn.Add(new NameScore(hiscoreData.ScoreMiddleJ, hiscoreData.NameMiddleJ));
            toReturn.Add(new NameScore(hiscoreData.ScoreHardA, hiscoreData.NameHardA));
            toReturn.Add(new NameScore(hiscoreData.ScoreHardB, hiscoreData.NameHardB));
            toReturn.Add(new NameScore(hiscoreData.ScoreHardC, hiscoreData.NameHardC));
            toReturn.Add(new NameScore(hiscoreData.ScoreHardD, hiscoreData.NameHardD));
            toReturn.Add(new NameScore(hiscoreData.ScoreHardE, hiscoreData.NameHardE));
            toReturn.Add(new NameScore(hiscoreData.ScoreHardF, hiscoreData.NameHardF));
            toReturn.Add(new NameScore(hiscoreData.ScoreHardG, hiscoreData.NameHardG));
            toReturn.Add(new NameScore(hiscoreData.ScoreHardH, hiscoreData.NameHardH));
            toReturn.Add(new NameScore(hiscoreData.ScoreHardI, hiscoreData.NameHardI));
            toReturn.Add(new NameScore(hiscoreData.ScoreHardJ, hiscoreData.NameHardJ));

            toReturn.Sort(NameScore.CompareScore);

            return toReturn;
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.ScoreEasyA, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreEasyA.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreEasyB, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreEasyB.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreEasyC, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreEasyC.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreEasyD, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreEasyD.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreEasyE, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreEasyE.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreEasyF, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreEasyF.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreEasyG, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreEasyG.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreEasyH, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreEasyH.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreEasyI, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreEasyI.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreEasyJ, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreEasyJ.Length));

            HiConvert.ByteArrayCopy(hiscoreData.ScoreMiddleA, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreMiddleA.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreMiddleB, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreMiddleB.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreMiddleC, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreMiddleC.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreMiddleD, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreMiddleD.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreMiddleE, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreMiddleE.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreMiddleF, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreMiddleF.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreMiddleG, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreMiddleG.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreMiddleH, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreMiddleH.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreMiddleI, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreMiddleI.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreMiddleJ, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreMiddleJ.Length));

            HiConvert.ByteArrayCopy(hiscoreData.ScoreHardA, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreHardA.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreHardB, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreHardB.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreHardC, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreHardC.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreHardD, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreHardD.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreHardE, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreHardE.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreHardF, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreHardF.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreHardG, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreHardG.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreHardH, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreHardH.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreHardI, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreHardI.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreHardJ, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreHardJ.Length));
            
            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            List<NameScore> sortedScores = SortScores(hiscoreData);

            #region MAKE EASY
            List<NameScore> sortedEasy = new List<NameScore>();
            sortedEasy.Add(new NameScore(hiscoreData.ScoreEasyA, hiscoreData.NameEasyA));
            sortedEasy.Add(new NameScore(hiscoreData.ScoreEasyB, hiscoreData.NameEasyB));
            sortedEasy.Add(new NameScore(hiscoreData.ScoreEasyC, hiscoreData.NameEasyC));
            sortedEasy.Add(new NameScore(hiscoreData.ScoreEasyD, hiscoreData.NameEasyD));
            sortedEasy.Add(new NameScore(hiscoreData.ScoreEasyE, hiscoreData.NameEasyE));
            sortedEasy.Add(new NameScore(hiscoreData.ScoreEasyF, hiscoreData.NameEasyF));
            sortedEasy.Add(new NameScore(hiscoreData.ScoreEasyG, hiscoreData.NameEasyG));
            sortedEasy.Add(new NameScore(hiscoreData.ScoreEasyH, hiscoreData.NameEasyH));
            sortedEasy.Add(new NameScore(hiscoreData.ScoreEasyI, hiscoreData.NameEasyI));
            sortedEasy.Add(new NameScore(hiscoreData.ScoreEasyJ, hiscoreData.NameEasyJ));
            sortedEasy.Sort(NameScore.CompareScore);
            #endregion

            #region MAKE MIDDLE
            List<NameScore> sortedMiddle = new List<NameScore>();
            sortedMiddle.Add(new NameScore(hiscoreData.ScoreMiddleA, hiscoreData.NameMiddleA));
            sortedMiddle.Add(new NameScore(hiscoreData.ScoreMiddleB, hiscoreData.NameMiddleB));
            sortedMiddle.Add(new NameScore(hiscoreData.ScoreMiddleC, hiscoreData.NameMiddleC));
            sortedMiddle.Add(new NameScore(hiscoreData.ScoreMiddleD, hiscoreData.NameMiddleD));
            sortedMiddle.Add(new NameScore(hiscoreData.ScoreMiddleE, hiscoreData.NameMiddleE));
            sortedMiddle.Add(new NameScore(hiscoreData.ScoreMiddleF, hiscoreData.NameMiddleF));
            sortedMiddle.Add(new NameScore(hiscoreData.ScoreMiddleG, hiscoreData.NameMiddleG));
            sortedMiddle.Add(new NameScore(hiscoreData.ScoreMiddleH, hiscoreData.NameMiddleH));
            sortedMiddle.Add(new NameScore(hiscoreData.ScoreMiddleI, hiscoreData.NameMiddleI));
            sortedMiddle.Add(new NameScore(hiscoreData.ScoreMiddleJ, hiscoreData.NameMiddleJ));
            sortedMiddle.Sort(NameScore.CompareScore);
            #endregion

            #region MAKE HARD
            List<NameScore> sortedHard = new List<NameScore>();
            sortedHard.Add(new NameScore(hiscoreData.ScoreHardA, hiscoreData.NameHardA));
            sortedHard.Add(new NameScore(hiscoreData.ScoreHardB, hiscoreData.NameHardB));
            sortedHard.Add(new NameScore(hiscoreData.ScoreHardC, hiscoreData.NameHardC));
            sortedHard.Add(new NameScore(hiscoreData.ScoreHardD, hiscoreData.NameHardD));
            sortedHard.Add(new NameScore(hiscoreData.ScoreHardE, hiscoreData.NameHardE));
            sortedHard.Add(new NameScore(hiscoreData.ScoreHardF, hiscoreData.NameHardF));
            sortedHard.Add(new NameScore(hiscoreData.ScoreHardG, hiscoreData.NameHardG));
            sortedHard.Add(new NameScore(hiscoreData.ScoreHardH, hiscoreData.NameHardH));
            sortedHard.Add(new NameScore(hiscoreData.ScoreHardI, hiscoreData.NameHardI));
            sortedHard.Add(new NameScore(hiscoreData.ScoreHardJ, hiscoreData.NameHardJ));
            sortedHard.Sort(NameScore.CompareScore);
            #endregion

            for (int i = 0; i < NumEntries; i++)
                retString += String.Format("{0}|{1}|{2}", (i + 1), HiConvert.ByteArrayHexAsHexToInt(sortedScores[i].Score), ByteArrayToString(sortedScores[i].Name)) + Environment.NewLine;

            retString += Environment.NewLine + Environment.NewLine + AltFormat[0] + Environment.NewLine;
            for (int i = 0; i < NumAltEntries[0]; i++)
                retString += String.Format("{0}|{1}|{2}", (i + 1), HiConvert.ByteArrayHexAsHexToInt(sortedEasy[i].Score), ByteArrayToString(sortedEasy[i].Name)) + Environment.NewLine;

            retString += Environment.NewLine + Environment.NewLine + AltFormat[1] + Environment.NewLine;
            for (int i = 0; i < NumAltEntries[1]; i++)
                retString += String.Format("{0}|{1}|{2}", (i + 1), HiConvert.ByteArrayHexAsHexToInt(sortedMiddle[i].Score), ByteArrayToString(sortedMiddle[i].Name)) + Environment.NewLine;

            retString += Environment.NewLine + Environment.NewLine + AltFormat[2] + Environment.NewLine;
            for (int i = 0; i < NumAltEntries[2]; i++)
                retString += String.Format("{0}|{1}|{2}", (i + 1), HiConvert.ByteArrayHexAsHexToInt(sortedHard[i].Score), ByteArrayToString(sortedHard[i].Name)) + Environment.NewLine;
           
            return retString;
        }
    }
}