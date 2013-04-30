using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class columns : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            public byte Header1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name1;
            public byte Separator1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Jewels1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Level1;
            public byte Footer1;

            public byte Header2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name2;
            public byte Separator2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Jewels2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Level2;
            public byte Footer2;

            public byte Header3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name3;
            public byte Separator3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Jewels3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Level3;
            public byte Footer3;

            public byte Header4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name4;
            public byte Separator4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Jewels4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Level4;
            public byte Footer4;

            public byte Header5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name5;
            public byte Separator5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Jewels5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Level5;
            public byte Footer5;

            public byte Header6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name6;
            public byte Separator6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Jewels6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Level6;
            public byte Footer6;

            public byte Header7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name7;
            public byte Separator7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Jewels7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Level7;
            public byte Footer7;

            public byte Header8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name8;
            public byte Separator8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Jewels8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Level8;
            public byte Footer8;

            public byte Header9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name9;
            public byte Separator9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Jewels9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Level9;
            public byte Footer9;
        }

        public columns()
        {
            m_numEntries = 9;
            m_format = "RANK|SCORE|NAME|JEWELS|LEVEL";
            m_gamesSupported = "columns,columnsj,columns2,column2j";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == 0x3f)
                    sb.Append('?');
                else if (data[i] == 0x2e)
                    sb.Append('.');
                else if (data[i] == 0x00)
                    sb.Append(' ');
                else if (data[i] == 0x20) //Game uses both 0x00, and 0x20 for spaces, they look the same, but are different selections when inputting your name.
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
                if (str[i] == '?')
                    data[i] = 0x3f;
                else if (str[i] == '.')
                    data[i] = 0x2e;
                else if (str[i] == ' ')
                    data[i] = 0x20; //It can also be 0x00, but since it doesn't matter in the game, we'll just use this one.
                else
                    data[i] = (byte)((int)str[i]);
            }

            return data;
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = System.Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2];
            int jewels = System.Convert.ToInt32(args[3]);
            int level = System.Convert.ToInt32(args[4]);

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            //While rank may exist, we still determine that by score.
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
            else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score6))
                rank = 5;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score7))
                rank = 6;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score8))
                rank = 7;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score9))
                rank = 8;
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
                    HiConvert.ByteArrayCopy(hiscoreData.Jewels2, hiscoreData.Jewels1);
                    HiConvert.ByteArrayCopy(hiscoreData.Level2, hiscoreData.Level1);
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
                    HiConvert.ByteArrayCopy(hiscoreData.Jewels2, hiscoreData.Jewels2);
                    HiConvert.ByteArrayCopy(hiscoreData.Level2, hiscoreData.Level2);
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, hiscoreData.Score3);
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, hiscoreData.Name3);
                    HiConvert.ByteArrayCopy(hiscoreData.Jewels4, hiscoreData.Jewels3);
                    HiConvert.ByteArrayCopy(hiscoreData.Level4, hiscoreData.Level3);
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, hiscoreData.Score4);
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, hiscoreData.Name4);
                    HiConvert.ByteArrayCopy(hiscoreData.Jewels5, hiscoreData.Jewels4);
                    HiConvert.ByteArrayCopy(hiscoreData.Level5, hiscoreData.Level4);
                    if (rank < 3)
                        goto case 2;
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, hiscoreData.Score5);
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, hiscoreData.Name5);
                    HiConvert.ByteArrayCopy(hiscoreData.Jewels6, hiscoreData.Jewels5);
                    HiConvert.ByteArrayCopy(hiscoreData.Level6, hiscoreData.Level5);
                    if (rank < 4)
                        goto case 3;
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, hiscoreData.Score6);
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, hiscoreData.Name6);
                    HiConvert.ByteArrayCopy(hiscoreData.Jewels7, hiscoreData.Jewels6);
                    HiConvert.ByteArrayCopy(hiscoreData.Level7, hiscoreData.Level6);
                    if (rank < 5)
                        goto case 4;
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, hiscoreData.Score7);
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, hiscoreData.Name7);
                    HiConvert.ByteArrayCopy(hiscoreData.Jewels8, hiscoreData.Jewels7);
                    HiConvert.ByteArrayCopy(hiscoreData.Level8, hiscoreData.Level7);
                    if (rank < 6)
                        goto case 5;
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, hiscoreData.Score8);
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, hiscoreData.Name8);
                    HiConvert.ByteArrayCopy(hiscoreData.Jewels9, hiscoreData.Jewels8);
                    HiConvert.ByteArrayCopy(hiscoreData.Level9, hiscoreData.Level8);
                    if (rank < 7)
                        goto case 6;
                    break;
            }
            #endregion

            #region REPLACE_NEW
            switch (rank)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Name1, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Jewels1, HiConvert.IntToByteArrayHexAsHex(jewels, hiscoreData.Jewels1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Level1, HiConvert.IntToByteArrayHexAsHex(level, hiscoreData.Level1.Length));
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score2.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Jewels2, HiConvert.IntToByteArrayHexAsHex(jewels, hiscoreData.Jewels2.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Level2, HiConvert.IntToByteArrayHexAsHex(level, hiscoreData.Level2.Length));
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score3.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Jewels3, HiConvert.IntToByteArrayHexAsHex(jewels, hiscoreData.Jewels3.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Level3, HiConvert.IntToByteArrayHexAsHex(level, hiscoreData.Level3.Length));
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score4.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Jewels4, HiConvert.IntToByteArrayHexAsHex(jewels, hiscoreData.Jewels4.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Level4, HiConvert.IntToByteArrayHexAsHex(level, hiscoreData.Level4.Length));
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score5.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Jewels5, HiConvert.IntToByteArrayHexAsHex(jewels, hiscoreData.Jewels5.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Level5, HiConvert.IntToByteArrayHexAsHex(level, hiscoreData.Level5.Length));
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score6.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Jewels6, HiConvert.IntToByteArrayHexAsHex(jewels, hiscoreData.Jewels6.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Level6, HiConvert.IntToByteArrayHexAsHex(level, hiscoreData.Level6.Length));
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score7.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Jewels7, HiConvert.IntToByteArrayHexAsHex(jewels, hiscoreData.Jewels7.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Level7, HiConvert.IntToByteArrayHexAsHex(level, hiscoreData.Level7.Length));
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score8.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Jewels8, HiConvert.IntToByteArrayHexAsHex(jewels, hiscoreData.Jewels8.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Level8, HiConvert.IntToByteArrayHexAsHex(level, hiscoreData.Level8.Length));
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score9.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Jewels9, HiConvert.IntToByteArrayHexAsHex(jewels, hiscoreData.Jewels9.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Level9, HiConvert.IntToByteArrayHexAsHex(level, hiscoreData.Level9.Length));
                    break;
            }
            #endregion

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score3.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score4.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score5.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score6, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score6.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score7, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score7.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score8, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score8.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score9, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score9.Length));

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 1, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score1), ByteArrayToString(hiscoreData.Name1), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Jewels1), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Level1)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 2, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score2), ByteArrayToString(hiscoreData.Name2), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Jewels2), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Level2)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 3, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score3), ByteArrayToString(hiscoreData.Name3), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Jewels3), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Level3)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 4, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score4), ByteArrayToString(hiscoreData.Name4), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Jewels4), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Level4)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 5, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score5), ByteArrayToString(hiscoreData.Name5), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Jewels5), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Level5)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 6, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score6), ByteArrayToString(hiscoreData.Name6), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Jewels6), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Level6)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 7, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score7), ByteArrayToString(hiscoreData.Name7), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Jewels7), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Level7)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 8, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score8), ByteArrayToString(hiscoreData.Name8), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Jewels8), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Level8)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 9, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score9), ByteArrayToString(hiscoreData.Name9), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Jewels9), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Level9)) + Environment.NewLine;
            
            return retString;
        }
    }
}