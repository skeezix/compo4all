using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class blockout : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Name1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Name2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Name3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Name4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Name5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Name6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Name7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Name8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Name9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Name10;

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
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score10;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Face1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Face2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Face3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Face4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Face5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Face6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Face7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Face8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Face9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Face10;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] HiScore;
        }

        public blockout()
        {
            // MAX. SCORE = 9,999,999
            m_numEntries = 10;
            m_format = "RANK|SCORE|NAME|FACE";
            m_gamesSupported = "blockout,blockoutj,blockout2";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] >= 0x0f && data[i] <= 0x18)
                    sb.Append(((char)((((int)data[i])) + 48 - 0x0f)));
                else if (data[i] >= 0x1f && data[i] <= 0x38)
                    sb.Append(((char)((((int)data[i])) + 65 - 0x1f)));
                else if (data[i] == 0x53)
                    sb.Append(' ');
                else if (data[i] == 0x0d)
                    sb.Append('.');
            }

            return sb.ToString();
        }

        public byte[] StringToByteArray(string str)
        {
            byte[] data = new byte[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                if (str.ToUpper()[i] >= '0' && str.ToUpper()[i] <= '9')
                    data[i] = (byte)(((int)str.ToUpper()[i] - 48 + 0x0f));
                else if (str.ToUpper()[i] >= 'A' && str.ToUpper()[i] <= 'Z')
                    data[i] = (byte)(((int)str.ToUpper()[i] - 65 + 0x1f));
                else if (str[i] == ' ')
                    data[i] = 0x53;
                else if (str[i] == '.')
                    data[i] = 0x0d;
            }

            return data;
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2].ToUpper().PadRight(4, (char)0x00).Substring(0, 4); // Catching also 0x00
            int face = System.Convert.ToInt32(args[3]);
            
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = NumEntries;
            if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score1))
                rank = 0;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score2))
                rank = 1;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score3))
                rank = 2;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score4))
                rank = 3;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score5))
                rank = 4;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score6))
                rank = 5;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score7))
                rank = 6;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score8))
                rank = 7;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score9))
                rank = 8;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score10))
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
                    HiConvert.ByteArrayCopy(hiscoreData.Face2, hiscoreData.Face1);
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
                    HiConvert.ByteArrayCopy(hiscoreData.Face3, hiscoreData.Face2);
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, hiscoreData.Score3);
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, hiscoreData.Name3);
                    HiConvert.ByteArrayCopy(hiscoreData.Face4, hiscoreData.Face3);
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, hiscoreData.Score4);
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, hiscoreData.Name4);
                    HiConvert.ByteArrayCopy(hiscoreData.Face5, hiscoreData.Face4);
                    if (rank < 3)
                        goto case 2;
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, hiscoreData.Score5);
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, hiscoreData.Name5);
                    HiConvert.ByteArrayCopy(hiscoreData.Face6, hiscoreData.Face5);
                    if (rank < 4)
                        goto case 3;
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, hiscoreData.Score6);
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, hiscoreData.Name6);
                    HiConvert.ByteArrayCopy(hiscoreData.Face7, hiscoreData.Face6);
                    if (rank < 5)
                        goto case 4;
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, hiscoreData.Score7);
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, hiscoreData.Name7);
                    HiConvert.ByteArrayCopy(hiscoreData.Face8, hiscoreData.Face7);
                    if (rank < 6)
                        goto case 5;
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, hiscoreData.Score8);
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, hiscoreData.Name8);
                    HiConvert.ByteArrayCopy(hiscoreData.Face9, hiscoreData.Face8);
                    if (rank < 7)
                        goto case 6;
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, hiscoreData.Score9);
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, hiscoreData.Name9);
                    HiConvert.ByteArrayCopy(hiscoreData.Face10, hiscoreData.Face9);
                    if (rank < 8)
                        goto case 7;
                    break;
            }
            #endregion

            #region REPLACE_NEW
            switch (rank)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Name1, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.IntToByteArrayHex(score, hiscoreData.Score1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Face1, HiConvert.IntToByteArrayHex(face, hiscoreData.Face1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.HiScore, hiscoreData.Score1);
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.IntToByteArrayHex(score, hiscoreData.Score2.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Face2, HiConvert.IntToByteArrayHex(face, hiscoreData.Face2.Length));
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.IntToByteArrayHex(score, hiscoreData.Score3.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Face3, HiConvert.IntToByteArrayHex(face, hiscoreData.Face3.Length));
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.IntToByteArrayHex(score, hiscoreData.Score4.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Face4, HiConvert.IntToByteArrayHex(face, hiscoreData.Face4.Length));
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.IntToByteArrayHex(score, hiscoreData.Score5.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Face5, HiConvert.IntToByteArrayHex(face, hiscoreData.Face5.Length));
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, HiConvert.IntToByteArrayHex(score, hiscoreData.Score6.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Face6, HiConvert.IntToByteArrayHex(face, hiscoreData.Face6.Length));
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, HiConvert.IntToByteArrayHex(score, hiscoreData.Score7.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Face7, HiConvert.IntToByteArrayHex(face, hiscoreData.Face7.Length));
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, HiConvert.IntToByteArrayHex(score, hiscoreData.Score8.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Face8, HiConvert.IntToByteArrayHex(face, hiscoreData.Face8.Length));
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, HiConvert.IntToByteArrayHex(score, hiscoreData.Score9.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Face9, HiConvert.IntToByteArrayHex(face, hiscoreData.Face9.Length));
                    break;
                case 9:
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, HiConvert.IntToByteArrayHex(score, hiscoreData.Score10.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Face10, HiConvert.IntToByteArrayHex(face, hiscoreData.Face10.Length));
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

            retString += String.Format("{0}|{1}|{2}|{3}", 1, HiConvert.ByteArrayHexToInt(hiscoreData.Score1).ToString().PadLeft(7, '0'), ByteArrayToString(hiscoreData.Name1), HiConvert.ByteArrayHexToInt(hiscoreData.Face1).ToString().PadLeft(4, '0')) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 2, HiConvert.ByteArrayHexToInt(hiscoreData.Score2).ToString().PadLeft(7, '0'), ByteArrayToString(hiscoreData.Name2), HiConvert.ByteArrayHexToInt(hiscoreData.Face2).ToString().PadLeft(4, '0')) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 3, HiConvert.ByteArrayHexToInt(hiscoreData.Score3).ToString().PadLeft(7, '0'), ByteArrayToString(hiscoreData.Name3), HiConvert.ByteArrayHexToInt(hiscoreData.Face3).ToString().PadLeft(4, '0')) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 4, HiConvert.ByteArrayHexToInt(hiscoreData.Score4).ToString().PadLeft(7, '0'), ByteArrayToString(hiscoreData.Name4), HiConvert.ByteArrayHexToInt(hiscoreData.Face4).ToString().PadLeft(4, '0')) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 5, HiConvert.ByteArrayHexToInt(hiscoreData.Score5).ToString().PadLeft(7, '0'), ByteArrayToString(hiscoreData.Name5), HiConvert.ByteArrayHexToInt(hiscoreData.Face5).ToString().PadLeft(4, '0')) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 6, HiConvert.ByteArrayHexToInt(hiscoreData.Score6).ToString().PadLeft(7, '0'), ByteArrayToString(hiscoreData.Name6), HiConvert.ByteArrayHexToInt(hiscoreData.Face6).ToString().PadLeft(4, '0')) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 7, HiConvert.ByteArrayHexToInt(hiscoreData.Score7).ToString().PadLeft(7, '0'), ByteArrayToString(hiscoreData.Name7), HiConvert.ByteArrayHexToInt(hiscoreData.Face7).ToString().PadLeft(4, '0')) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 8, HiConvert.ByteArrayHexToInt(hiscoreData.Score8).ToString().PadLeft(7, '0'), ByteArrayToString(hiscoreData.Name8), HiConvert.ByteArrayHexToInt(hiscoreData.Face8).ToString().PadLeft(4, '0')) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 9, HiConvert.ByteArrayHexToInt(hiscoreData.Score9).ToString().PadLeft(7, '0'), ByteArrayToString(hiscoreData.Name9), HiConvert.ByteArrayHexToInt(hiscoreData.Face9).ToString().PadLeft(4, '0')) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 10, HiConvert.ByteArrayHexToInt(hiscoreData.Score10).ToString().PadLeft(7, '0'), ByteArrayToString(hiscoreData.Name10), HiConvert.ByteArrayHexToInt(hiscoreData.Face10).ToString().PadLeft(4, '0')) + Environment.NewLine;
           
            return retString;
        }
    }
}