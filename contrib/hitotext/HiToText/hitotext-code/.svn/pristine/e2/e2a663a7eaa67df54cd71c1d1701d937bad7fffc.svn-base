using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class suprmrio : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] World1;
            public byte Spacer1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] World2;
            public byte Spacer2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] World3;
            public byte Spacer3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] World4;
            public byte Spacer4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] World5;
            public byte Spacer5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] World6;
            public byte Spacer6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] World7;
            public byte Spacer7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] World8;
            public byte Spacer8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] World9;
            public byte Spacer9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] World10;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name10;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            public byte[] MiddleSpace;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score10;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] HiScore;
        }

        public suprmrio()
        {
            m_numEntries = 10;
            m_format = "RANK|SCORE|NAME|WORLD";
            m_gamesSupported = "suprmrio";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] >= 0x0a && data[i] <= 0x23)
                    sb.Append(((char)(((int)data[i]) + 65 - 0x0a)));
                else if (data[i] == 0xfa)
                    sb.Append('\'');
                else if (data[i] == 0x2b)
                    sb.Append('!');
                else if (data[i] == 0x28)
                    sb.Append('-');
                else if (data[i] == 0xaf)
                    sb.Append('.');
                else if (data[i] == 0x24)
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
                    data[i] = (byte)((int)str[i] - 65 + 0x0a);
                else if (str[i] == '.')
                    data[i] = 0xaf;
                else if (str[i] == '\'')
                    data[i] = 0xfa;
                else if (str[i] == '!')
                    data[i] = 0x2b;
                else if (str[i] == '-')
                    data[i] = 0x28;
                else if (str[i] == ' ')
                    data[i] = 0x24;
            }

            return data;
        }

        public int ByteArrayToScore(byte[] byteData)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < byteData.Length; i++)
            {
                byte[] newData = HiConvert.HexStringToByteArray(byteData[i].ToString("X2"));
                sb.Append(newData[0]);
            }

            return Int32.Parse(sb.ToString());
        }

        public byte[] ScoreToByteArray(int score)
        {
            int bytesInScore = 7;
            StringBuilder sb = new StringBuilder();
            byte[] byteArray = new byte[bytesInScore];
            string scoreAsString = score.ToString().PadLeft(bytesInScore, '0');

            for (int i = 0; i < byteArray.Length; i++)
                sb.Append("0" + scoreAsString[i]);
            
            return HiConvert.HexStringToByteArray(sb.ToString());
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2];
            int world = System.Convert.ToInt32(args[3].Replace("W-", "0"));

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = 10;
            if (score > ByteArrayToScore(hiscoreData.Score1))
                rank = 0;
            else if (score > ByteArrayToScore(hiscoreData.Score2))
                rank = 1;
            else if (score > ByteArrayToScore(hiscoreData.Score3))
                rank = 2;
            else if (score > ByteArrayToScore(hiscoreData.Score4))
                rank = 3;
            else if (score > ByteArrayToScore(hiscoreData.Score5))
                rank = 4;
            else if (score > ByteArrayToScore(hiscoreData.Score6))
                rank = 5;
            else if (score > ByteArrayToScore(hiscoreData.Score7))
                rank = 6;
            else if (score > ByteArrayToScore(hiscoreData.Score8))
                rank = 7;
            else if (score > ByteArrayToScore(hiscoreData.Score9))
                rank = 8;
            else if (score > ByteArrayToScore(hiscoreData.Score10))
                rank = 9;
            #endregion

            #region ADJUST
            int adjust = 9;
            if (rank < 9)
                adjust = 8;
            switch (adjust)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.World2, hiscoreData.World1);
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, hiscoreData.Score1);
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, hiscoreData.Name1);
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.World3, hiscoreData.World2);
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.World4, hiscoreData.World3);
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, hiscoreData.Score3);
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, hiscoreData.Name3);
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.World5, hiscoreData.World4);
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, hiscoreData.Score4);
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, hiscoreData.Name4);
                    if (rank < 3)
                        goto case 2;
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.World6, hiscoreData.World5);
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, hiscoreData.Score5);
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, hiscoreData.Name5);
                    if (rank < 4)
                        goto case 3;
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.World7, hiscoreData.World6);
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, hiscoreData.Score6);
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, hiscoreData.Name6);
                    if (rank < 5)
                        goto case 4;
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.World8, hiscoreData.World7);
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, hiscoreData.Score7);
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, hiscoreData.Name7);
                    if (rank < 6)
                        goto case 5;
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.World9, hiscoreData.World8);
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, hiscoreData.Score8);
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, hiscoreData.Name8);
                    if (rank < 7)
                        goto case 6;
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.World10, hiscoreData.World9);
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, hiscoreData.Score9);
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, hiscoreData.Name9);
                    if (rank < 8)
                        goto case 7;
                    break;
                default:
                    break;
            }
            #endregion

            #region REPLACE_NEW
            switch (rank)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.World1, HiConvert.HexStringToByteArray(world.ToString("D4")));
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, ScoreToByteArray(score));
                    HiConvert.ByteArrayCopy(hiscoreData.HiScore, ScoreToByteArray(score));
                    HiConvert.ByteArrayCopy(hiscoreData.Name1, StringToByteArray(name));
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.World2, HiConvert.HexStringToByteArray(world.ToString("D4")));
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, ScoreToByteArray(score));
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name));
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.World3, HiConvert.HexStringToByteArray(world.ToString("D4")));
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, ScoreToByteArray(score));
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name));
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.World4, HiConvert.HexStringToByteArray(world.ToString("D4")));
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, ScoreToByteArray(score));
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name));
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.World5, HiConvert.HexStringToByteArray(world.ToString("D4")));
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, ScoreToByteArray(score));
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name));
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.World6, HiConvert.HexStringToByteArray(world.ToString("D4")));
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, ScoreToByteArray(score));
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, StringToByteArray(name));
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.World7, HiConvert.HexStringToByteArray(world.ToString("D4")));
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, ScoreToByteArray(score));
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, StringToByteArray(name));
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.World8, HiConvert.HexStringToByteArray(world.ToString("D4")));
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, ScoreToByteArray(score));
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, StringToByteArray(name));
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.World9, HiConvert.HexStringToByteArray(world.ToString("D4")));
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, ScoreToByteArray(score));
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, StringToByteArray(name));
                    break;
                case 9:
                    HiConvert.ByteArrayCopy(hiscoreData.World10, HiConvert.HexStringToByteArray(world.ToString("D4")));
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, ScoreToByteArray(score));
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, StringToByteArray(name));
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
            HiConvert.ByteArrayCopy(hiscoreData.Score6, HiConvert.IntToByteArrayHex(0, hiscoreData.Score6.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score7, HiConvert.IntToByteArrayHex(0, hiscoreData.Score7.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score8, HiConvert.IntToByteArrayHex(0, hiscoreData.Score8.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score9, HiConvert.IntToByteArrayHex(0, hiscoreData.Score9.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score10, HiConvert.IntToByteArrayHex(0, hiscoreData.Score10.Length));

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}|{1}|{2}|{3}", 
                1,
                ByteArrayToScore(hiscoreData.Score1),
                ByteArrayToString(hiscoreData.Name1), 
                HiConvert.ByteArrayHexToInt(hiscoreData.World1).ToString().Replace("0", "W-")) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}",
                2,
                ByteArrayToScore(hiscoreData.Score2),
                ByteArrayToString(hiscoreData.Name2),
                HiConvert.ByteArrayHexToInt(hiscoreData.World2).ToString().Replace("0", "W-")) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}",
                3,
                ByteArrayToScore(hiscoreData.Score3),
                ByteArrayToString(hiscoreData.Name3),
                HiConvert.ByteArrayHexToInt(hiscoreData.World3).ToString().Replace("0", "W-")) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}",
                4,
                ByteArrayToScore(hiscoreData.Score4),
                ByteArrayToString(hiscoreData.Name4),
                HiConvert.ByteArrayHexToInt(hiscoreData.World4).ToString().Replace("0", "W-")) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}",
                5,
                ByteArrayToScore(hiscoreData.Score5),
                ByteArrayToString(hiscoreData.Name5),
                HiConvert.ByteArrayHexToInt(hiscoreData.World5).ToString().Replace("0", "W-")) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}",
                6,
                ByteArrayToScore(hiscoreData.Score6),
                ByteArrayToString(hiscoreData.Name6),
                HiConvert.ByteArrayHexToInt(hiscoreData.World6).ToString().Replace("0", "W-")) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}",
                7,
                ByteArrayToScore(hiscoreData.Score7),
                ByteArrayToString(hiscoreData.Name7),
                HiConvert.ByteArrayHexToInt(hiscoreData.World7).ToString().Replace("0", "W-")) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}",
                8,
                ByteArrayToScore(hiscoreData.Score8),
                ByteArrayToString(hiscoreData.Name8),
                HiConvert.ByteArrayHexToInt(hiscoreData.World8).ToString().Replace("0", "W-")) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}",
                9,
                ByteArrayToScore(hiscoreData.Score9),
                ByteArrayToString(hiscoreData.Name9),
                HiConvert.ByteArrayHexToInt(hiscoreData.World9).ToString().Replace("0", "W-")) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}",
                10,
                ByteArrayToScore(hiscoreData.Score10),
                ByteArrayToString(hiscoreData.Name10),
                HiConvert.ByteArrayHexToInt(hiscoreData.World10).ToString().Replace("0", "W-")) + Environment.NewLine;
             
            return retString;
        }
    }
}
