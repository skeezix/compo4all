using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class silkworm : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            #region HELICOPTER
            public byte UnusedH1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreH1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameH1;
            public byte RoundH1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] TimeH1;

            public byte UnusedH2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreH2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameH2;
            public byte RoundH2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] TimeH2;

            public byte UnusedH3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreH3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameH3;
            public byte RoundH3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] TimeH3;

            public byte UnusedH4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreH4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameH4;
            public byte RoundH4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] TimeH4;

            public byte UnusedH5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreH5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameH5;
            public byte RoundH5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] TimeH5;
            #endregion

            #region JEEP
            public byte UnusedJ1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreJ1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameJ1;
            public byte RoundJ1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] TimeJ1;

            public byte UnusedJ2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreJ2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameJ2;
            public byte RoundJ2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] TimeJ2;

            public byte UnusedJ3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreJ3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameJ3;
            public byte RoundJ3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] TimeJ3;

            public byte UnusedJ4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreJ4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameJ4;
            public byte RoundJ4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] TimeJ4;

            public byte UnusedJ5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreJ5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameJ5;
            public byte RoundJ5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] TimeJ5;
            #endregion

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] HiScoreLongJeep;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] HiScoreLongHeli;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] HiScoreShortJeep;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] HiScoreShortHeli;
        }

        public silkworm()
        {
            m_numEntries = 10;
            m_format = "RANK|SCORE|NAME|ROUND|TIME|VEHICLE";
            m_gamesSupported = "silkworm,silkwrm2";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
                sb.Append((char)(int)data[i]);

            return sb.ToString();
        }

        public byte[] StringToByteArray(string str)
        {
            byte[] data = new byte[str.Length];

            for (int i = 0; i < str.Length; i++)
                data[i] = (byte)((int)str[i]);

            return data;
        }

        public byte[] GetTime(string time)
        {
            byte[] toReturn = new byte[2];
            toReturn[0] = HiConvert.IntToByteArrayHexAsHex(Convert.ToInt32(time.Substring(2, 2)), 1)[0];
            toReturn[1] = HiConvert.IntToByteArrayHexAsHex(Convert.ToInt32(time.Substring(time.IndexOf(':') + 1)),1)[0];
            return toReturn;
        }

        public string GetTime(byte[] time)
        {
            return "T-" + Convert.ToInt32(time[0]).ToString().PadLeft(2, '0') + ":" + Convert.ToInt32(time[1]).ToString().PadLeft(2, '0');
        }

        public int GetRound(string round)
        {
            return Convert.ToInt32(round.Substring(round.IndexOf("-") + 1));
        }

        public string GetRound(int round)
        {
            return "R-" + round.ToString().PadLeft(2, '0');
        }

        public byte[] GetHiScore(int score, int numDigitsInScore)
        {
            StringBuilder sb = new StringBuilder();
            String strScore = score.ToString();
            strScore = strScore.PadLeft(numDigitsInScore, 'F');

            for (int i = 0; i < numDigitsInScore; i++)
            {
                if (strScore[i].Equals('F'))
                    sb.Append("20");
                else
                    sb.Append("3" + strScore[i].ToString());
            }

            return HiConvert.HexStringToByteArray(sb.ToString());
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]) / 100;
            string name = args[2];
            int round = GetRound(args[3]);
            byte[] time = GetTime(args[4]);
            string vehicle = args[5];

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region CHAR SELECT AND REPLACE
            int rank = 5;
            int adjust = 4;
            switch (vehicle.ToUpper())
            {
                case "HELICOPTER":

                    #region DETERMINE_RANK
                    if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.ScoreH1)))
                        rank = 0;
                    else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.ScoreH2)))
                        rank = 1;
                    else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.ScoreH3)))
                        rank = 2;
                    else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.ScoreH4)))
                        rank = 3;
                    else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.ScoreH5)))
                        rank = 4;
                    #endregion

                    #region ADJUST
                    if (rank < 4)
                        adjust = 3;
                    switch (adjust)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreH2, hiscoreData.ScoreH1);
                            HiConvert.ByteArrayCopy(hiscoreData.NameH2, hiscoreData.NameH1);
                            HiConvert.ByteArrayCopy(hiscoreData.TimeH2, hiscoreData.TimeH1);
                            hiscoreData.RoundH2 = hiscoreData.RoundH1;
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreH3, hiscoreData.ScoreH2);
                            HiConvert.ByteArrayCopy(hiscoreData.NameH3, hiscoreData.NameH2);
                            HiConvert.ByteArrayCopy(hiscoreData.TimeH3, hiscoreData.TimeH2);
                            hiscoreData.RoundH3 = hiscoreData.RoundH2;
                            if (rank < 1)
                                goto case 0;
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreH4, hiscoreData.ScoreH3);
                            HiConvert.ByteArrayCopy(hiscoreData.NameH4, hiscoreData.NameH3);
                            HiConvert.ByteArrayCopy(hiscoreData.TimeH4, hiscoreData.TimeH3);
                            hiscoreData.RoundH4 = hiscoreData.RoundH3;
                            if (rank < 2)
                                goto case 1;
                            break;
                        case 3:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreH5, hiscoreData.ScoreH4);
                            HiConvert.ByteArrayCopy(hiscoreData.NameH5, hiscoreData.NameH4);
                            HiConvert.ByteArrayCopy(hiscoreData.TimeH5, hiscoreData.TimeH4);
                            hiscoreData.RoundH5 = hiscoreData.RoundH4;
                            if (rank < 3)
                                goto case 2;
                            break;
                        default:
                            break;
                    }
                    #endregion

                    #region REPLACE_NEW
                    switch (rank)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(hiscoreData.NameH1, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreH1, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreH1.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.HiScoreShortHeli, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.HiScoreShortHeli.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.HiScoreLongHeli, GetHiScore(score * 100, hiscoreData.HiScoreLongHeli.Length));
                            HiConvert.ByteArrayCopy(hiscoreData.TimeH1, time);
                            hiscoreData.RoundH1 = (byte)round;
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(hiscoreData.NameH2, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreH2, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreH2.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.TimeH2, time);
                            hiscoreData.RoundH2 = (byte)round;
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(hiscoreData.NameH3, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreH3, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreH3.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.TimeH3, time);
                            hiscoreData.RoundH3 = (byte)round;
                            break;
                        case 3:
                            HiConvert.ByteArrayCopy(hiscoreData.NameH4, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreH4, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreH4.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.TimeH4, time);
                            hiscoreData.RoundH4 = (byte)round;
                            break;
                        case 4:
                            HiConvert.ByteArrayCopy(hiscoreData.NameH5, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreH5, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreH5.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.TimeH5, time);
                            hiscoreData.RoundH5 = (byte)round;
                            break;
                    }
                    #endregion

                    break;

                case "JEEP":

                    #region DETERMINE_RANK
                    if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.ScoreJ1)))
                        rank = 0;
                    else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.ScoreJ2)))
                        rank = 1;
                    else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.ScoreJ3)))
                        rank = 2;
                    else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.ScoreJ4)))
                        rank = 3;
                    else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.ScoreJ5)))
                        rank = 4;
                    #endregion

                    #region ADJUST
                    if (rank < 4)
                        adjust = 3;
                    switch (adjust)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreJ2, hiscoreData.ScoreJ1);
                            HiConvert.ByteArrayCopy(hiscoreData.NameJ2, hiscoreData.NameJ1);
                            HiConvert.ByteArrayCopy(hiscoreData.TimeJ2, hiscoreData.TimeJ1);
                            hiscoreData.RoundJ2 = hiscoreData.RoundJ1;
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreJ3, hiscoreData.ScoreJ2);
                            HiConvert.ByteArrayCopy(hiscoreData.NameJ3, hiscoreData.NameJ2);
                            HiConvert.ByteArrayCopy(hiscoreData.TimeJ3, hiscoreData.TimeJ2);
                            hiscoreData.RoundJ3 = hiscoreData.RoundJ2;
                            if (rank < 1)
                                goto case 0;
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreJ4, hiscoreData.ScoreJ3);
                            HiConvert.ByteArrayCopy(hiscoreData.NameJ4, hiscoreData.NameJ3);
                            HiConvert.ByteArrayCopy(hiscoreData.TimeJ4, hiscoreData.TimeJ3);
                            hiscoreData.RoundJ4 = hiscoreData.RoundJ3;
                            if (rank < 2)
                                goto case 1;
                            break;
                        case 3:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreJ5, hiscoreData.ScoreJ4);
                            HiConvert.ByteArrayCopy(hiscoreData.NameJ5, hiscoreData.NameJ4);
                            HiConvert.ByteArrayCopy(hiscoreData.TimeJ5, hiscoreData.TimeJ4);
                            hiscoreData.RoundJ5 = hiscoreData.RoundJ4;
                            if (rank < 3)
                                goto case 2;
                            break;
                        default:
                            break;
                    }
                    #endregion

                    #region REPLACE_NEW
                    switch (rank)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(hiscoreData.NameJ1, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreJ1, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreJ1.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.HiScoreShortJeep, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.HiScoreShortJeep.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.HiScoreLongJeep, GetHiScore(score * 100, hiscoreData.HiScoreLongJeep.Length));
                            HiConvert.ByteArrayCopy(hiscoreData.TimeJ1, time);
                            hiscoreData.RoundJ1 = (byte)round;
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(hiscoreData.NameJ2, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreJ2, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreJ2.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.TimeJ2, time);
                            hiscoreData.RoundJ2 = (byte)round;
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(hiscoreData.NameJ3, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreJ3, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreJ3.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.TimeJ3, time);
                            hiscoreData.RoundJ3 = (byte)round;
                            break;
                        case 3:
                            HiConvert.ByteArrayCopy(hiscoreData.NameJ4, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreJ4, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreJ4.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.TimeJ4, time);
                            hiscoreData.RoundJ4 = (byte)round;
                            break;
                        case 4:
                            HiConvert.ByteArrayCopy(hiscoreData.NameJ5, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreJ5, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreJ5.Length)));
                            HiConvert.ByteArrayCopy(hiscoreData.TimeJ5, time);
                            hiscoreData.RoundJ5 = (byte)round;
                            break;
                    }
                    #endregion

                    break;
            }
            #endregion

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.ScoreH1, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreH1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreH2, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreH2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreH3, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreH3.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreH4, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreH4.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreH5, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreH5.Length));
            
            HiConvert.ByteArrayCopy(hiscoreData.ScoreJ1, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreJ1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreJ2, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreJ2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreJ3, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreJ3.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreJ4, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreJ4.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreJ5, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreJ5.Length));
            
            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}|{1}|{2}|{3}|{4}|{5}", 1, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.ScoreH1)) * 100, ByteArrayToString(hiscoreData.NameH1), GetRound(hiscoreData.RoundH1), GetTime(hiscoreData.TimeH1), "HELICOPTER") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}|{5}", 2, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.ScoreH2)) * 100, ByteArrayToString(hiscoreData.NameH2), GetRound(hiscoreData.RoundH2), GetTime(hiscoreData.TimeH2), "HELICOPTER") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}|{5}", 3, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.ScoreH3)) * 100, ByteArrayToString(hiscoreData.NameH3), GetRound(hiscoreData.RoundH3), GetTime(hiscoreData.TimeH3), "HELICOPTER") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}|{5}", 4, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.ScoreH4)) * 100, ByteArrayToString(hiscoreData.NameH4), GetRound(hiscoreData.RoundH4), GetTime(hiscoreData.TimeH4), "HELICOPTER") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}|{5}", 5, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.ScoreH5)) * 100, ByteArrayToString(hiscoreData.NameH5), GetRound(hiscoreData.RoundH5), GetTime(hiscoreData.TimeH5), "HELICOPTER") + Environment.NewLine;

            retString += String.Format("{0}|{1}|{2}|{3}|{4}|{5}", 1, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.ScoreJ1)) * 100, ByteArrayToString(hiscoreData.NameJ1), GetRound(hiscoreData.RoundJ1), GetTime(hiscoreData.TimeJ1), "JEEP") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}|{5}", 2, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.ScoreJ2)) * 100, ByteArrayToString(hiscoreData.NameJ2), GetRound(hiscoreData.RoundJ2), GetTime(hiscoreData.TimeJ2), "JEEP") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}|{5}", 3, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.ScoreJ3)) * 100, ByteArrayToString(hiscoreData.NameJ3), GetRound(hiscoreData.RoundJ3), GetTime(hiscoreData.TimeJ3), "JEEP") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}|{5}", 4, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.ScoreJ4)) * 100, ByteArrayToString(hiscoreData.NameJ4), GetRound(hiscoreData.RoundJ4), GetTime(hiscoreData.TimeJ4), "JEEP") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}|{5}", 5, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.ScoreJ5)) * 100, ByteArrayToString(hiscoreData.NameJ5), GetRound(hiscoreData.RoundJ5), GetTime(hiscoreData.TimeJ5), "JEEP") + Environment.NewLine;
            
            return retString;
        }

        public override String[] OptimizeScoresForGame(String[] webScores)
        {
            List<String[]> Heli = new List<String[]>();
            List<String[]> Jeep = new List<String[]>();

            for (int i = 0; i < webScores.Length; i++)
            {
                String[] webScore = webScores[i].Split(new char[] { '|' });
                switch (webScore[4].ToUpper())
                {
                    case "HELICOPTER":
                        Heli.Add(webScore);
                        break;
                    case "JEEP":
                        Jeep.Add(webScore);
                        break;
                }
            }

            Heli.Sort(new SilkwormComparator());
            Jeep.Sort(new SilkwormComparator());

            String[] toReturn = new String[NumEntries];

            for (int i = 0; i < NumEntries; i++)
            {
                switch (i / 5)
                {
                    case 0:
                        toReturn[i] = String.Join("|", Heli[i % 10]);
                        break;
                    case 1:
                        toReturn[i] = String.Join("|", Jeep[i % 10]);
                        break;
                }
            }
            return toReturn;
        }
    }

    class SilkwormComparator : IComparer<String[]>
    {

        #region IComparer<string[]> Members

        int IComparer<string[]>.Compare(string[] x, string[] y)
        {
            return Convert.ToInt32(y[1]).CompareTo(Convert.ToInt32(x[1]));
        }

        #endregion
    }
}