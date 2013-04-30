using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class hvysmsh : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            public byte Rank1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Lost1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Goals1;
            public byte Cnt1;
            public byte Flag1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Separator1;

            public byte Rank2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Lost2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Goals2;
            public byte Cnt2;
            public byte Flag2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Separator2;

            public byte Rank3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Lost3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Goals3;
            public byte Cnt3;
            public byte Flag3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Separator3;

            public byte Rank4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Lost4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Goals4;
            public byte Cnt4;
            public byte Flag4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Separator4;

            public byte Rank5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Lost5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Goals5;
            public byte Cnt5;
            public byte Flag5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Separator5;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] HiScore;

        }

        public hvysmsh()
        {
            m_numEntries = 5;
            m_format = "RANK|SCORE|NAME|GOAL|LOST|CNT|FLAG";
            m_gamesSupported = "hvysmsh,hvysmshj,hvysmsha";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] >= 0x00 && data[i] <= 0x19)
                    sb.Append((char)(((int)data[i]) + 65));
                else if (data[i] == 0x1a)
                    sb.Append('0');
                else if (data[i] == 0x1b)
                    sb.Append('1');
                else if (data[i] == 0x1c)
                    sb.Append('2');
                else if (data[i] == 0x1d)
                    sb.Append('3');
                else if (data[i] == 0x1e)
                    sb.Append('4');
                else if (data[i] == 0x1f)
                    sb.Append('5');
                else if (data[i] == 0x20)
                    sb.Append('6');
                else if (data[i] == 0x21)
                    sb.Append('7');
                else if (data[i] == 0x22)
                    sb.Append('8');
                else if (data[i] == 0x23)
                    sb.Append('9');
                else if (data[i] == 0x24)
                    sb.Append('!');
                else if (data[i] == 0x25)
                    sb.Append(',');
                else if (data[i] == 0x26)
                    sb.Append('.');
                else if (data[i] == 0x27)
                    sb.Append('=');
                else if (data[i] == 0x28)
                    sb.Append('?');
            }

            return sb.ToString();
        }

        public byte[] StringToByteArray(string str)
        {
            byte[] data = new byte[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 'A' && str[i] <= 'Z')
                    data[i] = (byte)(((int)str[i] - 65));
                else if (str[i] == '0')
                    data[i] = 0x1a;
                else if (str[i] == '1')
                    data[i] = 0x1b;
                else if (str[i] == '2')
                    data[i] = 0x1c;
                else if (str[i] == '3')
                    data[i] = 0x1d;
                else if (str[i] == '4')
                    data[i] = 0x1e;
                else if (str[i] == '5')
                    data[i] = 0x1f;
                else if (str[i] == '6')
                    data[i] = 0x20;
                else if (str[i] == '7')
                    data[i] = 0x21;
                else if (str[i] == '8')
                    data[i] = 0x22;
                else if (str[i] == '9')
                    data[i] = 0x23;
                else if (str[i] == '!')
                    data[i] = 0x24;
                else if (str[i] == ',')
                    data[i] = 0x25;
                else if (str[i] == '.')
                    data[i] = 0x26;
                else if (str[i] == '=')
                    data[i] = 0x27;
                else if (str[i] == '?')
                    data[i] = 0x28;                
            }

            return data;
        }

        private int GetFlag(string flag)
        {
            switch (flag)
            {
                case "USA":
                    return 0;
                case "JAP":
                    return 1;
                case "ESP":
                    return 2;
                case "BRA":
                    return 3;
                case "GER":
                    return 4;
                case "ENG":
                    return 5;
                case "ITA":
                    return 6;
                case "EGY":
                    return 7;
                case "AUS":
                    return 8;
                case "CYB":
                    return 9;
            }

            return -1;
        }

        private string GetFlag(int flag)
        {
            switch (flag)
            {
                case 0:
                    return "USA";
                case 1:
                    return "JAP";
                case 2:
                    return "ESP";
                case 3:
                    return "BRA";
                case 4:
                    return "GER";
                case 5:
                    return "ENG";
                case 6:
                    return "ITA";
                case 7:
                    return "EGY";
                case 8:
                    return "AUS";
                case 9:
                    return "CYB";
            }
            return "";
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2];
            int goal = System.Convert.ToInt32(args[3]);
            int lost = System.Convert.ToInt32(args[4]);
            int cnt = System.Convert.ToInt32(args[5]);
            int flag = GetFlag(args[6]);

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = NumEntries;
            if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score1)))
                rank = 0;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score2)))
                rank = 1;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score3)))
                rank = 2;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score4)))
                rank = 3;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score5)))
                rank = 4;
            #endregion

            #region ADJUST
            int adjust = NumEntries - 1;
            if (rank < NumEntries - 1)
                adjust = NumEntries - 2;
            switch (adjust)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, hiscoreData.Score1);
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, hiscoreData.Name1);
                    HiConvert.ByteArrayCopy(hiscoreData.Goals2, hiscoreData.Goals1);
                    HiConvert.ByteArrayCopy(hiscoreData.Lost2, hiscoreData.Lost1);
                    hiscoreData.Cnt2 = hiscoreData.Cnt1;
                    hiscoreData.Flag2 = hiscoreData.Flag1;
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
                    HiConvert.ByteArrayCopy(hiscoreData.Goals3, hiscoreData.Goals2);
                    HiConvert.ByteArrayCopy(hiscoreData.Lost3, hiscoreData.Lost2);
                    hiscoreData.Cnt3 = hiscoreData.Cnt2;
                    hiscoreData.Flag3 = hiscoreData.Flag2;
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, hiscoreData.Score3);
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, hiscoreData.Name3);
                    HiConvert.ByteArrayCopy(hiscoreData.Goals4, hiscoreData.Goals3);
                    HiConvert.ByteArrayCopy(hiscoreData.Lost4, hiscoreData.Lost3);
                    hiscoreData.Cnt4 = hiscoreData.Cnt3;
                    hiscoreData.Flag4 = hiscoreData.Flag3;
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, hiscoreData.Score4);
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, hiscoreData.Name4);
                    HiConvert.ByteArrayCopy(hiscoreData.Goals5, hiscoreData.Goals4);
                    HiConvert.ByteArrayCopy(hiscoreData.Lost5, hiscoreData.Lost4);
                    hiscoreData.Cnt5 = hiscoreData.Cnt4;
                    hiscoreData.Flag5 = hiscoreData.Flag4;
                    if (rank < 3)
                        goto case 2;
                    break;
            }
            #endregion

            #region REPLACE_NEW
            switch (rank)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Name1, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score1.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.HiScore, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.HiScore.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.Goals1, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(goal, hiscoreData.Goals1.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.Lost1, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(lost, hiscoreData.Lost1.Length)));
                    hiscoreData.Cnt1 = (byte)cnt;
                    hiscoreData.Flag1 = (byte)flag;
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score2.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.Goals2, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(goal, hiscoreData.Goals2.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.Lost2, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(lost, hiscoreData.Lost2.Length)));
                    hiscoreData.Cnt2 = (byte)cnt;
                    hiscoreData.Flag2 = (byte)flag;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score3.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.Goals3, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(goal, hiscoreData.Goals3.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.Lost3, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(lost, hiscoreData.Lost3.Length)));
                    hiscoreData.Cnt3 = (byte)cnt;
                    hiscoreData.Flag3 = (byte)flag;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score4.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.Goals4, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(goal, hiscoreData.Goals4.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.Lost4, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(lost, hiscoreData.Lost4.Length)));
                    hiscoreData.Cnt4 = (byte)cnt;
                    hiscoreData.Flag4 = (byte)flag;
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score5.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.Goals5, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(goal, hiscoreData.Goals5.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.Lost5, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(lost, hiscoreData.Lost5.Length)));
                    hiscoreData.Cnt5 = (byte)cnt;
                    hiscoreData.Flag5 = (byte)flag;
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

            retString += String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}", 
                1, 
                HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score1)), 
                ByteArrayToString(hiscoreData.Name1),
                HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Goals1)),
                HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Lost1)),
                hiscoreData.Cnt1,
                GetFlag((int)hiscoreData.Flag1)) + Environment.NewLine;

            retString += String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}",
                2,
                HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score2)),
                ByteArrayToString(hiscoreData.Name2),
                HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Goals2)),
                HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Lost2)),
                hiscoreData.Cnt2,
                GetFlag((int)hiscoreData.Flag2)) + Environment.NewLine;

            retString += String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}",
                3,
                HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score3)),
                ByteArrayToString(hiscoreData.Name3),
                HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Goals3)),
                HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Lost3)),
                hiscoreData.Cnt3,
                GetFlag((int)hiscoreData.Flag3)) + Environment.NewLine;

            retString += String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}",
                4,
                HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score4)),
                ByteArrayToString(hiscoreData.Name4),
                HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Goals4)),
                HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Lost4)),
                hiscoreData.Cnt4,
                GetFlag((int)hiscoreData.Flag4)) + Environment.NewLine;

            retString += String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}",
                5,
                HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score5)),
                ByteArrayToString(hiscoreData.Name5),
                HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Goals5)),
                HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Lost5)),
                hiscoreData.Cnt5,
                GetFlag((int)hiscoreData.Flag5)) + Environment.NewLine;

            return retString;
        }
    }
}