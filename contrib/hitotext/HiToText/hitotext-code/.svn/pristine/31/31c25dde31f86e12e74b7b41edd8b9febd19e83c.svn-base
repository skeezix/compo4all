using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class digdug2 : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Score1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Unknown1;
            public byte Round1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Score2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Unknown2;
            public byte Round2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Score3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Unknown3;
            public byte Round3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Score4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Unknown4;
            public byte Round4;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Score5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Unknown5;
            public byte Round5;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] HiShort;
            public byte HiFiller;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] HiLong;
        }

        public digdug2()
        {
            m_numEntries = 5;
            m_format = "RANK|SCORE|NAME|ROUND";
            m_gamesSupported = "digdug2,digdug2a,digdug2o";
            m_extensionsRequired = ".hi";
        }                               

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] >= 0x41 && data[i] <= 0x5a)
                    sb.Append((char)(int)data[i]);
                else if (data[i] == 0x5b)
                    sb.Append('.');
                else if (data[i] == 0x20)
                    sb.Append(' ');
            }

            return sb.ToString();
        }

        public byte[] StringToByteArray(string str)
        {
            byte[] data = new byte[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 'A' && str[i] <= 'Z')
                    data[i] = (byte)((int)str[i]);
                else if (str[i] == '.')
                    data[i] = 0x5b;
                else if (str[i] == ' ')
                    data[i] = 0x20;
            }

            return data;
        }

        public byte[] ScoreToByteArray(int score, bool isHighScore)
        {
            int numDigitsInScore = 6;
            StringBuilder sb = new StringBuilder();
            String strScore = score.ToString();
            if (isHighScore)
                strScore = strScore.PadLeft(numDigitsInScore, 'F');
            else
                strScore = strScore.PadLeft(numDigitsInScore, '0');

            for (int i = 0; i < numDigitsInScore; i++)
            {
                if (isHighScore)
                {
                    if (strScore[i].Equals('F'))
                        sb.Insert(0, "20");
                    else
                        sb.Insert(0, "0" + strScore[i].ToString());
                }
                else
                    sb.Insert(0, "0" + strScore[i].ToString());
            }

            return HiConvert.HexStringToByteArray(sb.ToString());
        }

        public int ByteArrayToScore(byte[] byteData)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < byteData.Length; i++)
            {
                byte[] newData = HiConvert.HexStringToByteArray(byteData[i].ToString("X2"));
                if (newData[0] == 0x20) //Empty byte for display purposes.
                    sb.Insert(0, "0");
                else
                    sb.Insert(0, newData[0]);
            }

            return Int32.Parse(sb.ToString());
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]) / 10;
            string name = args[2];
            int round = System.Convert.ToInt32(args[3]);

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = 5;
            if (score > ByteArrayToScore(HiConvert.ReverseByteArray(hiscoreData.Score1)))
                rank = 0;
            else if (score > ByteArrayToScore(HiConvert.ReverseByteArray(hiscoreData.Score2)))
                rank = 1;
            else if (score > ByteArrayToScore(HiConvert.ReverseByteArray(hiscoreData.Score3)))
                rank = 2;
            else if (score > ByteArrayToScore(HiConvert.ReverseByteArray(hiscoreData.Score4)))
                rank = 3;
            else if (score > ByteArrayToScore(HiConvert.ReverseByteArray(hiscoreData.Score5)))
                rank = 4;
            #endregion

            #region ADJUST
            int adjust = 4;
            if (rank < 4)
                adjust = 3;
            switch (adjust)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, hiscoreData.Score1);
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, hiscoreData.Name1);
                    hiscoreData.Round2 = hiscoreData.Round1;
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
                    hiscoreData.Round3 = hiscoreData.Round2;
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, hiscoreData.Score3);
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, hiscoreData.Name3);
                    hiscoreData.Round4 = hiscoreData.Round3;
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, hiscoreData.Score4);
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, hiscoreData.Name4);
                    hiscoreData.Round5 = hiscoreData.Round4;
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
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.ReverseByteArray(ScoreToByteArray(score, false)));
                    HiConvert.ByteArrayCopy(hiscoreData.HiShort, HiConvert.HexStringToByteArray(score.ToString("D6")));
                    HiConvert.ByteArrayCopy(hiscoreData.HiLong, ScoreToByteArray(score, true));
                    HiConvert.ByteArrayCopy(hiscoreData.Name1, StringToByteArray(name));
                    hiscoreData.Round1 = HiConvert.HexStringToByteArray(round.ToString("D2"))[0];
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.ReverseByteArray(ScoreToByteArray(score, false)));
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name));
                    hiscoreData.Round2 = HiConvert.HexStringToByteArray(round.ToString("D2"))[0];
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.ReverseByteArray(ScoreToByteArray(score, false)));
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name));
                    hiscoreData.Round3 = HiConvert.HexStringToByteArray(round.ToString("D2"))[0];
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.ReverseByteArray(ScoreToByteArray(score, false)));
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name));
                    hiscoreData.Round4 = HiConvert.HexStringToByteArray(round.ToString("D2"))[0];
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.ReverseByteArray(ScoreToByteArray(score, false)));
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name));
                    hiscoreData.Round5 = HiConvert.HexStringToByteArray(round.ToString("D2"))[0];
                    break;
                default:
                    break;
            }
            #endregion

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));
            
            HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.IntToByteArrayHex(0, hiscoreData.Score1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.IntToByteArrayHex(0, hiscoreData.Score2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.IntToByteArrayHex(0, hiscoreData.Score3.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.IntToByteArrayHex(0, hiscoreData.Score4.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.IntToByteArrayHex(0, hiscoreData.Score5.Length));
            
            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}|{1}|{2}|{3}", 1, ByteArrayToScore(HiConvert.ReverseByteArray(hiscoreData.Score1)) * 10, ByteArrayToString(hiscoreData.Name1), System.Convert.ToInt32(hiscoreData.Round1.ToString("X2"))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 2, ByteArrayToScore(HiConvert.ReverseByteArray(hiscoreData.Score2)) * 10, ByteArrayToString(hiscoreData.Name2), System.Convert.ToInt32(hiscoreData.Round2.ToString("X2"))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 3, ByteArrayToScore(HiConvert.ReverseByteArray(hiscoreData.Score3)) * 10, ByteArrayToString(hiscoreData.Name3), System.Convert.ToInt32(hiscoreData.Round3.ToString("X2"))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 4, ByteArrayToScore(HiConvert.ReverseByteArray(hiscoreData.Score4)) * 10, ByteArrayToString(hiscoreData.Name4), System.Convert.ToInt32(hiscoreData.Round4.ToString("X2"))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 5, ByteArrayToScore(HiConvert.ReverseByteArray(hiscoreData.Score5)) * 10, ByteArrayToString(hiscoreData.Name5), System.Convert.ToInt32(hiscoreData.Round5.ToString("X2"))) + Environment.NewLine;

            return retString;
        }
    }
}
