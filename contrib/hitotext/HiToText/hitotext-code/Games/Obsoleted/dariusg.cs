using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class dariusg : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Zone1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Separator1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Zone2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Separator2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Zone3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Separator3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Zone4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Separator4;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Zone5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name5;
        }

        public dariusg()
        {
            m_numEntries = 5;
            m_format = "RANK|SCORE|NAME|ZONE";
            m_gamesSupported = "dariusg,dariusgx";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] >= 0x41 && data[i] <= 0x5a)
                    sb.Append((char)(int)data[i]);
                else if (data[i] == 0x20)
                    sb.Append(' ');
                else if (data[i] == 0x2e)
                    sb.Append('.');
                else if (data[i] == 0x30)
                    sb.Append('0');
                else if (data[i] == 0x31)
                    sb.Append('1');
                else if (data[i] == 0x32)
                    sb.Append('2');
                else if (data[i] == 0x33)
                    sb.Append('3');
                else if (data[i] == 0x34)
                    sb.Append('4');
                else if (data[i] == 0x35)
                    sb.Append('5');
                else if (data[i] == 0x36)
                    sb.Append('6');
                else if (data[i] == 0x37)
                    sb.Append('7');
                else if (data[i] == 0x38)
                    sb.Append('8');
                else if (data[i] == 0x39)
                    sb.Append('9');
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
                else if (str[i] == ' ')
                    data[i] = 0x20;
                else if (str[i] == '.')
                    data[i] = 0x2e;
                else if (str[i] == '0')
                    data[i] = 0x30;
                else if (str[i] == '1')
                    data[i] = 0x31;
                else if (str[i] == '2')
                    data[i] = 0x32;
                else if (str[i] == '3')
                    data[i] = 0x33;
                else if (str[i] == '4')
                    data[i] = 0x34;
                else if (str[i] == '5')
                    data[i] = 0x35;
                else if (str[i] == '6')
                    data[i] = 0x36;
                else if (str[i] == '7')
                    data[i] = 0x37;
                else if (str[i] == '8')
                    data[i] = 0x38;
                else if (str[i] == '9')
                    data[i] = 0x39;
            }

            return data;
        }

        private int GetZone(String zone)
        {
            //TODO: Figure this one out.
            return Convert.ToInt32(zone);
        }

        private String GetZone(byte[] zone)
        {
            //TODO: Figure this one out.
            return HiConvert.ByteArrayHexToInt(zone).ToString();
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2];
            int zone = GetZone(args[3]);

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = NumEntries;
            if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score1))
                rank = 0;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score2))
                rank = 1;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score3))
                rank = 2;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score4))
                rank = 3;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score5))
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
                    HiConvert.ByteArrayCopy(hiscoreData.Zone2, hiscoreData.Zone1);
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
                    HiConvert.ByteArrayCopy(hiscoreData.Zone3, hiscoreData.Zone2);
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, hiscoreData.Score3);
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, hiscoreData.Name3);
                    HiConvert.ByteArrayCopy(hiscoreData.Zone4, hiscoreData.Zone3);
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, hiscoreData.Score4);
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, hiscoreData.Name4);
                    HiConvert.ByteArrayCopy(hiscoreData.Zone5, hiscoreData.Zone4);
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
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Zone1, HiConvert.IntToByteArrayHex(zone, hiscoreData.Zone1.Length));
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score2.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Zone2, HiConvert.IntToByteArrayHex(zone, hiscoreData.Zone2.Length));
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score3.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Zone3, HiConvert.IntToByteArrayHex(zone, hiscoreData.Zone3.Length));
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score4.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Zone4, HiConvert.IntToByteArrayHex(zone, hiscoreData.Zone4.Length));
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score5.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Zone5, HiConvert.IntToByteArrayHex(zone, hiscoreData.Zone5.Length));
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

            retString += String.Format("{0}|{1}|{2}|{3}", 1, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score1), ByteArrayToString(hiscoreData.Name1), GetZone(hiscoreData.Zone1)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 2, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score2), ByteArrayToString(hiscoreData.Name2), GetZone(hiscoreData.Zone2)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 3, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score3), ByteArrayToString(hiscoreData.Name3), GetZone(hiscoreData.Zone3)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 4, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score4), ByteArrayToString(hiscoreData.Name4), GetZone(hiscoreData.Zone4)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 5, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score5), ByteArrayToString(hiscoreData.Name5), GetZone(hiscoreData.Zone5)) + Environment.NewLine;

            return retString;
        }
    }
}

