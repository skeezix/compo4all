using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class pbaction : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Score1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Score2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Score3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Score4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Score5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Score6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Score7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Score8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Score9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Score10;

            public byte Buffer;
            
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name1;
            public byte Separator1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name2;
            public byte Separator2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name3;
            public byte Separator3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name4;
            public byte Separator4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name5;
            public byte Separator5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name6;
            public byte Separator6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name7;
            public byte Separator7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name8;
            public byte Separator8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name9;
            public byte Separator9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name10;
        }

        public pbaction()
        {
            m_numEntries = 10;
            m_format = "RANK|SCORE|NAME";
            m_gamesSupported = "pbaction,pbactio2,pbactio3";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == 0x3a)
                    sb.Append('.');
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
                if (str[i] == '.')
                    data[i] = 0x3a;
                else
                    data[i] = (byte)((int)str[i]);
            }

            return data;
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = System.Convert.ToInt32(args[0]);
            long score = System.Convert.ToInt64(args[1]) / 10;
            string name = args[2];

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = NumEntries;
            if (score > HiConvert.ByteArraySingleBCDToLong(HiConvert.ReverseByteArray(hiscoreData.Score1)))
                rank = 0;
            else if (score > HiConvert.ByteArraySingleBCDToLong(HiConvert.ReverseByteArray(hiscoreData.Score2)))
                rank = 1;
            else if (score > HiConvert.ByteArraySingleBCDToLong(HiConvert.ReverseByteArray(hiscoreData.Score3)))
                rank = 2;
            else if (score > HiConvert.ByteArraySingleBCDToLong(HiConvert.ReverseByteArray(hiscoreData.Score4)))
                rank = 3;
            else if (score > HiConvert.ByteArraySingleBCDToLong(HiConvert.ReverseByteArray(hiscoreData.Score5)))
                rank = 4;
            else if (score > HiConvert.ByteArraySingleBCDToLong(HiConvert.ReverseByteArray(hiscoreData.Score6)))
                rank = 5;
            else if (score > HiConvert.ByteArraySingleBCDToLong(HiConvert.ReverseByteArray(hiscoreData.Score7)))
                rank = 6;
            else if (score > HiConvert.ByteArraySingleBCDToLong(HiConvert.ReverseByteArray(hiscoreData.Score8)))
                rank = 7;
            else if (score > HiConvert.ByteArraySingleBCDToLong(HiConvert.ReverseByteArray(hiscoreData.Score9)))
                rank = 8;
            else if (score > HiConvert.ByteArraySingleBCDToLong(HiConvert.ReverseByteArray(hiscoreData.Score10)))
                rank = 9;
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
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, hiscoreData.Score3);
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, hiscoreData.Name3);
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, hiscoreData.Score4);
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, hiscoreData.Name4);
                    if (rank < 3)
                        goto case 2;
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, hiscoreData.Score5);
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, hiscoreData.Name5);
                    if (rank < 4)
                        goto case 3;
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, hiscoreData.Score6);
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, hiscoreData.Name6);
                    if (rank < 5)
                        goto case 4;
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, hiscoreData.Score7);
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, hiscoreData.Name7);
                    if (rank < 6)
                        goto case 5;
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, hiscoreData.Score8);
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, hiscoreData.Name8);
                    if (rank < 7)
                        goto case 6;
                    break;
                case 8:
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
                    HiConvert.ByteArrayCopy(hiscoreData.Name1, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.ReverseByteArray(HiConvert.LongToByteArraySingleBCD(score, hiscoreData.Score1.Length)));
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.ReverseByteArray(HiConvert.LongToByteArraySingleBCD(score, hiscoreData.Score2.Length)));
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.ReverseByteArray(HiConvert.LongToByteArraySingleBCD(score, hiscoreData.Score3.Length)));
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.ReverseByteArray(HiConvert.LongToByteArraySingleBCD(score, hiscoreData.Score4.Length)));
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.ReverseByteArray(HiConvert.LongToByteArraySingleBCD(score, hiscoreData.Score5.Length)));
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, HiConvert.ReverseByteArray(HiConvert.LongToByteArraySingleBCD(score, hiscoreData.Score6.Length)));
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, HiConvert.ReverseByteArray(HiConvert.LongToByteArraySingleBCD(score, hiscoreData.Score7.Length)));
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, HiConvert.ReverseByteArray(HiConvert.LongToByteArraySingleBCD(score, hiscoreData.Score8.Length)));
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, HiConvert.ReverseByteArray(HiConvert.LongToByteArraySingleBCD(score, hiscoreData.Score9.Length)));
                    break;
                case 9:
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, HiConvert.ReverseByteArray(HiConvert.LongToByteArraySingleBCD(score, hiscoreData.Score10.Length)));
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

            retString += String.Format("{0}|{1}|{2}", 1, HiConvert.ByteArraySingleBCDToLong(HiConvert.ReverseByteArray(hiscoreData.Score1)) * 10, ByteArrayToString(hiscoreData.Name1)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 2, HiConvert.ByteArraySingleBCDToLong(HiConvert.ReverseByteArray(hiscoreData.Score2)) * 10, ByteArrayToString(hiscoreData.Name2)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 3, HiConvert.ByteArraySingleBCDToLong(HiConvert.ReverseByteArray(hiscoreData.Score3)) * 10, ByteArrayToString(hiscoreData.Name3)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 4, HiConvert.ByteArraySingleBCDToLong(HiConvert.ReverseByteArray(hiscoreData.Score4)) * 10, ByteArrayToString(hiscoreData.Name4)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 5, HiConvert.ByteArraySingleBCDToLong(HiConvert.ReverseByteArray(hiscoreData.Score5)) * 10, ByteArrayToString(hiscoreData.Name5)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 6, HiConvert.ByteArraySingleBCDToLong(HiConvert.ReverseByteArray(hiscoreData.Score6)) * 10, ByteArrayToString(hiscoreData.Name6)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 7, HiConvert.ByteArraySingleBCDToLong(HiConvert.ReverseByteArray(hiscoreData.Score7)) * 10, ByteArrayToString(hiscoreData.Name7)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 8, HiConvert.ByteArraySingleBCDToLong(HiConvert.ReverseByteArray(hiscoreData.Score8)) * 10, ByteArrayToString(hiscoreData.Name8)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 9, HiConvert.ByteArraySingleBCDToLong(HiConvert.ReverseByteArray(hiscoreData.Score9)) * 10, ByteArrayToString(hiscoreData.Name9)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 10, HiConvert.ByteArraySingleBCDToLong(HiConvert.ReverseByteArray(hiscoreData.Score10)) * 10, ByteArrayToString(hiscoreData.Name10)) + Environment.NewLine;
            
            return retString;
        }
    }
}