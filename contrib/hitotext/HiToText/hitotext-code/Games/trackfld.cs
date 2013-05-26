using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class trackfld : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Name;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct AlternateData
        {
            //100m World Records.
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] _100mScore1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] _100mName1;
            public byte _100mSeperator1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] _100mScore2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] _100mName2;
            public byte _100mSeperator2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] _100mScore3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] _100mName3;
            public byte _100mSeperator3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] _100mScore4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] _100mName4;
            public byte _100mSeperator4;

            //Long Jump World Records.
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] LongJumpScore1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] LongJumpName1;
            public byte LongJumpSeperator1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] LongJumpScore2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] LongJumpName2;
            public byte LongJumpSeperator2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] LongJumpScore3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] LongJumpName3;
            public byte LongJumpSeperator3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] LongJumpScore4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] LongJumpName4;
            public byte LongJumpSeperator4;

            //Javelin World Records.
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] JavelinScore1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] JavelinName1;
            public byte JavelinSeperator1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] JavelinScore2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] JavelinName2;
            public byte JavelinSeperator2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] JavelinScore3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] JavelinName3;
            public byte JavelinSeperator3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] JavelinScore4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] JavelinName4;
            public byte JavelinSeperator4;

            //110m Hurdles World Records.
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] _110mHurdlesScore1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] _110mHurdlesName1;
            public byte _110mHurdlesSeperator1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] _110mHurdlesScore2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] _110mHurdlesName2;
            public byte _110mHurdlesSeperator2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] _110mHurdlesScore3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] _110mHurdlesName3;
            public byte _110mHurdlesSeperator3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] _110mHurdlesScore4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] _110mHurdlesName4;
            public byte _110mHurdlesSeperator4;

            //Hammer Toss World Records.
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] HammerTossScore1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] HammerTossName1;
            public byte HammerTossSeperator1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] HammerTossScore2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] HammerTossName2;
            public byte HammerTossSeperator2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] HammerTossScore3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] HammerTossName3;
            public byte HammerTossSeperator3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] HammerTossScore4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] HammerTossName4;
            public byte HammerTossSeperator4;

            //High Jump World Records.
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] HighJumpScore1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] HighJumpName1;
            public byte HighJumpSeperator1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] HighJumpScore2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] HighJumpName2;
            public byte HighJumpSeperator2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] HighJumpScore3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] HighJumpName3;
            public byte HighJumpSeperator3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] HighJumpScore4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] HighJumpName4;
            public byte HighJumpSeperator4;
        }

        public trackfld()
        {
            m_numEntries = 160;
            m_format = "RANK|SCORE|NAME";
            m_altFormat = new string[6];
            m_altFormat[0] = "100M WORLD RECORD" + Environment.NewLine + "RANK|TIME|NAME";
            m_altFormat[1] = "LONG JUMP WORLD RECORD" + Environment.NewLine + "RANK|DISTANCE|NAME";
            m_altFormat[2] = "JAVELIN WORLD RECORD" + Environment.NewLine + "RANK|DISTANCE|NAME";
            m_altFormat[3] = "110M HURDLES WORLD RECORD" + Environment.NewLine + "RANK|TIME|NAME";
            m_altFormat[4] = "HAMMER TOSS WORLD RECORD" + Environment.NewLine + "RANK|DISTANCE|NAME";
            m_altFormat[5] = "HIGH JUMP WORLD RECORD" + Environment.NewLine + "RANK|HEIGHT|NAME";
            m_numAltEntries = new int[] { 3, 3, 3, 3, 3, 3 };
            m_gamesSupported = "trackfld,trackflc,atlantol,hyprolym,hyprolyb";
            m_extensionsRequired = ".nv";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            //Marble madness approach.
            if (data.Length == 2)
            {
                for (int i = 0; i < data.Length; i++)
                    sb.Append(data[i].ToString("X2"));

                String name = sb.ToString();
                String toReturn = "";

                int val = System.Convert.ToInt32(name, 16);
                int everyFirst = 1024;
                int everySecond = 32;

                toReturn = ((char)(System.Convert.ToInt32((val / everyFirst).ToString("X2"), 16) + 64)).ToString();
                int restOfLastTwo = val - ((val / everyFirst) * everyFirst);

                toReturn += ((char)(System.Convert.ToInt32((restOfLastTwo / everySecond).ToString("X2"), 16) + 64)).ToString();
                int last = restOfLastTwo - ((restOfLastTwo / everySecond) * everySecond);

                toReturn += ((char)(System.Convert.ToInt32(last.ToString("X2"), 16) + 64)).ToString();
                return toReturn.Replace('@', ' ').Replace('[', '.');
            }
            //Standard approach.
            else
            {
                for (int i = 0; i < data.Length; i++)
                {
                    if (data[i] >= 0x11 && data[i] <= 0x2a)
                        sb.Append(((char)((((int)data[i])) + 65 - 0x11)));
                    else if (data[i] == 0x10)
                        sb.Append(' ');
                    else if (data[i] == 0x2b)
                        sb.Append('.');
                }
            }

            return sb.ToString();
        }

        public byte[] StringToByteArray(string str, bool isLong)
        {
            byte[] data = new byte[str.Length];

            //Marble madness approach.
            if (!isLong)
            {
                int val = 0;

                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] >= 'A' && str[i] <= 'Z')
                        val += ((int)str[i] - (65 - 0x01)) * System.Convert.ToInt32(Math.Pow(32, str.Length - 1 - i));
                    else if (str[i] == '.')
                        val += 27 * System.Convert.ToInt32(Math.Pow(32, str.Length - 1 - i)); //((int)('[') - 64) = 27
                }

                return HiConvert.HexStringToByteArray(val.ToString("X").PadLeft(4, '0'));
            }
            //Standard approach.
            else
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] >= 'A' && str[i] <= 'Z')
                        data[i] = (byte)(((int)str[i] - 65 + 0x11));
                    else if (str[i] == ' ')
                        data[i] = 0x10;
                    else if (str[i] == '.')
                        data[i] = 0x2b;
                }
            }

            return data;
        }

        private int GetAlternateName(string altName)
        {
            switch (altName)
            {
                case "100M WORLD RECORD":
                    return 0;
                case "LONG JUMP WORLD RECORD":
                    return 1;
                case "JAVELIN WORLD RECORD":
                    return 2;
                case "110M HURDLES WORLD RECORD":
                    return 3;
                case "HAMMER TOSS WORLD RECORD":
                    return 4;
                case "HIGH JUMP WORLD RECORD":
                    return 5;
            }
            return -1;
        }

        private string FormatAsDistance(int score)
        {
            if (score == 0)
                return "0.00m";
            string centimeters = score.ToString().Substring(score.ToString().Length - 2);
            return (score.ToString().Substring(0, score.ToString().Length - centimeters.Length) + "." + centimeters + "m").PadLeft(5, '0');
        }

        private string FormatAsTime(int score)
        {
            if (score == 0)
                return "0.00sec";
            string millseconds = score.ToString().Substring(score.ToString().Length - 2);
            return (score.ToString().Substring(0, score.ToString().Length - millseconds.Length) + "." + millseconds + "sec").PadLeft(7, '0');
        }

        private int FormatFromDistance(string score)
        {
            return Convert.ToInt32(score.Replace("m", "").Replace(".", ""));
        }

        private int FormatFromTime(string score)
        {
            return Convert.ToInt32(score.Replace("sec", "").Replace(".", ""));
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]) / 10;
            string name = args[2];

            int rank = NumEntries;
            int offset;

            HiscoreData hiscoreData = new HiscoreData();
            //Do not change the below.
            hiscoreData.Score = HiConvert.IntToByteArrayHex(score, 3);
            hiscoreData.Name = new byte[2];
            HiConvert.ByteArrayCopy(hiscoreData.Name, StringToByteArray(name, false));
            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            #region DETERMINE RANK
            for (int i = 0; i < NumEntries; i++)
            {
                offset = Marshal.SizeOf(typeof(AlternateData)) + (i * Marshal.SizeOf(typeof(HiscoreData))) + 1024;
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

                int offsetOldLoc = Marshal.SizeOf(typeof(AlternateData)) + (i * Marshal.SizeOf(typeof(HiscoreData))) + 1024;
                int offsetNewLoc = Marshal.SizeOf(typeof(AlternateData)) + ((i + 1) * Marshal.SizeOf(typeof(HiscoreData))) + 1024;

                for (int j = 0; j < byteArray.Length; j++)
                    m_data[offsetNewLoc + j] = m_data[offsetOldLoc + j];
            }

            #endregion

            #region REPLACE NEW
            if (rank < NumEntries)
            {
                offset = Marshal.SizeOf(typeof(AlternateData)) + (rank * Marshal.SizeOf(typeof(HiscoreData))) + 1024;

                for (int i = 0; i < byteArray.Length; i++)
                    m_data[offset + i] = byteArray[i];
            }
            #endregion
        }

        public override void SetAlternateScore(string[] args)
        {
            int alternateName = GetAlternateName(args[0]);
            int rankGiven = Convert.ToInt32(args[1]);
            int score = 0;
            switch (alternateName)
            {
                case 0:
                case 3:
                    score = FormatFromTime(args[2]);
                    if (score == 0)
                        score = 9999;
                    break;
                case 1:
                case 2:
                case 4:
                case 5:
                    score = FormatFromDistance(args[2]);
                    break;
            }
            string name = args[3];

            byte[] altArea = new byte[Marshal.SizeOf(typeof(AlternateData))];
            for (int i = 0; i < altArea.Length; i++)
                altArea[i] = m_data[i + 1024];
            AlternateData hiscoreData = (AlternateData)HiConvert.RawDeserialize(altArea, 0, typeof(AlternateData));

            #region DETERMINE_RANK
            int rank = NumAltEntries[alternateName];
            switch (alternateName)
            {
                case 0:
                    if (score < HiConvert.ByteArraySingleBCDToInt(hiscoreData._100mScore1))
                        rank = 0;
                    else if (score < HiConvert.ByteArraySingleBCDToInt(hiscoreData._100mScore2))
                        rank = 1;
                    else if (score < HiConvert.ByteArraySingleBCDToInt(hiscoreData._100mScore3))
                        rank = 2;
                    else if (score < HiConvert.ByteArraySingleBCDToInt(hiscoreData._100mScore4))
                        rank = 3;
                    break;
                case 1:
                    if (score > HiConvert.ByteArraySingleBCDToInt(hiscoreData.LongJumpScore1))
                        rank = 0;
                    else if (score > HiConvert.ByteArraySingleBCDToInt(hiscoreData.LongJumpScore2))
                        rank = 1;
                    else if (score > HiConvert.ByteArraySingleBCDToInt(hiscoreData.LongJumpScore3))
                        rank = 2;
                    else if (score > HiConvert.ByteArraySingleBCDToInt(hiscoreData.LongJumpScore4))
                        rank = 3;
                    break;
                case 2:
                    if (score > HiConvert.ByteArraySingleBCDToInt(hiscoreData.JavelinScore1))
                        rank = 0;
                    else if (score > HiConvert.ByteArraySingleBCDToInt(hiscoreData.JavelinScore2))
                        rank = 1;
                    else if (score > HiConvert.ByteArraySingleBCDToInt(hiscoreData.JavelinScore3))
                        rank = 2;
                    else if (score > HiConvert.ByteArraySingleBCDToInt(hiscoreData.JavelinScore4))
                        rank = 3;
                    break;
                case 3:
                    if (score < HiConvert.ByteArraySingleBCDToInt(hiscoreData._110mHurdlesScore1))
                        rank = 0;
                    else if (score < HiConvert.ByteArraySingleBCDToInt(hiscoreData._110mHurdlesScore2))
                        rank = 1;
                    else if (score < HiConvert.ByteArraySingleBCDToInt(hiscoreData._110mHurdlesScore3))
                        rank = 2;
                    else if (score < HiConvert.ByteArraySingleBCDToInt(hiscoreData._110mHurdlesScore4))
                        rank = 3;
                    break;
                case 4:
                    if (score > HiConvert.ByteArraySingleBCDToInt(hiscoreData.HammerTossScore1))
                        rank = 0;
                    else if (score > HiConvert.ByteArraySingleBCDToInt(hiscoreData.HammerTossScore2))
                        rank = 1;
                    else if (score > HiConvert.ByteArraySingleBCDToInt(hiscoreData.HammerTossScore3))
                        rank = 2;
                    else if (score > HiConvert.ByteArraySingleBCDToInt(hiscoreData.HammerTossScore4))
                        rank = 3;
                    break;
                case 5:
                    if (score > HiConvert.ByteArraySingleBCDToInt(hiscoreData.HighJumpScore1))
                        rank = 0;
                    else if (score > HiConvert.ByteArraySingleBCDToInt(hiscoreData.HighJumpScore2))
                        rank = 1;
                    else if (score > HiConvert.ByteArraySingleBCDToInt(hiscoreData.HighJumpScore3))
                        rank = 2;
                    else if (score > HiConvert.ByteArraySingleBCDToInt(hiscoreData.HighJumpScore4))
                        rank = 3;
                    break;
            }
            #endregion

            #region ADJUST
            int adjust = NumAltEntries[alternateName] - 1;
            if (rank < NumAltEntries[alternateName] - 1)
                adjust = NumAltEntries[alternateName] - 2;

            switch (alternateName)
            {
                case 0:
                    switch (adjust)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(hiscoreData._100mScore2, hiscoreData._100mScore1);
                            HiConvert.ByteArrayCopy(hiscoreData._100mName2, hiscoreData._100mName1);
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(hiscoreData._100mScore3, hiscoreData._100mScore2);
                            HiConvert.ByteArrayCopy(hiscoreData._100mName3, hiscoreData._100mName2);
                            if (rank < 1)
                                goto case 0;
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(hiscoreData._100mScore4, hiscoreData._100mScore3);
                            HiConvert.ByteArrayCopy(hiscoreData._100mName4, hiscoreData._100mName3);
                            if (rank < 2)
                                goto case 1;
                            break;
                    }
                    break;
                case 1:
                    switch (adjust)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(hiscoreData.LongJumpScore2, hiscoreData.LongJumpScore1);
                            HiConvert.ByteArrayCopy(hiscoreData.LongJumpName2, hiscoreData.LongJumpName1);
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(hiscoreData.LongJumpScore3, hiscoreData.LongJumpScore2);
                            HiConvert.ByteArrayCopy(hiscoreData.LongJumpName3, hiscoreData.LongJumpName2);
                            if (rank < 1)
                                goto case 0;
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(hiscoreData.LongJumpScore4, hiscoreData.LongJumpScore3);
                            HiConvert.ByteArrayCopy(hiscoreData.LongJumpName4, hiscoreData.LongJumpName3);
                            if (rank < 2)
                                goto case 1;
                            break;
                    }
                    break;
                case 2:
                    switch (adjust)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(hiscoreData.JavelinScore2, hiscoreData.JavelinScore1);
                            HiConvert.ByteArrayCopy(hiscoreData.JavelinName2, hiscoreData.JavelinName1);
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(hiscoreData.JavelinScore3, hiscoreData.JavelinScore2);
                            HiConvert.ByteArrayCopy(hiscoreData.JavelinName3, hiscoreData.JavelinName2);
                            if (rank < 1)
                                goto case 0;
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(hiscoreData.JavelinScore4, hiscoreData.JavelinScore3);
                            HiConvert.ByteArrayCopy(hiscoreData.JavelinName4, hiscoreData.JavelinName3);
                            if (rank < 2)
                                goto case 1;
                            break;
                    }
                    break;
                case 3:
                    switch (adjust)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(hiscoreData._110mHurdlesScore2, hiscoreData._110mHurdlesScore1);
                            HiConvert.ByteArrayCopy(hiscoreData._110mHurdlesName2, hiscoreData._110mHurdlesName1);
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(hiscoreData._110mHurdlesScore3, hiscoreData._110mHurdlesScore2);
                            HiConvert.ByteArrayCopy(hiscoreData._110mHurdlesName3, hiscoreData._110mHurdlesName2);
                            if (rank < 1)
                                goto case 0;
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(hiscoreData._110mHurdlesScore4, hiscoreData._110mHurdlesScore3);
                            HiConvert.ByteArrayCopy(hiscoreData._110mHurdlesName4, hiscoreData._110mHurdlesName3);
                            if (rank < 2)
                                goto case 1;
                            break;
                    }
                    break;
                case 4:
                    switch (adjust)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(hiscoreData.HammerTossScore2, hiscoreData.HammerTossScore1);
                            HiConvert.ByteArrayCopy(hiscoreData.HammerTossName2, hiscoreData.HammerTossName1);
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(hiscoreData.HammerTossScore3, hiscoreData.HammerTossScore2);
                            HiConvert.ByteArrayCopy(hiscoreData.HammerTossName3, hiscoreData.HammerTossName2);
                            if (rank < 1)
                                goto case 0;
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(hiscoreData.HammerTossScore4, hiscoreData.HammerTossScore3);
                            HiConvert.ByteArrayCopy(hiscoreData.HammerTossName4, hiscoreData.HammerTossName3);
                            if (rank < 2)
                                goto case 1;
                            break;
                    }
                    break;
                case 5:
                    switch (adjust)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(hiscoreData.HighJumpScore2, hiscoreData.HighJumpScore1);
                            HiConvert.ByteArrayCopy(hiscoreData.HighJumpName2, hiscoreData.HighJumpName1);
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(hiscoreData.HighJumpScore3, hiscoreData.HighJumpScore2);
                            HiConvert.ByteArrayCopy(hiscoreData.HighJumpName3, hiscoreData.HighJumpName2);
                            if (rank < 1)
                                goto case 0;
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(hiscoreData.HighJumpScore4, hiscoreData.HighJumpScore3);
                            HiConvert.ByteArrayCopy(hiscoreData.HighJumpName4, hiscoreData.HighJumpName3);
                            if (rank < 2)
                                goto case 1;
                            break;
                    }
                    break;
            }
            #endregion

            #region REPLACE_NEW
            switch (alternateName)
            {
                case 0:
                    switch (rank)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(hiscoreData._100mName1, StringToByteArray(name, true));
                            HiConvert.ByteArrayCopy(hiscoreData._100mScore1, HiConvert.IntToByteArraySingleBCD(score, hiscoreData._100mScore1.Length));
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(hiscoreData._100mName2, StringToByteArray(name, true));
                            HiConvert.ByteArrayCopy(hiscoreData._100mScore2, HiConvert.IntToByteArraySingleBCD(score, hiscoreData._100mScore2.Length));
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(hiscoreData._100mName3, StringToByteArray(name, true));
                            HiConvert.ByteArrayCopy(hiscoreData._100mScore3, HiConvert.IntToByteArraySingleBCD(score, hiscoreData._100mScore3.Length));
                            break;
                        case 3:
                            HiConvert.ByteArrayCopy(hiscoreData._100mName4, StringToByteArray(name, true));
                            HiConvert.ByteArrayCopy(hiscoreData._100mScore4, HiConvert.IntToByteArraySingleBCD(score, hiscoreData._100mScore4.Length));
                            break;
                    }
                    break;
                case 1:
                    switch (rank)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(hiscoreData.LongJumpName1, StringToByteArray(name, true));
                            HiConvert.ByteArrayCopy(hiscoreData.LongJumpScore1, HiConvert.IntToByteArraySingleBCD(score, hiscoreData.LongJumpScore1.Length));
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(hiscoreData.LongJumpName2, StringToByteArray(name, true));
                            HiConvert.ByteArrayCopy(hiscoreData.LongJumpScore2, HiConvert.IntToByteArraySingleBCD(score, hiscoreData.LongJumpScore2.Length));
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(hiscoreData.LongJumpName3, StringToByteArray(name, true));
                            HiConvert.ByteArrayCopy(hiscoreData.LongJumpScore3, HiConvert.IntToByteArraySingleBCD(score, hiscoreData.LongJumpScore3.Length));
                            break;
                        case 3:
                            HiConvert.ByteArrayCopy(hiscoreData.LongJumpName4, StringToByteArray(name, true));
                            HiConvert.ByteArrayCopy(hiscoreData.LongJumpScore4, HiConvert.IntToByteArraySingleBCD(score, hiscoreData.LongJumpScore4.Length));
                            break;
                    }
                    break;
                case 2:
                    switch (rank)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(hiscoreData.JavelinName1, StringToByteArray(name, true));
                            HiConvert.ByteArrayCopy(hiscoreData.JavelinScore1, HiConvert.IntToByteArraySingleBCD(score, hiscoreData.JavelinScore1.Length));
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(hiscoreData.JavelinName2, StringToByteArray(name, true));
                            HiConvert.ByteArrayCopy(hiscoreData.JavelinScore2, HiConvert.IntToByteArraySingleBCD(score, hiscoreData.JavelinScore2.Length));
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(hiscoreData.JavelinName3, StringToByteArray(name, true));
                            HiConvert.ByteArrayCopy(hiscoreData.JavelinScore3, HiConvert.IntToByteArraySingleBCD(score, hiscoreData.JavelinScore3.Length));
                            break;
                        case 3:
                            HiConvert.ByteArrayCopy(hiscoreData.JavelinName4, StringToByteArray(name, true));
                            HiConvert.ByteArrayCopy(hiscoreData.JavelinScore4, HiConvert.IntToByteArraySingleBCD(score, hiscoreData.JavelinScore4.Length));
                            break;
                    }
                    break;
                case 3:
                    switch (rank)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(hiscoreData._110mHurdlesName1, StringToByteArray(name, true));
                            HiConvert.ByteArrayCopy(hiscoreData._110mHurdlesScore1, HiConvert.IntToByteArraySingleBCD(score, hiscoreData._110mHurdlesScore1.Length));
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(hiscoreData._110mHurdlesName2, StringToByteArray(name, true));
                            HiConvert.ByteArrayCopy(hiscoreData._110mHurdlesScore2, HiConvert.IntToByteArraySingleBCD(score, hiscoreData._110mHurdlesScore2.Length));
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(hiscoreData._110mHurdlesName3, StringToByteArray(name, true));
                            HiConvert.ByteArrayCopy(hiscoreData._110mHurdlesScore3, HiConvert.IntToByteArraySingleBCD(score, hiscoreData._110mHurdlesScore3.Length));
                            break;
                        case 3:
                            HiConvert.ByteArrayCopy(hiscoreData._110mHurdlesName4, StringToByteArray(name, true));
                            HiConvert.ByteArrayCopy(hiscoreData._110mHurdlesScore4, HiConvert.IntToByteArraySingleBCD(score, hiscoreData._110mHurdlesScore4.Length));
                            break;
                    }
                    break;
                case 4:
                    switch (rank)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(hiscoreData.HammerTossName1, StringToByteArray(name, true));
                            HiConvert.ByteArrayCopy(hiscoreData.HammerTossScore1, HiConvert.IntToByteArraySingleBCD(score, hiscoreData.HammerTossScore1.Length));
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(hiscoreData.HammerTossName2, StringToByteArray(name, true));
                            HiConvert.ByteArrayCopy(hiscoreData.HammerTossScore2, HiConvert.IntToByteArraySingleBCD(score, hiscoreData.HammerTossScore2.Length));
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(hiscoreData.HammerTossName3, StringToByteArray(name, true));
                            HiConvert.ByteArrayCopy(hiscoreData.HammerTossScore3, HiConvert.IntToByteArraySingleBCD(score, hiscoreData.HammerTossScore3.Length));
                            break;
                        case 3:
                            HiConvert.ByteArrayCopy(hiscoreData.HammerTossName4, StringToByteArray(name, true));
                            HiConvert.ByteArrayCopy(hiscoreData.HammerTossScore4, HiConvert.IntToByteArraySingleBCD(score, hiscoreData.HammerTossScore4.Length));
                            break;
                    }
                    break;
                case 5:
                    switch (rank)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(hiscoreData.HighJumpName1, StringToByteArray(name, true));
                            HiConvert.ByteArrayCopy(hiscoreData.HighJumpScore1, HiConvert.IntToByteArraySingleBCD(score, hiscoreData.HighJumpScore1.Length));
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(hiscoreData.HighJumpName2, StringToByteArray(name, true));
                            HiConvert.ByteArrayCopy(hiscoreData.HighJumpScore2, HiConvert.IntToByteArraySingleBCD(score, hiscoreData.HighJumpScore2.Length));
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(hiscoreData.HighJumpName3, StringToByteArray(name, true));
                            HiConvert.ByteArrayCopy(hiscoreData.HighJumpScore3, HiConvert.IntToByteArraySingleBCD(score, hiscoreData.HighJumpScore3.Length));
                            break;
                        case 3:
                            HiConvert.ByteArrayCopy(hiscoreData.HighJumpName4, StringToByteArray(name, true));
                            HiConvert.ByteArrayCopy(hiscoreData.HighJumpScore4, HiConvert.IntToByteArraySingleBCD(score, hiscoreData.HighJumpScore4.Length));
                            break;
                    }
                    break;
            }
            #endregion

            byte[] byteArray = new byte[m_data.Length];
            byte[] scoreArray = HiConvert.RawSerialize(hiscoreData);

            for (int i = 1024; i < byteArray.Length; i++)
            {
                if (i < scoreArray.Length + 1024)
                    byteArray[i] = scoreArray[i - 1024];
                else
                    byteArray[i] = m_data[i];
            }

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        {
            for (int i = 0; i < NumEntries; i++)
            {
                m_data[Marshal.SizeOf(typeof(AlternateData)) + (i * Marshal.SizeOf(typeof(HiscoreData))) + 1024] = 0x00;
                m_data[Marshal.SizeOf(typeof(AlternateData)) + (i * Marshal.SizeOf(typeof(HiscoreData))) + 1024 + 1] = 0x00;
                m_data[Marshal.SizeOf(typeof(AlternateData)) + (i * Marshal.SizeOf(typeof(HiscoreData))) + 1024 + 2] = 0x00;
            }

            AlternateData hiscoreData = (AlternateData)HiConvert.RawDeserialize(m_data, 1024, typeof(AlternateData));

            HiConvert.ByteArrayCopy(hiscoreData._100mScore1, HiConvert.IntToByteArrayHex(0, hiscoreData._100mScore1.Length));
            HiConvert.ByteArrayCopy(hiscoreData._100mScore2, HiConvert.IntToByteArrayHex(0, hiscoreData._100mScore2.Length));
            HiConvert.ByteArrayCopy(hiscoreData._100mScore3, HiConvert.IntToByteArrayHex(0, hiscoreData._100mScore3.Length));
            HiConvert.ByteArrayCopy(hiscoreData._100mScore4, HiConvert.IntToByteArrayHex(0, hiscoreData._100mScore4.Length));
            HiConvert.ByteArrayCopy(hiscoreData.LongJumpScore1, HiConvert.IntToByteArrayHex(0, hiscoreData.LongJumpScore1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.LongJumpScore2, HiConvert.IntToByteArrayHex(0, hiscoreData.LongJumpScore2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.LongJumpScore3, HiConvert.IntToByteArrayHex(0, hiscoreData.LongJumpScore3.Length));
            HiConvert.ByteArrayCopy(hiscoreData.LongJumpScore4, HiConvert.IntToByteArrayHex(0, hiscoreData.LongJumpScore4.Length));
            HiConvert.ByteArrayCopy(hiscoreData.JavelinScore1, HiConvert.IntToByteArrayHex(0, hiscoreData.JavelinScore1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.JavelinScore2, HiConvert.IntToByteArrayHex(0, hiscoreData.JavelinScore2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.JavelinScore3, HiConvert.IntToByteArrayHex(0, hiscoreData.JavelinScore3.Length));
            HiConvert.ByteArrayCopy(hiscoreData.JavelinScore4, HiConvert.IntToByteArrayHex(0, hiscoreData.JavelinScore4.Length));
            HiConvert.ByteArrayCopy(hiscoreData._110mHurdlesScore1, HiConvert.IntToByteArrayHex(0, hiscoreData._110mHurdlesScore1.Length));
            HiConvert.ByteArrayCopy(hiscoreData._110mHurdlesScore2, HiConvert.IntToByteArrayHex(0, hiscoreData._110mHurdlesScore2.Length));
            HiConvert.ByteArrayCopy(hiscoreData._110mHurdlesScore3, HiConvert.IntToByteArrayHex(0, hiscoreData._110mHurdlesScore3.Length));
            HiConvert.ByteArrayCopy(hiscoreData._110mHurdlesScore4, HiConvert.IntToByteArrayHex(0, hiscoreData._110mHurdlesScore4.Length));
            HiConvert.ByteArrayCopy(hiscoreData.HammerTossScore1, HiConvert.IntToByteArrayHex(0, hiscoreData.HammerTossScore1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.HammerTossScore2, HiConvert.IntToByteArrayHex(0, hiscoreData.HammerTossScore2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.HammerTossScore3, HiConvert.IntToByteArrayHex(0, hiscoreData.HammerTossScore3.Length));
            HiConvert.ByteArrayCopy(hiscoreData.HammerTossScore4, HiConvert.IntToByteArrayHex(0, hiscoreData.HammerTossScore4.Length));
            HiConvert.ByteArrayCopy(hiscoreData.HighJumpScore1, HiConvert.IntToByteArrayHex(0, hiscoreData.HighJumpScore1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.HighJumpScore2, HiConvert.IntToByteArrayHex(0, hiscoreData.HighJumpScore2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.HighJumpScore3, HiConvert.IntToByteArrayHex(0, hiscoreData.HighJumpScore3.Length));
            HiConvert.ByteArrayCopy(hiscoreData.HighJumpScore4, HiConvert.IntToByteArrayHex(0, hiscoreData.HighJumpScore4.Length));

            byte[] byteArray = new byte[m_data.Length];
            byte[] scoreArray = HiConvert.RawSerialize(hiscoreData);

            for (int i = 0; i < byteArray.Length; i++)
            {
                if (i < scoreArray.Length)
                    byteArray[i] = scoreArray[i];
                else
                    byteArray[i] = m_data[i + 1024];
            }

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = Format + Environment.NewLine;

            for (int i = 0; i < NumEntries; i++)
            {
                HiscoreData hiscoreData = new HiscoreData();
                hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, Marshal.SizeOf(typeof(AlternateData)) + (i * Marshal.SizeOf(typeof(HiscoreData)) + 1024), typeof(HiscoreData));

                retString += String.Format("{0}|{1}|{2}",
                    i + 1,
                    HiConvert.ByteArrayHexToInt(hiscoreData.Score) * 10,
                    ByteArrayToString(hiscoreData.Name) + Environment.NewLine);
            }

            byte[] altArea = new byte[Marshal.SizeOf(typeof(AlternateData))];
            for (int i = 0; i < altArea.Length; i++)
                altArea[i] = m_data[i + 1024];
            AlternateData altData = (AlternateData)HiConvert.RawDeserialize(altArea, 0, typeof(AlternateData));

            retString += Environment.NewLine + Environment.NewLine + AltFormat[0] + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 1, FormatAsTime(HiConvert.ByteArraySingleBCDToInt(altData._100mScore1)), ByteArrayToString(altData._100mName1)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 2, FormatAsTime(HiConvert.ByteArraySingleBCDToInt(altData._100mScore2)), ByteArrayToString(altData._100mName2)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 3, FormatAsTime(HiConvert.ByteArraySingleBCDToInt(altData._100mScore3)), ByteArrayToString(altData._100mName3)) + Environment.NewLine;
            retString += AltFormat[1] + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 1, FormatAsDistance(HiConvert.ByteArraySingleBCDToInt(altData.LongJumpScore1)), ByteArrayToString(altData.LongJumpName1)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 2, FormatAsDistance(HiConvert.ByteArraySingleBCDToInt(altData.LongJumpScore2)), ByteArrayToString(altData.LongJumpName2)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 3, FormatAsDistance(HiConvert.ByteArraySingleBCDToInt(altData.LongJumpScore3)), ByteArrayToString(altData.LongJumpName3)) + Environment.NewLine;
            retString += AltFormat[2] + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 1, FormatAsDistance(HiConvert.ByteArraySingleBCDToInt(altData.JavelinScore1)), ByteArrayToString(altData.JavelinName1)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 2, FormatAsDistance(HiConvert.ByteArraySingleBCDToInt(altData.JavelinScore2)), ByteArrayToString(altData.JavelinName2)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 3, FormatAsDistance(HiConvert.ByteArraySingleBCDToInt(altData.JavelinScore3)), ByteArrayToString(altData.JavelinName3)) + Environment.NewLine;
            retString += AltFormat[3] + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 1, FormatAsTime(HiConvert.ByteArraySingleBCDToInt(altData._110mHurdlesScore1)), ByteArrayToString(altData._110mHurdlesName1)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 2, FormatAsTime(HiConvert.ByteArraySingleBCDToInt(altData._110mHurdlesScore2)), ByteArrayToString(altData._110mHurdlesName2)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 3, FormatAsTime(HiConvert.ByteArraySingleBCDToInt(altData._110mHurdlesScore3)), ByteArrayToString(altData._110mHurdlesName3)) + Environment.NewLine;
            retString += AltFormat[4] + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 1, FormatAsDistance(HiConvert.ByteArraySingleBCDToInt(altData.HammerTossScore1)), ByteArrayToString(altData.HammerTossName1)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 2, FormatAsDistance(HiConvert.ByteArraySingleBCDToInt(altData.HammerTossScore2)), ByteArrayToString(altData.HammerTossName2)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 3, FormatAsDistance(HiConvert.ByteArraySingleBCDToInt(altData.HammerTossScore3)), ByteArrayToString(altData.HammerTossName3)) + Environment.NewLine;
            retString += AltFormat[5] + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 1, FormatAsDistance(HiConvert.ByteArraySingleBCDToInt(altData.HighJumpScore1)), ByteArrayToString(altData.HighJumpName1)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 2, FormatAsDistance(HiConvert.ByteArraySingleBCDToInt(altData.HighJumpScore2)), ByteArrayToString(altData.HighJumpName2)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 3, FormatAsDistance(HiConvert.ByteArraySingleBCDToInt(altData.HighJumpScore3)), ByteArrayToString(altData.HighJumpName3)) + Environment.NewLine;

            return retString;
        }
    }
}