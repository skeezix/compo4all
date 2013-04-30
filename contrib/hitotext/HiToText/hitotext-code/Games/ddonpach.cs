using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class ddonpach : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score5;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name5;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] AreaPartB1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] AreaPartB2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] AreaPartB3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] AreaPartB4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] AreaPartB5;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] AreaPartA1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] AreaPartA2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] AreaPartA3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] AreaPartA4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] AreaPartA5;

            public byte Character1;
            public byte Character2;
            public byte Character3;
            public byte Character4;
            public byte Character5;

            public byte Powerup1;
            public byte Powerup2;
            public byte Powerup3;
            public byte Powerup4;
            public byte Powerup5;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] MaxHit1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] MaxHit2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] MaxHit3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] MaxHit4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] MaxHit5;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] LastScore1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] LastScore2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] LastScore3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] LastScore4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] LastScore5;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] HiScore;
        }

        public ddonpach()
        {
            m_numEntries = 5;
            m_format = "RANK|SCORE|NAME|AREA|CHARACTER|POWERUP|MAXHIT";
            m_gamesSupported = "ddonpach";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 1; i < data.Length; i = i + 1)
            {
                if (data[i] >= 0x84 && data[i] <= 0xe8)
                    sb.Append(((char)((((int)data[i]) / 4) + 65 - 0x21)));
                else if (data[i] == 0x38)
                    sb.Append('.');
                else if (data[i] == 0x00)
                    sb.Append(' ');
            }

            return sb.ToString();
        }

        public byte[] StringToByteArray(string str)
        {
            byte[] data = new byte[str.Length * 2];
            for (int i = 0; i < data.Length; i++)
                data[i] = 0x01;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 'A' && str[i] <= 'Z')
                    data[(i * 2) + 1] = (byte)((((int)str[i]) - 65 + 0x21) * 4);
                else if (str[i] == '.')
                    data[(i * 2) + 1] = 0x38;
                else if (str[i] == ' ')
                    data[(i * 2) + 1] = 0x00;
            }

            return data;
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2];
            string area = args[3];
            int areaA = System.Convert.ToInt32(area.Substring(0, 1));
            
            int areaB = 0;
            if (area.Length > 1)
                areaB = System.Convert.ToInt32(area.Substring(2, 1));

            int character = System.Convert.ToInt32(args[4]);
            int powerup = System.Convert.ToInt32(args[5]);
            int maxhit = System.Convert.ToInt32(args[6]);

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = 5;
            if (score > (HiConvert.ByteArrayHexToInt(hiscoreData.Score1) * 10) + HiConvert.ByteArrayHexToInt(hiscoreData.LastScore1))
                rank = 0;
            else if (score > (HiConvert.ByteArrayHexToInt(hiscoreData.Score2) * 10) + HiConvert.ByteArrayHexToInt(hiscoreData.LastScore2))
                rank = 1;
            else if (score > (HiConvert.ByteArrayHexToInt(hiscoreData.Score3) * 10) + HiConvert.ByteArrayHexToInt(hiscoreData.LastScore3))
                rank = 2;
            else if (score > (HiConvert.ByteArrayHexToInt(hiscoreData.Score4) * 10) + HiConvert.ByteArrayHexToInt(hiscoreData.LastScore4))
                rank = 3;
            else if (score > (HiConvert.ByteArrayHexToInt(hiscoreData.Score5) * 10) + HiConvert.ByteArrayHexToInt(hiscoreData.LastScore5))
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
                    HiConvert.ByteArrayCopy(hiscoreData.LastScore2, hiscoreData.LastScore1);
                    HiConvert.ByteArrayCopy(hiscoreData.AreaPartA2, hiscoreData.AreaPartA1);
                    HiConvert.ByteArrayCopy(hiscoreData.AreaPartB2, hiscoreData.AreaPartB1);
                    hiscoreData.Character2 = hiscoreData.Character1;
                    hiscoreData.Powerup2 = hiscoreData.Powerup1;
                    HiConvert.ByteArrayCopy(hiscoreData.MaxHit2, hiscoreData.MaxHit1);
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
                    HiConvert.ByteArrayCopy(hiscoreData.LastScore3, hiscoreData.LastScore2);
                    HiConvert.ByteArrayCopy(hiscoreData.AreaPartA3, hiscoreData.AreaPartA2);
                    HiConvert.ByteArrayCopy(hiscoreData.AreaPartB3, hiscoreData.AreaPartB2);
                    hiscoreData.Character3 = hiscoreData.Character2;
                    hiscoreData.Powerup3 = hiscoreData.Powerup2;
                    HiConvert.ByteArrayCopy(hiscoreData.MaxHit3, hiscoreData.MaxHit2);
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, hiscoreData.Score3);
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, hiscoreData.Name3);
                    HiConvert.ByteArrayCopy(hiscoreData.LastScore4, hiscoreData.LastScore3);
                    HiConvert.ByteArrayCopy(hiscoreData.AreaPartA4, hiscoreData.AreaPartA3);
                    HiConvert.ByteArrayCopy(hiscoreData.AreaPartB4, hiscoreData.AreaPartB3);
                    hiscoreData.Character4 = hiscoreData.Character3;
                    hiscoreData.Powerup4 = hiscoreData.Powerup3;
                    HiConvert.ByteArrayCopy(hiscoreData.MaxHit4, hiscoreData.MaxHit3);
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, hiscoreData.Score4);
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, hiscoreData.Name4);
                    HiConvert.ByteArrayCopy(hiscoreData.LastScore5, hiscoreData.LastScore4);
                    HiConvert.ByteArrayCopy(hiscoreData.AreaPartA5, hiscoreData.AreaPartA4);
                    HiConvert.ByteArrayCopy(hiscoreData.AreaPartB5, hiscoreData.AreaPartB4);
                    hiscoreData.Character5 = hiscoreData.Character4;
                    hiscoreData.Powerup5 = hiscoreData.Powerup4;
                    HiConvert.ByteArrayCopy(hiscoreData.MaxHit5, hiscoreData.MaxHit4);
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
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.IntToByteArrayHex(score / 10, hiscoreData.Score1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.HiScore, HiConvert.IntToByteArrayHex(score / 10, hiscoreData.HiScore.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.LastScore1, HiConvert.HexStringToByteArray((score % 10).ToString("D4")));
                    HiConvert.ByteArrayCopy(hiscoreData.Name1, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.AreaPartA1, HiConvert.HexStringToByteArray(areaA.ToString("D4")));
                    HiConvert.ByteArrayCopy(hiscoreData.AreaPartB1, HiConvert.HexStringToByteArray(areaB.ToString("D4")));
                    hiscoreData.Character1 = (byte)character;
                    hiscoreData.Powerup1 = (byte)powerup;
                    HiConvert.ByteArrayCopy(hiscoreData.MaxHit1, HiConvert.HexStringToByteArray(maxhit.ToString("D4")));
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.IntToByteArrayHex(score / 10, hiscoreData.Score2.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.LastScore2, HiConvert.HexStringToByteArray((score % 10).ToString("D4")));
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.AreaPartA2, HiConvert.HexStringToByteArray(areaA.ToString("D4")));
                    HiConvert.ByteArrayCopy(hiscoreData.AreaPartB2, HiConvert.HexStringToByteArray(areaB.ToString("D4")));
                    hiscoreData.Character2 = (byte)character;
                    hiscoreData.Powerup2 = (byte)powerup;
                    HiConvert.ByteArrayCopy(hiscoreData.MaxHit2, HiConvert.HexStringToByteArray(maxhit.ToString("D4")));
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.IntToByteArrayHex(score / 10, hiscoreData.Score3.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.LastScore3, HiConvert.HexStringToByteArray((score % 10).ToString("D4")));
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.AreaPartA3, HiConvert.HexStringToByteArray(areaA.ToString("D4")));
                    HiConvert.ByteArrayCopy(hiscoreData.AreaPartB3, HiConvert.HexStringToByteArray(areaB.ToString("D4")));
                    hiscoreData.Character3 = (byte)character;
                    hiscoreData.Powerup3 = (byte)powerup;
                    HiConvert.ByteArrayCopy(hiscoreData.MaxHit3, HiConvert.HexStringToByteArray(maxhit.ToString("D4")));
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.IntToByteArrayHex(score / 10, hiscoreData.Score4.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.LastScore4, HiConvert.HexStringToByteArray((score % 10).ToString("D4")));
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.AreaPartA4, HiConvert.HexStringToByteArray(areaA.ToString("D4")));
                    HiConvert.ByteArrayCopy(hiscoreData.AreaPartB4, HiConvert.HexStringToByteArray(areaB.ToString("D4")));
                    hiscoreData.Character4 = (byte)character;
                    hiscoreData.Powerup4 = (byte)powerup;
                    HiConvert.ByteArrayCopy(hiscoreData.MaxHit4, HiConvert.HexStringToByteArray(maxhit.ToString("D4")));
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.IntToByteArrayHex(score / 10, hiscoreData.Score5.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.LastScore5, HiConvert.HexStringToByteArray((score % 10).ToString("D4")));
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.AreaPartA5, HiConvert.HexStringToByteArray(areaA.ToString("D4")));
                    HiConvert.ByteArrayCopy(hiscoreData.AreaPartB5, HiConvert.HexStringToByteArray(areaB.ToString("D4")));
                    hiscoreData.Character5 = (byte)character;
                    hiscoreData.Powerup5 = (byte)powerup;
                    HiConvert.ByteArrayCopy(hiscoreData.MaxHit5, HiConvert.HexStringToByteArray(maxhit.ToString("D4")));
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

            HiConvert.ByteArrayCopy(hiscoreData.LastScore1, HiConvert.IntToByteArrayHex(0, hiscoreData.LastScore1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.LastScore2, HiConvert.IntToByteArrayHex(0, hiscoreData.LastScore2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.LastScore3, HiConvert.IntToByteArrayHex(0, hiscoreData.LastScore3.Length));
            HiConvert.ByteArrayCopy(hiscoreData.LastScore4, HiConvert.IntToByteArrayHex(0, hiscoreData.LastScore4.Length));
            HiConvert.ByteArrayCopy(hiscoreData.LastScore5, HiConvert.IntToByteArrayHex(0, hiscoreData.LastScore5.Length));

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public string AreaToString(int areaA, int areaB)
        {
            string toReturn = areaA.ToString();
            if (areaB != 0)
                toReturn += "-" + areaB.ToString();

            return toReturn;
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format(
                         "{0}|{1}|{2}|{3}|{4}|{5}|{6}",
                         1,
                         HiConvert.ByteArrayHexToInt(hiscoreData.Score1) * 10 + HiConvert.ByteArrayHexToInt(hiscoreData.LastScore1), 
                         ByteArrayToString(hiscoreData.Name1), 
                         AreaToString(HiConvert.ByteArrayHexToInt(hiscoreData.AreaPartA1), HiConvert.ByteArrayHexToInt(hiscoreData.AreaPartB1)),
                         hiscoreData.Character1,
                         hiscoreData.Powerup1,
                         HiConvert.ByteArrayHexToInt(hiscoreData.MaxHit1))
                            + Environment.NewLine;
            retString += String.Format(
                         "{0}|{1}|{2}|{3}|{4}|{5}|{6}",
                         2,
                         HiConvert.ByteArrayHexToInt(hiscoreData.Score2) * 10 + HiConvert.ByteArrayHexToInt(hiscoreData.LastScore2),
                         ByteArrayToString(hiscoreData.Name2),
                         AreaToString(HiConvert.ByteArrayHexToInt(hiscoreData.AreaPartA2), HiConvert.ByteArrayHexToInt(hiscoreData.AreaPartB2)),
                         hiscoreData.Character2,
                         hiscoreData.Powerup2,
                         HiConvert.ByteArrayHexToInt(hiscoreData.MaxHit2))
                            + Environment.NewLine;
            retString += String.Format(
                         "{0}|{1}|{2}|{3}|{4}|{5}|{6}",
                         3,
                         HiConvert.ByteArrayHexToInt(hiscoreData.Score3) * 10 + HiConvert.ByteArrayHexToInt(hiscoreData.LastScore3),
                         ByteArrayToString(hiscoreData.Name3),
                         AreaToString(HiConvert.ByteArrayHexToInt(hiscoreData.AreaPartA3), HiConvert.ByteArrayHexToInt(hiscoreData.AreaPartB3)),
                         hiscoreData.Character3,
                         hiscoreData.Powerup3,
                         HiConvert.ByteArrayHexToInt(hiscoreData.MaxHit3))
                            + Environment.NewLine;
            retString += String.Format(
                         "{0}|{1}|{2}|{3}|{4}|{5}|{6}",
                         4,
                         HiConvert.ByteArrayHexToInt(hiscoreData.Score4) * 10 + HiConvert.ByteArrayHexToInt(hiscoreData.LastScore4),
                         ByteArrayToString(hiscoreData.Name4),
                         AreaToString(HiConvert.ByteArrayHexToInt(hiscoreData.AreaPartA4), HiConvert.ByteArrayHexToInt(hiscoreData.AreaPartB4)),
                         hiscoreData.Character4,
                         hiscoreData.Powerup4,
                         HiConvert.ByteArrayHexToInt(hiscoreData.MaxHit4))
                            + Environment.NewLine;
            retString += String.Format(
                         "{0}|{1}|{2}|{3}|{4}|{5}|{6}",
                         5,
                         HiConvert.ByteArrayHexToInt(hiscoreData.Score5) * 10 + HiConvert.ByteArrayHexToInt(hiscoreData.LastScore5),
                         ByteArrayToString(hiscoreData.Name5),
                         AreaToString(HiConvert.ByteArrayHexToInt(hiscoreData.AreaPartA5), HiConvert.ByteArrayHexToInt(hiscoreData.AreaPartB5)),
                         hiscoreData.Character5,
                         hiscoreData.Powerup5,
                         HiConvert.ByteArrayHexToInt(hiscoreData.MaxHit5))
                            + Environment.NewLine;

            return retString;
        }
    }
}
